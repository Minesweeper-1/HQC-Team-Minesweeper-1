namespace Minesweeper.Logic.Tests.DifficultyCommands
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Logic.Boards.Settings;
    using Logic.DifficultyCommands;

    [TestClass]
    public class ExpertModeTests
    {
        [TestMethod]
        public void ExpertModeValueAndSettingsShouldBeSetProperly()
        {
            var testMode = new ExpertMode();
            var value = testMode.Value;
            var settings = testMode.Settings;
            Assert.AreEqual("Expert", value);
            Assert.AreEqual(typeof(HardBoardSettings), settings.GetType());
        }

        [TestMethod]
        public void GetPreviousShouldReturnNewIntermediateMode()
        {
            var testExpertMode = new ExpertMode();
            var testIntermediateMode = testExpertMode.GetPrevious();
            Assert.AreEqual("Intermediate", testIntermediateMode.Value);
        }

        [TestMethod]
        public void GetNextShouldReturnNewBeginnerMode()
        {
            var testExpertMode = new ExpertMode();
            var testBeginnerMode = testExpertMode.GetNext();
            Assert.AreEqual("Beginner", testBeginnerMode.Value);
        }
    }
}