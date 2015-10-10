namespace Minesweeper.Logic.Tests.Boards
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Logic.Boards;
    using Logic.Boards.Contracts;
    using Logic.Boards.Settings.Contracts;
    using Common;

    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void TestingChangeBoardState()
        {
            var boardSettings = new Mock<BoardSettings>(9, 9, 3);
            Mock<Board> board = new Mock<Board>(boardSettings.Object, new List<IBoardObserver>());
            board.CallBase = true;
            var ta = board.Object;
            var nootif = new Notification("B", BoardState.Open);
            ta.ChangeBoardState(nootif);
            Assert.AreEqual(ta.BoardState, BoardState.Open);

        }

        [TestMethod]
        public void ChangedBoardStateShouldThowEror()
        {
            var boardSettings = new Mock<BoardSettings>(9, 9, 3);
            Mock<Board> board = new Mock<Board>(boardSettings.Object, new List<IBoardObserver>());
            board.CallBase = true;
            var ta = board.Object;
            var nootif = new Notification("B", BoardState.Open);
            ta.ChangeBoardState(nootif);
            try
            {
                Assert.AreEqual(ta.BoardState, BoardState.Closed);
                Assert.Fail();
            }
            catch (Exception)
            {

            }
        }
    }
}
