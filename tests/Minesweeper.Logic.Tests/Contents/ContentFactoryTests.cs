// <copyright file="ContentFactoryTests.cs" company="Team Minesweeper-1">
// Copyright (c) The team. All rights reserved.
// </copyright>
namespace Minesweeper.Logic.Tests.Contents
{
    using Logic.Contents;
    using Logic.Contents.Contracts;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Defines unit tests for the ContentFactory class in Minesweeper.Logic.Contents
    /// </summary>
    [TestClass]
    public class ContentFactoryTests
    {
        /// <summary>
        /// Testing the default functionality of the Factory
        /// </summary>
        [TestMethod]
        public void GetContentWithNoParametersReturnsDefaultContent()
        {
            var factory = new ContentFactory();

            IContent content = factory.GetContent();

            Assert.AreEqual(!default(bool), content is EmptyContent);
        }
    }
}
