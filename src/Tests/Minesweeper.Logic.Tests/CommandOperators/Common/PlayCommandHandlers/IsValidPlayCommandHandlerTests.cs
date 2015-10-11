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

    [TestClass]
    public class IsValidPlayCommandHandlerTests
    {
        [TestMethod]
        public void IsValidHandleRequestShouldRecogniseAValidCommand()
        {
            var testHandler = new IsValidPlayCommandHandler();
            testHandler.HandleRequest("1 1", new Board(new EasyBoardSettings(), new List<IBoardObserver>()));
            Assert.AreEqual(false, testHandler.IsInvalid);
        }

        [TestMethod]
        public void IsValidHandleRequestShouldRecogniseAnInvalidCommand()
        {
            var testHandler = new IsValidPlayCommandHandler();
            var testBoard = new Board(new EasyBoardSettings(), new List<IBoardObserver>());
            testHandler.HandleRequest("a a", testBoard);
            Assert.AreEqual(true, testHandler.IsInvalid);
            Assert.AreEqual(BoardState.Pending, testBoard.BoardState);
        }

        [TestMethod]
        public void IsValidPlayShouldHandleTheRequestIfTheCellIsValid()
        {
            var testHandler = new IsValidPlayCommandHandler();
            var testBoard = new Board(new EasyBoardSettings(), new List<IBoardObserver>());
            testHandler.SetSuccessor(new IsInsideBoardHandler());
            testBoard.Cells[0, 0] = new CellContext();
            testBoard.Cells[0, 0].Content = new EmptyContent();
            testBoard.Cells[0, 0].Content.Value = 0;
            testBoard.Cells[0, 0].State = CellState.Sealed;
            testBoard.Cells[0, 1] = new CellContext();
            testBoard.Cells[0, 1].Content = new EmptyContent();
            testBoard.Cells[0, 1].Content.Value = 1;
            testBoard.Cells[0, 1].State = CellState.Sealed;
            testBoard.Cells[1, 0] = new CellContext();
            testBoard.Cells[1, 0].Content = new EmptyContent();
            testBoard.Cells[1, 0].Content.Value = 1;
            testBoard.Cells[1, 0].State = CellState.Sealed;
            testBoard.Cells[1, 1] = new CellContext();
            testBoard.Cells[1, 1].Content = new EmptyContent();
            testBoard.Cells[1, 1].Content.Value = 2;
            testBoard.Cells[1, 1].State = CellState.Sealed;
            testHandler.HandleRequest("0 0", testBoard);
        }

        [TestMethod]
        public void IsValidPlayCommandShouldCallItsSuccessorWhenNeeded()
        {
            var testHandler = new IsValidPlayCommandHandler();
            var testBoard = new Board(new EasyBoardSettings(), new List<IBoardObserver>());
            testHandler.SetSuccessor(new IsInsideBoardHandler());
            testBoard.Cells[0, 0] = new CellContext();
            testBoard.Cells[0, 0].Content = new EmptyContent();
            testBoard.Cells[0, 0].Content.Value = 1;
            testHandler.HandleRequest("0 0", testBoard);
        }
    }
}