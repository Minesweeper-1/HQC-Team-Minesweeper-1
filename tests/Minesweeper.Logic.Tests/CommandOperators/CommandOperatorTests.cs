﻿// <copyright file="CommandOperatorTests.cs" company="Team Minesweeper-1">
// Copyright (c) The team. All rights reserved.
// </copyright>
namespace Minesweeper.Logic.Tests.CommandOperators
{
    using System.Collections.Generic;

    using Logic.Boards;
    using Logic.Boards.Contracts;
    using Logic.Boards.Settings;
    using Logic.CommandOperators;
    using Logic.Scoreboards;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Test class for the CommandOperators class
    /// </summary>
    [TestClass]
    public class CommandOperatorTests
    {
        /// <summary>
        /// Execute method test
        /// </summary>
        [TestMethod]
        public void TheExecuteMethodShouldExecuteTheCorrectCommandBasedOnTheInput()
        {
            var testOperator = new CommandOperator(
                new Board(new EasyBoardSettings(), new List<IBoardObserver>()),
                new Scoreboard());
            testOperator.Execute(command: "play");
            testOperator.Execute(command: "exit");
            testOperator.Execute(command: "restart");
            testOperator.Execute(command: "invalid");
        }
    }
}