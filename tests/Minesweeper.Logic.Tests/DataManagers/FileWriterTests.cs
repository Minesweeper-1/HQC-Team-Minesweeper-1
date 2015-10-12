// <copyright file="FileWriterTests.cs" company="Team Minesweeper-1">
// Copyright (c) The team. All rights reserved.
// </copyright>
namespace Minesweeper.Logic.Tests.DataManagers
{
    using Logic.DataManagers;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Test class for the file writer class
    /// </summary>
    [TestClass]
    public class FileWriterTests
    {
        /// <summary>
        /// Testing WriteAllText functionality
        /// </summary>
        [TestMethod]
        public void WriteAllTextShouldWriteAllTextToTheFile()
        {
            string path = "../../DataManagers/answer-to-the-universe.txt";
            string text = "42";
            var reader = new FileReader();
            var writer = new FileWriter();

            writer.WriteAllText(path, text);
            Assert.AreEqual(text, reader.ReadAllText(path));
        }
    }
}
