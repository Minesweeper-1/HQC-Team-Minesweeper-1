// <copyright file="GameTests.cs" company="Team Minesweeper-1">
// Copyright (c) The team. All rights reserved.
// </copyright>
namespace Minesweeper.UI.Console.Tests
{
    using System;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using Console.Renderers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper.UI.Console.InputProviders.Contracts;
    using Minesweeper.UI.Console.Renderers.Contracts;
    using Moq;

    /// <summary>
    /// A test class for the Game class.
    /// </summary>
    [TestClass]
    public class GameTests
    {
        /// <summary>
        /// Standard output handle constant.
        /// </summary>
        private const uint StdOutputHandle = 0xFFFFFFF5;

        /// <summary>
        /// Allocates a new console for the calling process.
        /// </summary>
        /// <returns>True upon success and false otherwise.</returns>
        [DllImport("kernel32")]
        public static extern bool AllocConsole();

        /// <summary>
        /// Testing singleton functionality.
        /// </summary>
        [TestMethod]
        public void GameInstanceShouldCreateOnlyOneInstanceAndReturnIt()
        {
            var gameInstance = Game.Instance;
            var secondInstance = Game.Instance;
            Assert.AreSame(gameInstance, secondInstance);
        }

        /// <summary>
        /// Game start with correct settings and allowed 200 microseconds execution time.
        /// </summary>
        [TestMethod]
        public void TestStart()
        {
            AllocConsole();
            var gameInstance = Game.Instance;
            var inputMock = new Mock<IConsoleInputProvider>();
            var outputMock = new ConsoleRenderer();
            inputMock.Setup(x => x.IsKeyAvailable).Returns(true);
            inputMock.Setup(x => x.GetKeyChar()).Returns(' ');
            inputMock.Setup(x => x.ReceiveInputLine()).Returns("1 1");
            inputMock.Setup(x => x.TransformCommandToNumbersOnly(It.IsAny<string>())).Returns("1 1");
            gameInstance.InputProvider = inputMock.Object;
            gameInstance.OutputRenderer = outputMock;
            inputMock.Verify();
            outputMock.SetCursor(6, 0);

            bool completed = this.ExecuteWithTimeLimit(
              TimeSpan.FromMilliseconds(200),
              () =>
              {
                  gameInstance.Start();
              });
        }

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetStdHandle(uint stdHandle);
        [DllImport("kernel32.dll")]
        private static extern void SetStdHandle(uint stdHandle, IntPtr handle);

        /// <summary>
        /// Limits method execution time. It is used to skip wait for user input.
        /// </summary>
        /// <param name="timeSpan">Allow time of execution.</param>
        /// <param name="codeBlock">Code to be executed.</param>
        /// <returns>Code that will be terminated after time span.</returns>
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