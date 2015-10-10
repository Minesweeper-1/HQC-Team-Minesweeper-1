namespace Minesweeper.Logic.CommandOperators.Common.PlayCommandHandlers.Tests
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Minesweeper.Logic.Boards;
    using Minesweeper.Logic.Boards.Contracts;
    using Minesweeper.Logic.Boards.Settings.Contracts;
    using Minesweeper.Logic.CommandOperators.Common.PlayCommandHandlers;

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
            testHandler.HandleRequest("a a", new Board(new EasyBoardSettings(), new List<IBoardObserver>()));
            Assert.AreEqual(true, testHandler.IsInvalid);
        }
    }
}