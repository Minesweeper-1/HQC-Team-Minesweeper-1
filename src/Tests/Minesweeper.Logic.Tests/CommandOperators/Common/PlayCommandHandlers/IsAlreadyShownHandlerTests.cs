using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper.Logic.CommandOperators.Common.PlayCommandHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic.CommandOperators.Common.PlayCommandHandlers.Tests
{
    using Minesweeper.Logic.Boards;
    using Minesweeper.Logic.Boards.Contracts;
    using Minesweeper.Logic.Boards.Settings.Contracts;
    using Minesweeper.Logic.Cells;
    using Minesweeper.Logic.Common;

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
            testBoard.Cells[0, 0].State = CellState.Revealed;
            testHandler.SetSuccessor(new IsBombHandler());
            testHandler.HandleRequest(0, 0, testBoard);
        }
    }
}