namespace Minesweeper.Tests.Ui.InputProviders
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using UI.Console.InputProviders.Contracts;

    [TestClass]
    public class InputProviderTests
    {
        [TestMethod]
        public void MockTestOFReceiceInputLieMethod()
        {
            var mockedInputProvider = MockedInputProvder();
            Assert.AreEqual(mockedInputProvider.Object.ReceiveInputLine(), "a 1");
        }

        [TestMethod]
        public void MockTestOFIsKeyAvailableProperty()
        {
            var mockedInputProvider = MockedInputProvder();
            Assert.AreEqual(mockedInputProvider.Object.IsKeyAvailable, true);
        }

        [TestMethod]
        public void MockTestOFGetKeyChar()
        {
            var mockedInputProvider = MockedInputProvder();
            Assert.AreEqual(mockedInputProvider.Object.GetKeyChar(), 1);
        }

        private Mock<IConsoleInputProvider> MockedInputProvder()
        {
            var mockedInputProvider = new Mock<IConsoleInputProvider>();
            mockedInputProvider.Setup(o => o.ReceiveInputLine()).Returns("a 1");
            mockedInputProvider.Setup(o => o.IsKeyAvailable).Returns(true);
            mockedInputProvider.Setup(o => o.GetKeyChar()).Returns(1);

            return mockedInputProvider;
        }
    }
}
