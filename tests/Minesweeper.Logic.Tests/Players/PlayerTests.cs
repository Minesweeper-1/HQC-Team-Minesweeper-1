// <copyright file="PlayerTests.cs" company="Team Minesweeper-1">
// Copyright (c) The team. All rights reserved.
// </copyright>
namespace Minesweeper.Logic.Tests.Players
{
    using Logic.Players;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Defines unit tests for the Player class in Minesweeper.Logic.Players
    /// </summary>
    [TestClass]
    public class PlayerTests
    {
        /// <summary>
        /// Testing empty constructor
        /// </summary>
        [TestMethod]
        public void EmptyConstructorSetsDefaultPropertyValues()
        {
            var player = new Player();

            Assert.AreEqual(string.Empty, player.Name);
            Assert.AreEqual(default(int), player.Score);
        }

        /// <summary>
        /// Testing constructor with given name
        /// </summary>
        [TestMethod]
        public void ConstructorWithNameSetsNameAndDefaultScore()
        {
            string name = "John";
            var player = new Player(name);

            Assert.AreEqual(name, player.Name);
            Assert.AreEqual(default(int), player.Score);
        }
    }
}
