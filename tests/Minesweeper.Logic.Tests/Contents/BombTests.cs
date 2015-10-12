// <copyright file="BombTests.cs" company="Team Minesweeper-1">
// Copyright (c) The team. All rights reserved.
// </copyright>
namespace Minesweeper.Logic.Tests.Contents
{
    using Logic.Common;
    using Logic.Contents;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Defines unit tests for the Bomb class in Minesweeper.Logic.Contents
    /// </summary>
    [TestClass]
    public class BombTests
    {
        /// <summary>
        /// Testing bomb creation
        /// </summary>
        [TestMethod]
        public void ConstructorSetsCorrectBombProperties()
        {
            var bomb = new Bomb();

            Assert.AreEqual(ContentType.Bomb, bomb.ContentType);
            Assert.AreEqual(-1, bomb.Value);
        }
    }
}
