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
        [TestMethod]
        public void SplitByUpperCaseShouldReturnArrayOfStringsOfTheInitialStringSplitByUpperCaseLetters()
        {
            var result = "OneTwo".SplitByUpperCase();
            Assert.AreEqual("One", result[0], "The first element of the array should be the string \"One\"");
            Assert.AreEqual("Two", result[1], "The second element of the array should be the string \"Two\"");
        }
    }
}