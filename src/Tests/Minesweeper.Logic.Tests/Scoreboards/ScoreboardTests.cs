namespace Minesweeper.Logic.Scoreboards.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Minesweeper.Logic.Players;
    using Minesweeper.Logic.Players.Contracts;
    using Minesweeper.Logic.Scoreboards;
    using Minesweeper.Logic.Scoreboards.Contracts;

    using Moq;

    [TestClass]
    public class ScoreboardTests
    {
        [TestMethod]
        public void GetAllShouldReturnListOfLeaders()
        {
            var mockBoard = new Mock<IScoreboard>();
            mockBoard.Setup(x => x.GetAll()).Returns(new List<IPlayer> { new Player("Gosho"), new Player("Pesho") });
            mockBoard.Object.GetAll();
            mockBoard.Verify(x => x.GetAll());
            Assert.AreEqual(2, mockBoard.Object.GetAll().Count);
        }

        [TestMethod]
        public void RegisterNewPlayerShouldAddPlayersToTheList()
        {
            var mockBoard = new Mock<IScoreboard>();
            var testPlayer = new Player("Ivan");
            mockBoard.Setup(x => x.RegisterNewPlayerScore(testPlayer)).Verifiable();
            mockBoard.Object.RegisterNewPlayerScore(testPlayer);
            mockBoard.Verify();
            mockBoard.Setup(x => x.GetAll()).Returns(new List<IPlayer> { testPlayer });
            Assert.AreEqual("Ivan", mockBoard.Object.GetAll()[0].Name);
        }
    }
}