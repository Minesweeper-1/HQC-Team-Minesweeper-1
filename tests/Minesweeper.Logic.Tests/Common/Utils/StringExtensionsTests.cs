// <copyright file="StringExtensionsTests.cs" company="Team Minesweeper-1">
// Copyright (c) The team. All rights reserved.
// </copyright>
namespace Minesweeper.Logic.Tests.Common.Utils
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper.Logic.Common.Utils;

    /// <summary>
    /// Test class for the StringExtensions class
    /// </summary>
    [TestClass]
    public class StringExtensionsTests
    {
        /// <summary>
        /// Testing the SplitByUpperCase functionality
        /// </summary>
        [TestMethod]
        public void SplitByUpperCaseShouldReturnArrayOfStringsOfTheInitialStringSplitByUpperCaseLetters()
        {
            string[] result = "OneTwo".SplitByUpperCase();
            Assert.AreEqual(expected: "One", actual: result[0], message: "The first element of the array should be the string \"One\"");
            Assert.AreEqual(expected: "Two", actual: result[1], message: "The second element of the array should be the string \"Two\"");
        }
    }
}