namespace Minesweeper.Logic.Tests.Contents
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Logic.Contents;
    using Logic.Common;

    /// <summary>
    /// Defines unit tests for the Bomb class in Minesweeper.Logic.Contents
    /// </summary>
    [TestClass]
    public class BombTests
    {
        [TestMethod]
        public void ConstructorSetsCorrectBombProperties()
        {
            var bomb = new Bomb();

            Assert.AreEqual(ContentType.Bomb, bomb.ContentType);
            Assert.AreEqual(-1, bomb.Value);
        }
    }
}
