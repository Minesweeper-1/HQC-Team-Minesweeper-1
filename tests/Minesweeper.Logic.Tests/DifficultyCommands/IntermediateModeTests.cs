namespace Minesweeper.Logic.Tests.DifficultyCommands
{
    using Logic.Boards.Settings;
    using Logic.Boards.Settings.Contracts;
    using Logic.DifficultyCommands;
    using Logic.DifficultyCommands.Contracts;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IntermediateModeTests
    {
        [TestMethod]
        public void IntermediateModeValueAndSettingsShouldBeSetProperly()
        {
            var testMode = new IntermediateMode();
            string value = testMode.Value;
            BoardSettings settings = testMode.Settings;
            Assert.AreEqual(expected: "Intermediate", actual: value);
            Assert.AreEqual(typeof(NormalBoardSettings), settings.GetType());
        }

        [TestMethod]
        public void GetPreviousShouldReturnNewBeginnerMode()
        {
            var testIntermediateMode = new IntermediateMode();
            IGameMode testBeginnerMode = testIntermediateMode.GetPrevious();
            Assert.AreEqual(expected: "Beginner", actual: testBeginnerMode.Value);
        }

        [TestMethod]
        public void GetNextShouldReturnNewExpertMode()
        {
            var testIntermediateMode = new IntermediateMode();
            IGameMode testExpertMode = testIntermediateMode.GetNext();
            Assert.AreEqual(expected: "Expert", actual: testExpertMode.Value);
        }
    }
}