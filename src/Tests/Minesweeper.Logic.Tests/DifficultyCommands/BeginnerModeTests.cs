namespace Minesweeper.Logic.Tests.DifficultyCommands
{
    using Logic.Boards.Settings;
    using Logic.Boards.Settings.Contracts;
    using Logic.DifficultyCommands;
    using Logic.DifficultyCommands.Contracts;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BeginnerModeTests
    {
        [TestMethod]
        public void BeginnerModeValueAndSettingsShouldBeSetProperly()
        {
            var testMode = new BeginnerMode();
            string value = testMode.Value;
            BoardSettings settings = testMode.Settings;
            Assert.AreEqual(expected: "Beginner", actual: value);
            Assert.AreEqual(typeof(EasyBoardSettings), settings.GetType());
        }

        [TestMethod]
        public void GetPreviousShouldReturnNewExpertMode()
        {
            var testBeginnerMode = new BeginnerMode();
            IGameMode testExpertMode = testBeginnerMode.GetPrevious();
            Assert.AreEqual(expected: "Expert", actual: testExpertMode.Value);
        }

        [TestMethod]
        public void GetNextShouldReturnNewIntermediateMode()
        {
            var testBeginnerMode = new BeginnerMode();
            IGameMode testIntermediateMode = testBeginnerMode.GetNext();
            Assert.AreEqual(expected: "Intermediate", actual: testIntermediateMode.Value);
        }
    }
}