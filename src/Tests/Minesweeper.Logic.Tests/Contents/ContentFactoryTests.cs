namespace Minesweeper.Logic.Tests.Contents
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Logic.Contents;

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

            var content = factory.GetContent();

            Assert.AreEqual(!default(bool), content is EmptyContent);
        }
    }
}
