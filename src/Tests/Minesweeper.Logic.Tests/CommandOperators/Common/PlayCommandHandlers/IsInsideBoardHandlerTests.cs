namespace Minesweeper.Logic.CommandOperators.Common.PlayCommandHandlers.Tests
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Minesweeper.Logic.Boards;
    using Minesweeper.Logic.Boards.Contracts;
    using Minesweeper.Logic.Boards.Settings.Contracts;
    using Minesweeper.Logic.Cells;
    using Minesweeper.Logic.CommandOperators.Common.PlayCommandHandlers;
    using Minesweeper.Logic.Common;
    using Minesweeper.Logic.Contents;

    /// <summary>
    /// Class thesting the IsInsideBoardHandler
    /// </summary>
    [TestClass]
    public class IsInsideBoardHandlerTests
    {
        [TestMethod]
        public void IsInsideBoardSetsItsAndCallsItSuccessorCorrectly()
        {
            var testHandler = new IsInsideBoardHandler();
            testHandler.SetSuccessor(new IsBombHandler());
            var testBoard = new Board(new EasyBoardSettings(), new List<IBoardObserver>());
            testBoard.Cells[0, 0] = new CellContext();
            testBoard.Cells[0, 0].Content = new Bomb();
            testBoard.Cells[0, 0].Content.Value = 0;
            testHandler.HandleRequest(0, 0, testBoard);
            Assert.AreEqual(BoardState.Closed, testBoard.BoardState);
        }

        [TestMethod]
        public void IsInsideBoardHandlerShouldHandleTheRequestIfCoordinatesOutsideBoardArePassed()
        {
            var testHandler = new IsInsideBoardHandler();
            var testBoard = new Board(new EasyBoardSettings(), new List<IBoardObserver>());
            testHandler.HandleRequest(-1, -1, testBoard);
            Assert.AreEqual(BoardState.Pending, testBoard.BoardState);
        }
    }
}