namespace Minesweeper.Logic.Tests.DifficultyCommands
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Logic.Boards.Settings;
    using Logic.DifficultyCommands;

    [TestClass]
    public class IntermediateModeTests
    {
        [TestMethod]
        public void IntermediateModeValueAndSettingsShouldBeSetProperly()
        {
            var testMode = new IntermediateMode();
            var value = testMode.Value;
            var settings = testMode.Settings;
            Assert.AreEqual("Intermediate", value);
            Assert.AreEqual(typeof(NormalBoardSettings), settings.GetType());
        }

        [TestMethod]
        public void GetPreviousShouldReturnNewBeginnerMode()
        {
            var testIntermediateMode = new IntermediateMode();
            var testBeginnerMode = testIntermediateMode.GetPrevious();
            Assert.AreEqual("Beginner", testBeginnerMode.Value);
        }

        [TestMethod]
        public void GetNextShouldReturnNewExpertMode()
        {
            var testIntermediateMode = new IntermediateMode();
            var testExpertMode = testIntermediateMode.GetNext();
            Assert.AreEqual("Expert", testExpertMode.Value);
        }
    }
}