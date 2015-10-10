using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper.Logic.Boards;
using Minesweeper.Logic.Boards.Settings.Contracts;
using Moq;
using Minesweeper.Logic.Boards.Contracts;
using System.Collections.Generic;
using Minesweeper.Logic.Common;
using Minesweeper.Logic.Contents;

namespace Minesweeper.Logic.Tests.Boards
{
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
