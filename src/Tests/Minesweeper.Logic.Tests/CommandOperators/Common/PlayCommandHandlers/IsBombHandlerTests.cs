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
    /// A test class for the IsBombHandler
    /// </summary>
    [TestClass]
    public class IsBombHandlerTests
    {
        [TestMethod]
        public void IsBombHandlerShouldHandleTheRequestIfTheCellIsABomb()
        {
            var testHandler = new IsBombHandler();
            var testBoard = new Board(new EasyBoardSettings(), new List<IBoardObserver>());
            testHandler.SetSuccessor(new IsAlreadyShownHandler());
            testBoard.Cells[0, 0] = new CellContext();
            testBoard.Cells[0, 0].Content = new Bomb();
            testHandler.HandleRequest(row: 0, col: 0, board: testBoard);
            Assert.AreEqual(BoardState.Closed, testBoard.BoardState);
        }

        [TestMethod]
        public void IsBombHandlerShouldPassTheRequestToItsSuccessorIfTheContentIsEmpty()
        {
            var testHandler = new IsBombHandler();
            var testBoard = new Board(new EasyBoardSettings(), new List<IBoardObserver>());
            testHandler.SetSuccessor(new IsAlreadyShownHandler());
            testBoard.Cells[0, 0] = new CellContext();
            testBoard.Cells[0, 0].Content = new EmptyContent();
            testBoard.Cells[0, 0].State = CellState.Revealed;
            testHandler.HandleRequest(row: 0, col: 0, board: testBoard);
            Assert.AreEqual(BoardState.Pending, testBoard.BoardState);
        }
    }
}