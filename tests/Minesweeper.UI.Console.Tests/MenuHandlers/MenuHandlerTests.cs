// <copyright file="MenuHandlerTests.cs" company="Team Minesweeper-1">
// Copyright (c) The team. All rights reserved.
// </copyright>
namespace Minesweeper.UI.Console.Tests.MenuHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using Console.InputProviders.Contracts;
    using Console.MenuHandlers;
    using Console.Renderers;
    using Console.Renderers.Contracts;
    using Logic.DifficultyCommands;
    using Logic.DifficultyCommands.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Tests for MenuHandler class
    /// </summary>
    [TestClass]
    public class MenuHandlerTests
    {
        /// <summary>
        /// Console constant;
        /// </summary>
        private const uint StdOutputHandle = 0xFFFFFFF5;

        /// <summary>
        /// Console creator
        /// </summary>
        /// <returns>Provides usable console</returns>
        [DllImport("kernel32")]
        public static extern bool AllocConsole();

        /// <summary>
        /// Test Constructor with mocked items
        /// </summary>
        [TestMethod]
        public void ExpectNoExcpetionFromMenuHandlerConstructor()
        {
            var mockedConsoleRenderer = new Mock<IConsoleRenderer>();
            var mockedInputProvider = new Mock<IConsoleInputProvider>();
            var gameModes = new List<IGameMode>();
            gameModes.Add(new BeginnerMode());

            var consoleMenuHandler = new ConsoleMenuHandler(mockedInputProvider.Object, mockedConsoleRenderer.Object, gameModes, 0, 0);
        }

        /// <summary>
        /// Test show function with mocked renderer and input provider
        /// </summary>
        [TestMethod]
        public void ExpectNoExcpetionFromMenuHandlerShowMenu()
        {
            var mockedConsoleRenderer = new Mock<IConsoleRenderer>();
            var mockedInputProvider = new Mock<IConsoleInputProvider>();
            var gameModes = new List<IGameMode>();
            gameModes.Add(new BeginnerMode());

            var consoleMenuHandler = new ConsoleMenuHandler(mockedInputProvider.Object, mockedConsoleRenderer.Object, gameModes, 0, 0);

            consoleMenuHandler.ShowSelections();
        }

        /// <summary>
        /// Test selection menu user selection when no input is provided
        /// </summary>
        [TestMethod]
        public void ExpectNoExcpetionFromMenuHandlerUserSelection()
        {
            var mockedConsoleRenderer = new Mock<IConsoleRenderer>();
            var mockedInputProvider = new Mock<IConsoleInputProvider>();
            mockedInputProvider.Setup(o => o.IsKeyAvailable).Returns(true);
            var gameModes = new List<IGameMode>();
            gameModes.Add(new BeginnerMode());

            var consoleMenuHandler = new ConsoleMenuHandler(mockedInputProvider.Object, mockedConsoleRenderer.Object, gameModes, 0, 0);

            consoleMenuHandler.RequestUserSelection();
        }

        /// <summary>
        /// Test selection menu when enter is pressed
        /// </summary>
        [TestMethod]
        public void ExpectNoExcpetionFromMenuHandlerUserSelectionDownsEnter()
        {
            var mockedConsoleRenderer = new Mock<IConsoleRenderer>();
            var mockedInputProvider = new Mock<IConsoleInputProvider>();
            mockedInputProvider.Setup(o => o.IsKeyAvailable).Returns(false);
            mockedInputProvider.Setup(o => o.GetKeyChar()).Returns(13);
            
            var gameModes = new List<IGameMode>();
            gameModes.Add(new BeginnerMode());
            gameModes.Add(new ExpertMode());

            var consoleMenuHandler = new ConsoleMenuHandler(mockedInputProvider.Object, mockedConsoleRenderer.Object, gameModes, 10, 5);

            consoleMenuHandler.RequestUserSelection();
        }

        /// <summary>
        /// Test selection menu when up arrow is pressed 200 micro seconds
        /// </summary>
        [TestMethod]
        public void ExpectNoExcpetionFromMenuHandlerUserSelectionDownSelection()
        {
            AllocConsole();
            var mockedConsoleRenderer = new ConsoleRenderer();
            var mockedInputProvider = new Mock<IConsoleInputProvider>();
            mockedInputProvider.Setup(o => o.IsKeyAvailable).Returns(false);
            mockedInputProvider.Setup(o => o.GetKeyChar()).Returns(38);

            var gameModes = new List<IGameMode>();
            gameModes.Add(new BeginnerMode());
            gameModes.Add(new ExpertMode());
            gameModes.Add(new BeginnerMode());

            var consoleMenuHandler = new ConsoleMenuHandler(mockedInputProvider.Object, mockedConsoleRenderer, gameModes, 10, 6);

            bool completed = this.ExecuteWithTimeLimit(
                TimeSpan.FromMilliseconds(200), 
                () =>
            {
                consoleMenuHandler.RequestUserSelection();
            });            
        }

        /// <summary>
        /// Test selection menu when up arrow is pressed 200 micro seconds
        /// </summary>
        [TestMethod]
        public void ExpectNoExcpetionFromMenuHandlerUserSelectionUpSelection()
        {
            AllocConsole();
            var mockedConsoleRenderer = new ConsoleRenderer();
            var mockedInputProvider = new Mock<IConsoleInputProvider>();
            mockedInputProvider.Setup(o => o.IsKeyAvailable).Returns(false);
            mockedInputProvider.Setup(o => o.GetKeyChar()).Returns(40);
            mockedInputProvider.Setup(o => o.TransformCommandToNumbersOnly("1 a")).Returns("1 a");

            var gameModes = new List<IGameMode>();
            gameModes.Add(new BeginnerMode());
            gameModes.Add(new ExpertMode());
            gameModes.Add(new BeginnerMode());

            var consoleMenuHandler = new ConsoleMenuHandler(mockedInputProvider.Object, mockedConsoleRenderer, gameModes, 10, 5);

            bool completed = this.ExecuteWithTimeLimit(
                TimeSpan.FromMilliseconds(200), 
                () =>
            {
                consoleMenuHandler.RequestUserSelection();
            });
        }

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetStdHandle(uint nonStardarddHandle);
        [DllImport("kernel32.dll")]
        private static extern void SetStdHandle(uint nonStardarddHandle, IntPtr handle);

        /// <summary>
        /// Limits method execution time. It is used to skip wait for user input
        /// </summary>
        /// <param name="timeSpan">Allow time of execution</param>
        /// <param name="codeBlock">Code to be executed</param>
        /// <returns>Code that will be terminated after time span</returns>
        private bool ExecuteWithTimeLimit(TimeSpan timeSpan, Action codeBlock)
        {
            try
            {
                Task task = Task.Factory.StartNew(() => codeBlock());
                task.Wait(timeSpan);
                return task.IsCompleted;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerExceptions[0];
            }
        }
    }
}
