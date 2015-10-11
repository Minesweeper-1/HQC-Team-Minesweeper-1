namespace Minesweeper.Logic.Tests.Players
{
    using Logic.Players;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Defines unit tests for the Player class in Minesweeper.Logic.Players
    /// </summary>
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void EmptyConstructorSetsDefaultPropertyValues()
        {
            var player = new Player();

            Assert.AreEqual(string.Empty, player.Name);
            Assert.AreEqual(default(int), player.Score);
        }

        [TestMethod]
        public void ConstructorWithNameSetsNameAndDefaultScore()
        {
            string name = "John";
            var player = new Player(name);

            Assert.AreEqual(name, player.Name);
            Assert.AreEqual(default(int), player.Score);
        }
    }
}
