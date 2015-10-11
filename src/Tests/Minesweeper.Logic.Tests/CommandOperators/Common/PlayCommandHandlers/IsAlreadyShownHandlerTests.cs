namespace Minesweeper.Logic.Tests.CommandOperators.Common.PlayCommandHandlers
{
    using System.Collections.Generic;
    
    using Logic.Boards;
    using Logic.Boards.Contracts;
    using Logic.Boards.Settings;
    using Logic.Cells;
    using Logic.CommandOperators.Common.PlayCommandHandlers;
    using Logic.Common;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            testHandler.HandleRequest(row: 0, col: 0, board: testBoard);
            Assert.AreEqual(expected: true, actual: testBoard.IsAlreadyShown(cellRow: 0, cellCol: 0));
        }

        [TestMethod]
        public void IsAlreadyShownShouldPassTheRequestToItsSuccessorWhenNecessary()
        {
            var testHandler = new IsAlreadyShownHandler();
            var testBoard = new Board(new EasyBoardSettings(), new List<IBoardObserver>());
            testBoard.Cells[0, 0] = new CellContext();
            testBoard.Cells[0, 0].State = CellState.Sealed;
            testHandler.SetSuccessor(new RevealCellHandler());
            testHandler.HandleRequest(row: 0, col: 0, board: testBoard);
        }
    }
}