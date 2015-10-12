// <copyright file="MenuHandlerTests.cs" company="Team Minesweeper-1">
// Copyright (c) The team. All rights reserved.
// </copyright>
namespace Minesweeper.UI.Console.Tests.MenuHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using Console.InputProviders.Contracts;
    using Console.MenuHandlers;
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
        /// test selection menu when input is provided
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

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetStdHandle(uint nonStardarddHandle);
        [DllImport("kernel32.dll")]
        private static extern void SetStdHandle(uint nonStardarddHandle, IntPtr handle);        
    }
}
