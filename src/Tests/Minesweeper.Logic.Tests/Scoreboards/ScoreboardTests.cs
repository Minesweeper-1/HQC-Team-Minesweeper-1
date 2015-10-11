namespace Minesweeper.Logic.Tests.Scoreboards
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    using Logic.Players;
    using Logic.Players.Contracts;
    using Logic.Scoreboards;
    using Logic.Scoreboards.Contracts;
    using Moq;

    [TestClass]
    public class ScoreboardTests
    {
        [TestMethod]
        public void GetAllShouldReturnListOfLeaders()
        {
            var fakeScoreboard = new Mock<Scoreboard>();
            //fakeScoreboard.Setup(s => s.GetAll()).Returns(new List<IPlayer>());
            
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