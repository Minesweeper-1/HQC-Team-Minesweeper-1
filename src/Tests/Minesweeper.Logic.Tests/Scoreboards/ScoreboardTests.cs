namespace Minesweeper.Logic.Tests.Scoreboards
{
    using System.Collections.Generic;

    using Logic.Players;
    using Logic.Players.Contracts;
    using Logic.Scoreboards;
    using Logic.Scoreboards.Contracts;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class ScoreboardTests
    {
        [TestMethod]
        public void GetAllShouldReturnListOfLeaders()
        {
            var mockBoard = new Mock<IScoreboard>();
            mockBoard.Setup(x => x.GetAll()).Returns(new List<IPlayer>
            {
                new Player(name: "Gosho"),
                new Player(name: "Pesho")
            });

            mockBoard.Object.GetAll();
            mockBoard.Verify(x => x.GetAll());
            Assert.AreEqual(expected: 2, actual: mockBoard.Object.GetAll().Count);
        }

        [TestMethod]
        public void RegisterNewPlayerShouldAddPlayersToTheList()
        {
            var mockBoard = new Mock<IScoreboard>();
            var testPlayer = new Player(name: "Ivan");
            mockBoard.Setup(x => x.RegisterNewPlayerScore(testPlayer)).Verifiable();
            mockBoard.Object.RegisterNewPlayerScore(testPlayer);
            mockBoard.Verify();
            mockBoard.Setup(x => x.GetAll()).Returns(new List<IPlayer> { testPlayer });
            Assert.AreEqual(expected: "Ivan", actual: mockBoard.Object.GetAll()[0].Name);
        }
    }
}