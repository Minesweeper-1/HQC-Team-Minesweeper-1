// <copyright file="EmptyContentTests.cs" company="Team Minesweeper-1">
// Copyright (c) The team. All rights reserved.
// </copyright>
namespace Minesweeper.Logic.Tests.Contents
{
    using Logic.Common;
    using Logic.Contents;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Defines unit tests for the EmptyContent class in Minesweeper.Logic.Contents
    /// </summary>
    [TestClass]
    public class EmptyContentTests
    {
        /// <summary>
        /// Testing empty content creation
        /// </summary>
        [TestMethod]
        public void ConstructorSetsCorrectEmptyContentProperties()
        {
            var empty = new EmptyContent();

            Assert.AreEqual(ContentType.Empty, empty.ContentType);
            Assert.AreEqual(default(int), empty.Value);
        }
    }
}
