namespace Minesweeper.Logic.Tests.Boards.Settings
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Logic.Boards.Settings;

    [TestClass]
    public class BoardSettingsTests
    {
        [TestMethod]
        public void EasyBoardSettingsConstructorShouldSetExpectedBoardParameterValues()
        {
            var settings = new EasyBoardSettings();

            Assert.AreEqual(expected: 9, actual: settings.Rows);
            Assert.AreEqual(expected: 9, actual: settings.Cols);
            Assert.AreEqual(expected: 10, actual: settings.NumberOfBombs);
        }

        [TestMethod]
        public void NormalBoardSettingsConstructorShouldSetExpectedBoardParameterValues()
        {
            var settings = new NormalBoardSettings();

            Assert.AreEqual(expected: 16, actual: settings.Rows);
            Assert.AreEqual(expected: 16, actual: settings.Cols);
            Assert.AreEqual(expected: 40, actual: settings.NumberOfBombs);
        }

        [TestMethod]
        public void HardBoardSettingsConstructorShouldSetExpectedBoardParameterValues()
        {
            var settings = new HardBoardSettings();

            Assert.AreEqual(expected: 20, actual: settings.Rows);
            Assert.AreEqual(expected: 24, actual: settings.Cols);
            Assert.AreEqual(expected: 99, actual: settings.NumberOfBombs);
        }
    }
}