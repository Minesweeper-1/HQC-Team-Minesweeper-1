namespace Minesweeper.Logic.Tests.CommandOperators.Common.PlayCommandHandlers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    using Logic.Boards;
    using Logic.Boards.Contracts;
    using Logic.Boards.Settings;
    using Logic.Cells;
    using Logic.Common;
    using Logic.CommandOperators.Common.PlayCommandHandlers;

    [TestClass]
    public class IsAlreadyShownHandlerTests
    {
        [TestMethod]
        public void IsAlreadyShownShouldHandleRevealedAndUnrevealedCellsAccordingly()
        {
            var testHandler = new IsAlreadyShownHandler();
            var testBoard = new Board(new EasyBoardSettings(), new List<IBoardObserver>());
            testBoard.Cells[0, 0] = new CellContext();
            testBoard.Cells[0, 0].State = CellState.Revealed;
            testHandler.HandleRequest(0, 0, testBoard);
            Assert.AreEqual(true, testBoard.IsAlreadyShown(0, 0));
        }

        [TestMethod]
        public void IsAlreadyShownShouldPassTheRequestToItsSuccessorWhenNecessary()
        {
            var testHandler = new IsAlreadyShownHandler();
            var testBoard = new Board(new EasyBoardSettings(), new List<IBoardObserver>());
            testBoard.Cells[0, 0] = new CellContext();
            testBoard.Cells[0, 0].State = CellState.Sealed;
            testHandler.SetSuccessor(new RevealCellHandler());
            testHandler.HandleRequest(0, 0, testBoard);
        }
    }
}