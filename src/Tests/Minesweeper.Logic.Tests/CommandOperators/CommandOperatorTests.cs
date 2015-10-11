namespace Minesweeper.Logic.Tests.CommandOperators
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Logic.Boards;
    using Logic.Boards.Contracts;
    using Logic.Boards.Settings;
    using Logic.CommandOperators;
    using Logic.Scoreboards;

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