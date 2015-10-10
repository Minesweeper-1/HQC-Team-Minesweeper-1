namespace Minesweeper.Logic.Tests.Boards
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper.Logic.Boards.Settings.Contracts;
    using Moq;

    [TestClass]
    public class BoardSettingsTests
    {
        [TestMethod]
        public void BoardSettingsConstructor()
        {
            var mock = new Mock<BoardSettings>(9, 9, 3);
            Assert.AreEqual(mock.Object.Rows, 9);
            Assert.AreEqual(mock.Object.Cols, 9);
            Assert.AreEqual(mock.Object.NumberOfBombs, 3);
        }
    }
}