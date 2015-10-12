// <copyright file="CoordinateTests.cs" company="Team Minesweeper-1">
// Copyright (c) The team. All rights reserved.
// </copyright>
namespace Minesweeper.Logic.Tests.Common
{
    using Logic.Common;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Test class for the Coordinate class
    /// </summary>
    [TestClass]
    public class CoordinateTests
    {
        /// <summary>
        /// Testing cells equality comparison with equal cells
        /// </summary>
        [TestMethod]
        public void CoordinatesWithEqualValuesForRowAndCallShouldBeEqual()
        {
            var firstCoordinate = new Coordinate(row: 2, col: 2);
            var secondCoordinate = new Coordinate(row: 2, col: 2);
            Assert.AreEqual(firstCoordinate, secondCoordinate);
        }

        /// <summary>
        /// Testing cells equality comparison with different cells
        /// </summary>
        [TestMethod]
        public void CoordinatesWithDifferentValuesForRowOrCallShouldNotBeEqual()
        {
            var firstCoordinate = new Coordinate(row: 2, col: 2);
            var secondCoordinate = new Coordinate(row: 2, col: 1);
            Assert.AreNotEqual(firstCoordinate, secondCoordinate);
        }
    }
}