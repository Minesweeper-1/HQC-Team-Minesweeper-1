﻿// <copyright file="GameTests.cs" company="Team Minesweeper-1">
// Copyright (c) The team. All rights reserved.
// </copyright>
namespace Minesweeper.UI.Console.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper.UI.Console.InputProviders.Contracts;
    using Minesweeper.UI.Console.Renderers.Contracts;
    using Moq;

    /// <summary>
    /// A test class for the Game class
    /// </summary>
    [TestClass]
    public class GameTests
    {
        /// <summary>
        /// Testing singleton functionality
        /// </summary>
        [TestMethod]
        public void GameInstanceShouldCreateOnlyOneInstanceAndReturnIt()
        {
            var gameInstance = Game.Instance;
            var secondInstance = Game.Instance;
            Assert.AreSame(gameInstance, secondInstance);
        }

        /// <summary>
        /// Starting the game with not fully correct settings should throw an exception
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestStart()
        {
            var gameInstance = Game.Instance;
            var inputMock = new Mock<IConsoleInputProvider>();
            var outputMock = new Mock<IConsoleRenderer>();
            inputMock.Setup(x => x.IsKeyAvailable).Returns(true);
            inputMock.Setup(x => x.GetKeyChar()).Returns(' ');
            inputMock.Setup(x => x.ReceiveInputLine()).Returns("1 1");
            inputMock.Setup(x => x.TransformCommandToNumbersOnly(It.IsAny<string>())).Returns("1 1");
            gameInstance.InputProvider = inputMock.Object;
            gameInstance.OutputRenderer = outputMock.Object;
            inputMock.Verify();
            gameInstance.Start();
        }
    }
}