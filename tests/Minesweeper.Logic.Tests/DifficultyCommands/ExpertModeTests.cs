// <copyright file="ExpertModeTests.cs" company="Team Minesweeper-1">
// Copyright (c) The team. All rights reserved.
// </copyright>
namespace Minesweeper.Logic.Tests.DifficultyCommands
{
    using Logic.Boards.Settings;
    using Logic.Boards.Settings.Contracts;
    using Logic.DifficultyCommands;
    using Logic.DifficultyCommands.Contracts;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Test class for the ExpertMode class
    /// </summary>
    [TestClass]
    public class ExpertModeTests
    {
        /// <summary>
        /// Testing ExpertMode value and settings creation
        /// </summary>
        [TestMethod]
        public void ExpertModeValueAndSettingsShouldBeSetProperly()
        {
            var testMode = new ExpertMode();
            string value = testMode.Value;
            BoardSettings settings = testMode.Settings;
            Assert.AreEqual(expected: "Expert", actual: value);
            Assert.AreEqual(typeof(HardBoardSettings), settings.GetType());
        }

        /// <summary>
        /// Testing GetPrevious functionality
        /// </summary>
        [TestMethod]
        public void GetPreviousShouldReturnNewIntermediateMode()
        {
            var testExpertMode = new ExpertMode();
            IGameMode testIntermediateMode = testExpertMode.GetPrevious();
            Assert.AreEqual(expected: "Intermediate", actual: testIntermediateMode.Value);
        }

        /// <summary>
        /// Testing GetNext functionality
        /// </summary>
        [TestMethod]
        public void GetNextShouldReturnNewBeginnerMode()
        {
            var testExpertMode = new ExpertMode();
            IGameMode testBeginnerMode = testExpertMode.GetNext();
            Assert.AreEqual(expected: "Beginner", actual: testBeginnerMode.Value);
        }
    }
}