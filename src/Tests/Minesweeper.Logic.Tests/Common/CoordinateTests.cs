namespace Minesweeper.Logic.Tests.Common
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Logic.Common;

    /// <summary>
    /// Test class for the Coordinate class
    /// </summary>
    [TestClass]
    public class CoordinateTests
    {
        [TestMethod]
        public void CoordinatesWithEqualValuesForRowAndCallShouldBeEqual()
        {
            var firstCoordinate = new Coordinate(2, 2);
            var secondCoordinate = new Coordinate(2, 2);
            Assert.AreEqual(firstCoordinate, secondCoordinate);
        }

        [TestMethod]
        public void CoordinatesWithDifferentValuesForRowOrCallShouldNotBeEqual()
        {
            var firstCoordinate = new Coordinate(2, 2);
            var secondCoordinate = new Coordinate(2, 1);
            Assert.AreNotEqual(firstCoordinate, secondCoordinate);
        }
    }
}