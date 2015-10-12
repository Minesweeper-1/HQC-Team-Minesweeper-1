// <copyright file="BoardSettingsTests.cs" company="Team Minesweeper-1">
// Copyright (c) The team. All rights reserved.
// </copyright>
namespace Minesweeper.Logic.Tests.Boards.Settings
{
    using Logic.Boards.Settings;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Class containing BoardSettings tests
    /// </summary>
    [TestClass]
    public class BoardSettingsTests
    {
        /// <summary>
        /// The settings should set the appropriate board parameters
        /// </summary>
        [TestMethod]
        public void EasyBoardSettingsConstructorShouldSetExpectedBoardParameterValues()
        {
            var settings = new EasyBoardSettings();

            Assert.AreEqual(expected: 9, actual: settings.Rows);
            Assert.AreEqual(expected: 9, actual: settings.Cols);
            Assert.AreEqual(expected: 10, actual: settings.NumberOfBombs);
        }

        /// <summary>
        /// The settings should set the appropriate board parameters
        /// </summary>
        [TestMethod]
        public void NormalBoardSettingsConstructorShouldSetExpectedBoardParameterValues()
        {
            var settings = new NormalBoardSettings();

            Assert.AreEqual(expected: 16, actual: settings.Rows);
            Assert.AreEqual(expected: 16, actual: settings.Cols);
            Assert.AreEqual(expected: 40, actual: settings.NumberOfBombs);
        }

        /// <summary>
        /// The settings should set the appropriate board parameters
        /// </summary>
        [TestMethod]
        public void HardBoardSettingsConstructorShouldSetExpectedBoardParameterValues()
        {
            var settings = new HardBoardSettings();

            Assert.AreEqual(expected: 20, actual: settings.Rows);
            Assert.AreEqual(expected: 24, actual: settings.Cols);
            Assert.AreEqual(expected: 99, actual: settings.NumberOfBombs);
        }
    }
}