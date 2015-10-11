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
    using Minesweeper.Logic.DifficultyCommands.Contracts;

    using Moq;

    [TestClass]
    public class BeginnerModeTests
    {
        [TestMethod]
        public void BeginnerModeValueAndSettingsShouldBeSetProperly()
        {
            var testMode = new BeginnerMode();
            var value = testMode.Value;
            var settings = testMode.Settings;
            Assert.AreEqual("Beginner", value);
            Assert.AreEqual(typeof(EasyBoardSettings), settings.GetType());
        }

        [TestMethod]
        public void GetPreviousShouldReturnNewExpertMode()
        {
            var testBeginnerMode = new BeginnerMode();
            var testExpertMode = testBeginnerMode.GetPrevious();
            Assert.AreEqual("Expert", testExpertMode.Value);
        }

        [TestMethod]
        public void GetNextShouldReturnNewIntermediateMode()
        {
            var testBeginnerMode = new BeginnerMode();
            var testIntermediateMode = testBeginnerMode.GetNext();
            Assert.AreEqual("Intermediate", testIntermediateMode.Value);
        }
    }
}