namespace Minesweeper.UI.Console.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Minesweeper.UI.Console.InputProviders.Contracts;
    using Minesweeper.UI.Console.Renderers.Contracts;

    using Moq;

    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void GameInstanceShouldCreateOnlyOneInstanceAndReturnIt()
        {
            
            var gameInstance = Game.Instance;
            var secondInstance = Game.Instance;
            Assert.AreSame(gameInstance, secondInstance);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestStart()
        {
            var gameInstance = Game.Instance;
            var inputMock = new Mock<IConsoleInputProvider>();
            var outputMock = new Mock<IConsoleRenderer>();
            inputMock.Setup(x => x.IsKeyAvailable).Returns(true);
            inputMock.Setup(x => x.GetKeyChar()).Returns(' ');
            inputMock.Setup(x => x.ReceiveInputLine()).Returns("1 1");
            inputMock.Setup(x => x.TransformCommandToNumbersOnly(It.IsAny<string>())).Returns("1 1");

            
            gameInstance.InputProvider = inputMock.Object;
            gameInstance.OutputRenderer = outputMock.Object;
            inputMock.Verify();
            gameInstance.Start();
        }
    }
}