// <copyright file="CellTests.cs" company="Team Minesweeper-1">
// Copyright (c) The team. All rights reserved.
// </copyright>
namespace Minesweeper.Logic.Tests.Cells
{
    using Logic.Cells;
    using Logic.Cells.Contracts;
    using Logic.Common;
    using Logic.Contents;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Defines unit tests for the Cell class in Minesweeper.Logic.Cells
    /// </summary>
    [TestClass]
    public class CellTests
    {
        /// <summary>
        /// Method testing the GetContext functionality
        /// </summary>
        [TestMethod]
        public void GetContextReturnsObjectOfTypeCellContext()
        {
            var cell = new Cell();

            Assert.AreEqual(!default(bool), cell.GetContext() is CellContext);
        }

        /// <summary>
        /// Method testing whether the constructor creates default context
        /// </summary>
        [TestMethod]
        public void CellConstructorCreatesContextWithDefaultPropertyValues()
        {
            var cell = new Cell();
            ICell context = cell.GetContext();

            Assert.AreEqual(default(object), context.Content);
            Assert.AreEqual((CellState)default(int), context.State);
        }

        /// <summary>
        /// Method testing the SetState functionality
        /// </summary>
        [TestMethod]
        public void SetStateAssignsSpecifiedStateToContext()
        {
            var cell = new Cell();

            cell.SetState(CellState.Revealed);
            ICell context = cell.GetContext();

            Assert.AreEqual(default(object), context.Content);
            Assert.AreEqual(CellState.Revealed, context.State);
        }

        /// <summary>
        /// Method testing the SetContent functionality
        /// </summary>
        [TestMethod]
        public void SetContentAssignsSpecifiedContentToContext()
        {
            var cell = new Cell();
            var contentFactory = new ContentFactory();
            cell.SetContent(contentFactory.GetContent(ContentType.Bomb));
            ICell context = cell.GetContext();

            Assert.AreEqual(!default(bool), context.Content is Bomb);
            Assert.AreEqual((CellState)default(int), context.State);
        }
    }
}
