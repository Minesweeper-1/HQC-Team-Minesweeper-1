namespace Minesweeper.Logic.Tests.Cells
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Logic.Cells;
    using Logic.Common;
    using Logic.Contents;

    /// <summary>
    /// Defines unit tests for the Cell class in Minesweeper.Logic.Cells
    /// </summary>
    [TestClass]
    public class CellTests
    {
        [TestMethod]
        public void GetContextReturnsObjectOfTypeCellContext()
        {
            var cell = new Cell();

            Assert.AreEqual(!default(bool), cell.GetContext() is CellContext);
        }

        [TestMethod]
        public void CellConstructorCreatesContextWithDefaultPropertyValues()
        {
            var cell = new Cell();

            var context = cell.GetContext();

            Assert.AreEqual(default(object), context.Content);
            Assert.AreEqual((CellState)default(int), context.State);
        }

        [TestMethod]
        public void SetStateAssignsSpecifiedStateToContext()
        {
            var cell = new Cell();

            cell.SetState(CellState.Revealed);
            var context = cell.GetContext();

            Assert.AreEqual(default(object), context.Content);
            Assert.AreEqual(CellState.Revealed, context.State);
        }

        [TestMethod]
        public void SetContentAssignsSpecifiedContentToContext()
        {
            var cell = new Cell();
            var contentFactory = new ContentFactory();
            cell.SetContent(contentFactory.GetContent(ContentType.Bomb));
            var context = cell.GetContext();

            Assert.AreEqual(!default(bool), context.Content is Bomb);
            Assert.AreEqual((CellState)default(int), context.State);
        }
    }
}
