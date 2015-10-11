namespace Minesweeper.Logic.Tests.DifficultyCommands
{
    using Logic.Boards.Settings;
    using Logic.Boards.Settings.Contracts;
    using Logic.DifficultyCommands;
    using Logic.DifficultyCommands.Contracts;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ExpertModeTests
    {
        [TestMethod]
        public void ExpertModeValueAndSettingsShouldBeSetProperly()
        {
            var testMode = new ExpertMode();
            string value = testMode.Value;
            BoardSettings settings = testMode.Settings;
            Assert.AreEqual(expected: "Expert", actual: value);
            Assert.AreEqual(typeof(HardBoardSettings), settings.GetType());
        }

        [TestMethod]
        public void GetPreviousShouldReturnNewIntermediateMode()
        {
            var testExpertMode = new ExpertMode();
            IGameMode testIntermediateMode = testExpertMode.GetPrevious();
            Assert.AreEqual(expected: "Intermediate", actual: testIntermediateMode.Value);
        }

        [TestMethod]
        public void GetNextShouldReturnNewBeginnerMode()
        {
            var testExpertMode = new ExpertMode();
            IGameMode testBeginnerMode = testExpertMode.GetNext();
            Assert.AreEqual(expected: "Beginner", actual: testBeginnerMode.Value);
        }
    }
}