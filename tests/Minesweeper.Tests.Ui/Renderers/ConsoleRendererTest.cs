namespace Minesweeper.Tests.Ui.Renderers
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using UI.Console.Renderers.Contracts;

    [TestClass]
    public class ConsoleRendererTest
    {
        [TestMethod]
        public void RenderLineMockest()
        {
            var mockRendere = new Mock<IConsoleRenderer>();
            mockRendere.Setup(o => o.RenderLine("input")).Verifiable();

            mockRendere.Object.RenderLine("input");

            mockRendere.Verify();
        }

        [TestMethod]
        public void RenderMockTest()
        {
            var mockRendere = new Mock<IConsoleRenderer>();
            mockRendere.Setup(o => o.Render("input")).Verifiable();

            mockRendere.Object.Render("input");

            mockRendere.Verify();
        }

        [TestMethod]
        public void RenderWelcomeScreenMockTest()
        {
            var mockRendere = new Mock<IConsoleRenderer>();
            mockRendere.Setup(o => o.RenderWelcomeScreen("input")).Verifiable();

            mockRendere.Object.RenderWelcomeScreen("input");

            mockRendere.Verify();
        }

    }
}
