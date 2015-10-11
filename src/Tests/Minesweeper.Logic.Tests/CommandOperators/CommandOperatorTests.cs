namespace Minesweeper.Logic.CommandOperators.Tests
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Minesweeper.Logic.Boards;
    using Minesweeper.Logic.Boards.Contracts;
    using Minesweeper.Logic.Boards.Settings.Contracts;
    using Minesweeper.Logic.CommandOperators;
    using Minesweeper.Logic.Scoreboards;

    /// <summary>
    /// Test class for the CommandOperators class
    /// </summary>
    [TestClass]
    public class CommandOperatorTests
    {
        [TestMethod]
        public void TheExecuteMethodShouldExecuteTheCorrectCommandBasedOnTheInput()
        {
            var testOperator = new CommandOperator(
                new Board(new EasyBoardSettings(), new List<IBoardObserver>()),
                new Scoreboard());
            testOperator.Execute("play");
            testOperator.Execute("exit");
            testOperator.Execute("restart");
            testOperator.Execute("invalid");
        }
    }
}