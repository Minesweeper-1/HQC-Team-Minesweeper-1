// <copyright file="BeginnerModeTests.cs" company="Team Minesweeper-1">
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
    /// A test class for the BeginnerMode class
    /// </summary>
    [TestClass]
    public class BeginnerModeTests
    {
        /// <summary>
        /// Testing BeginnerMode value and settings creation
        /// </summary>
        [TestMethod]
        public void BeginnerModeValueAndSettingsShouldBeSetProperly()
        {
            var testMode = new BeginnerMode();
            string value = testMode.Value;
            BoardSettings settings = testMode.Settings;
            Assert.AreEqual(expected: "Beginner", actual: value);
            Assert.AreEqual(typeof(EasyBoardSettings), settings.GetType());
        }

        /// <summary>
        /// Testing the GetPrevious functionality
        /// </summary>
        [TestMethod]
        public void GetPreviousShouldReturnNewExpertMode()
        {
            var testBeginnerMode = new BeginnerMode();
            IGameMode testExpertMode = testBeginnerMode.GetPrevious();
            Assert.AreEqual(expected: "Expert", actual: testExpertMode.Value);
        }

        /// <summary>
        /// Testing the GetNext functionality
        /// </summary>
        [TestMethod]
        public void GetNextShouldReturnNewIntermediateMode()
        {
            var testBeginnerMode = new BeginnerMode();
            IGameMode testIntermediateMode = testBeginnerMode.GetNext();
            Assert.AreEqual(expected: "Intermediate", actual: testIntermediateMode.Value);
        }
    }
}