// <copyright file="FileReaderTests.cs" company="Team Minesweeper-1">
// Copyright (c) The team. All rights reserved.
// </copyright>
namespace Minesweeper.Logic.Tests.DataManagers
{
    using Logic.DataManagers;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Test class for the FileReader class
    /// </summary>
    [TestClass]
    public class FileReaderTests
    {
        /// <summary>
        /// Testing the ReadAllText functionality
        /// </summary>
        [TestMethod]
        public void ReadAllTextShouldReadAllOfTheFileContents()
        {
            string source = "../../DataManagers/top-secret.txt";
            string result = "Pesho";
            var reader = new FileReader();
            var writer = new FileWriter();
            writer.WriteAllText(source, result);

            Assert.AreEqual(result, reader.ReadAllText(source));
        }
    }
}
