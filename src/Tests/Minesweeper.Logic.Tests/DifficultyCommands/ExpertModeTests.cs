using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper.Logic.DifficultyCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic.DifficultyCommands.Tests
{
    using Minesweeper.Logic.Boards.Settings.Contracts;

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