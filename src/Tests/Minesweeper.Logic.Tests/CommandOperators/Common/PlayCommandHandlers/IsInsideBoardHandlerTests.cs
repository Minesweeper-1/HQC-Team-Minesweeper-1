namespace Minesweeper.Logic.Tests.CommandOperators.Common.PlayCommandHandlers
{
    using System.Collections.Generic;
    
    using Logic.Boards;
    using Logic.Boards.Contracts;
    using Logic.Boards.Settings;
    using Logic.Cells;
    using Logic.CommandOperators.Common.PlayCommandHandlers;
    using Logic.Common;
    using Logic.Contents;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
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
            testHandler.HandleRequest(row: 0, col: 0, board: testBoard);
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