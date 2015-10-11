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
        [TestMethod]
        public void GetContentWithNoParametersReturnsDefaultContent()
        {
            var factory = new ContentFactory();

            IContent content = factory.GetContent();

            Assert.AreEqual(!default(bool), content is EmptyContent);
        }
    }
}
