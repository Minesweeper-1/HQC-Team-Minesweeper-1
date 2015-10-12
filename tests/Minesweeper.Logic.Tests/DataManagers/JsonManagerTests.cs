// <copyright file="JsonManagerTests.cs" company="Team Minesweeper-1">
// Copyright (c) The team. All rights reserved.
// </copyright>
namespace Minesweeper.Logic.Tests.DataManagers
{
    using Logic.DataManagers;
    using Logic.Players;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Test class for this class
    /// </summary>
    [TestClass]
    public class JsonManagerTests
    {
        /// <summary>
        /// Testing Parse functionality
        /// </summary>
        [TestMethod]
        public void ParseShouldGenerateSpecifiedObject()
        {
            string playerJson = "{\"Name\":\"Mara\",\"Score\":1024}";
            var jsonManager = new JsonManager();

            Player mara = jsonManager.Parse<Player>(playerJson);

            Assert.AreEqual(expected: "Mara", actual: mara.Name);
            Assert.AreEqual(expected: 1024, actual: mara.Score);
        }

        /// <summary>
        /// Testing to string functionality
        /// </summary>
        [TestMethod]
        public void ToStringRepresentationShouldGenerateCorrectJsonString()
        {
            string playerJson = "{\"Name\":\"Mara\",\"Score\":1024}";
            var jsonManager = new JsonManager();
            var mara = new Player()
            {
                Name = "Mara",
                Score = 1024
            };

            string stringMara = jsonManager.ToStringRepresentation(mara);

            Assert.AreEqual(playerJson, stringMara);
        }
    }
}
