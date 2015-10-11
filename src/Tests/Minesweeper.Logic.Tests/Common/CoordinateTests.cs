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
        [TestMethod]
        public void CoordinatesWithEqualValuesForRowAndCallShouldBeEqual()
        {
            var firstCoordinate = new Coordinate(row: 2, col: 2);
            var secondCoordinate = new Coordinate(row: 2, col: 2);
            Assert.AreEqual(firstCoordinate, secondCoordinate);
        }

        [TestMethod]
        public void CoordinatesWithDifferentValuesForRowOrCallShouldNotBeEqual()
        {
            var firstCoordinate = new Coordinate(row: 2, col: 2);
            var secondCoordinate = new Coordinate(row: 2, col: 1);
            Assert.AreNotEqual(firstCoordinate, secondCoordinate);
        }
    }
}