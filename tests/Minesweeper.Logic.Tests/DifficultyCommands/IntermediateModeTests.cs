// <copyright file="IntermediateModeTests.cs" company="Team Minesweeper-1">
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
    /// Test class for the intermediate mode class
    /// </summary>
    [TestClass]
    public class IntermediateModeTests
    {
        /// <summary>
        /// Tests the proper setting of value and settings
        /// </summary>
        [TestMethod]
        public void IntermediateModeValueAndSettingsShouldBeSetProperly()
        {
            var testMode = new IntermediateMode();
            string value = testMode.Value;
            BoardSettings settings = testMode.Settings;
            Assert.AreEqual(expected: "Intermediate", actual: value);
            Assert.AreEqual(typeof(NormalBoardSettings), settings.GetType());
        }

        /// <summary>
        /// Testing the GetPrevious functionality
        /// </summary>
        [TestMethod]
        public void GetPreviousShouldReturnNewBeginnerMode()
        {
            var testIntermediateMode = new IntermediateMode();
            IGameMode testBeginnerMode = testIntermediateMode.GetPrevious();
            Assert.AreEqual(expected: "Beginner", actual: testBeginnerMode.Value);
        }

        /// <summary>
        /// Testing the GetNext functionality
        /// </summary>
        [TestMethod]
        public void GetNextShouldReturnNewExpertMode()
        {
            var testIntermediateMode = new IntermediateMode();
            IGameMode testExpertMode = testIntermediateMode.GetNext();
            Assert.AreEqual(expected: "Expert", actual: testExpertMode.Value);
        }
    }
}