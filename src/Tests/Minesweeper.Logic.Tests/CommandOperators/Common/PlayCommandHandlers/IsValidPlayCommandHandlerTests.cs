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

    [TestClass]
    public class IsValidPlayCommandHandlerTests
    {
        [TestMethod]
        public void IsValidHandleRequestShouldRecogniseAValidCommand()
        {
            var testHandler = new IsValidPlayCommandHandler();
            testHandler.HandleRequest(command: "1 1", board: new Board(new EasyBoardSettings(), new List<IBoardObserver>()));
            Assert.AreEqual(expected: false, actual: testHandler.IsInvalid);
        }

        [TestMethod]
        public void IsValidHandleRequestShouldRecogniseAnInvalidCommand()
        {
            var testHandler = new IsValidPlayCommandHandler();
            var testBoard = new Board(new EasyBoardSettings(), new List<IBoardObserver>());
            testHandler.HandleRequest(command: "a a", board: testBoard);
            Assert.AreEqual(expected: true, actual: testHandler.IsInvalid);
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
            testHandler.HandleRequest(command: "0 0", board: testBoard);
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
            testHandler.HandleRequest(command: "0 0", board: testBoard);
        }
    }
}