// <copyright file="InputProviderTests.cs" company="Team Minesweeper-1">
// Copyright (c) The team. All rights reserved.
// </copyright>
namespace Minesweeper.UI.Console.Tests.InputProviders
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Minesweeper.UI.Console.InputProviders.Contracts;

    using Moq;

    /// <summary>
    /// Test class for the InputProvider
    /// </summary>
    [TestClass]
    public class InputProviderTests
    {
        /// <summary>
        /// Testing receiving input
        /// </summary>
        [TestMethod]
        public void MockTestOfReceiveInputLieMethod()
        {
            var mockedInputProvider = this.MockedInputProvder();
            Assert.AreEqual(mockedInputProvider.Object.ReceiveInputLine(), "a 1");
        }

        /// <summary>
        /// Testing IsKeyAvailable
        /// </summary>
        [TestMethod]
        public void MockTestOfIsKeyAvailableProperty()
        {
            var mockedInputProvider = this.MockedInputProvder();
            Assert.AreEqual(mockedInputProvider.Object.IsKeyAvailable, true);
        }

        /// <summary>
        /// Testing GetKeyChar
        /// </summary>
        [TestMethod]
        public void MockTestOfGetKeyChar()
        {
            var mockedInputProvider = this.MockedInputProvder();
            Assert.AreEqual(mockedInputProvider.Object.GetKeyChar(), 1);
        }

        /// <summary>
        /// Private method providing a mocked input provider
        /// </summary>
        /// <returns>The mocked input provider</returns>
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
