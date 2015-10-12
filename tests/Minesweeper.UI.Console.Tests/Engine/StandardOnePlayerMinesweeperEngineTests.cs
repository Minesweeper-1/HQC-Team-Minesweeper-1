// <copyright file="StandardOnePlayerMinesweeperEngineTests.cs" company="Team Minesweeper-1">
// Copyright (c) The team. All rights reserved.
// </copyright>
namespace Minesweeper.UI.Console.Tests.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using Console.Engine;
    using Console.Engine.Initializations;
    using Console.InputProviders.Contracts;
    using Console.Renderers;
    using Logic.Boards;
    using Logic.Boards.Contracts;
    using Logic.Boards.Settings;
    using Logic.CommandOperators;
    using Logic.Common;
    using Logic.Contents;
    using Logic.Players;
    using Logic.Scoreboards.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// A test class for the StandardOnePlayerMinesweeperEngine class
    /// </summary>
    [TestClass]
    public class StandardOnePlayerMinesweeperEngineTests
    {
        /// <summary>
        /// Standard output handle constant
        /// </summary>
        private const uint StdOutputHandle = 0xFFFFFFF5;

        /// <summary>
        /// Allocates a new console for the calling process.
        /// </summary>
        /// <returns>True upon success and false otherwise</returns>
        [DllImport("kernel32")]
        public static extern bool AllocConsole();

        /// <summary>
        /// Running with the engine should throw an NullReferenceException when some of the required components are not set
        /// </summary>
        [TestMethod]
        public void StandardOnePlayerMinesweeperEngineTest()
        {
            AllocConsole();
            var testInputProvider = new Mock<IConsoleInputProvider>();
            testInputProvider.Setup(o => o.ReceiveInputLine()).Returns("1 a");
            testInputProvider.Setup(o => o.TransformCommandToNumbersOnly("1 a")).Returns("1 a");
            var testOutputRenderer = new ConsoleRenderer();
            var testScoreboard = new Mock<IScoreboard>();
            var testBoard = new Board(new EasyBoardSettings(), new List<IBoardObserver>());
            var testEngine = new StandardOnePlayerMinesweeperEngine(
                testBoard,
                testInputProvider.Object,
                testOutputRenderer,
                new CommandOperator(testBoard, testScoreboard.Object),
                testScoreboard.Object,
                new Player("Gosho"));
            testEngine.Initialize(new StandardGameInitializationStrategy(new ContentFactory()));
            testEngine.Update(new Notification("test", BoardState.Closed));

            bool completed = this.ExecuteWithTimeLimit(
                TimeSpan.FromMilliseconds(200),
                () =>
                {
                    testEngine.Run();
                });
        }

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetStdHandle(uint stdHandle);
        [DllImport("kernel32.dll")]
        private static extern void SetStdHandle(uint stdHandle, IntPtr handle);

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