namespace Minesweeper.Logic.CommandOperators.Common.PlayCommandHandlers.Tests
{
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
            testHandler.HandleRequest(0, 0, testBoard);
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
            testHandler.HandleRequest(0, 0, testBoard);
            Assert.AreEqual(BoardState.Pending, testBoard.BoardState);
        }
    }
}