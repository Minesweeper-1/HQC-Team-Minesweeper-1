namespace Minesweeper.UI.Console.Tests.MenuHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    using Console.InputProviders.Contracts;
    using Console.MenuHandlers;
    using Console.Renderers.Contracts;
    using Logic.DifficultyCommands;
    using Logic.DifficultyCommands.Contracts;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class MenuHandlerTests
    {
        private const uint StdOutputHandle = 0xFFFFFFF5;

        [TestMethod]
        public void ExpectNoExcpetionFromMenuHandlerConstructor()
        {
            var mockedConsoleRenderer = new Mock<IConsoleRenderer>();
            var mockedInputProvider = new Mock<IConsoleInputProvider>();
            var gameModes = new List<IGameMode>();
            gameModes.Add(new BeginnerMode());

            var consoleMenuHandler = new ConsoleMenuHandler(mockedInputProvider.Object, mockedConsoleRenderer.Object, gameModes, 0, 0);
        }

        [TestMethod]
        public void ExpectNoExcpetionFromMenuHandlerShowMenu()
        {
            var mockedConsoleRenderer = new Mock<IConsoleRenderer>();
            var mockedInputProvider = new Mock<IConsoleInputProvider>();
            var gameModes = new List<IGameMode>();
            gameModes.Add(new BeginnerMode());

            var consoleMenuHandler = new ConsoleMenuHandler(mockedInputProvider.Object, mockedConsoleRenderer.Object, gameModes, 0, 0);

            consoleMenuHandler.ShowSelections();
        }

        [TestMethod]
        public void ExpectNoExcpetionFromMenuHandlerUserSelection()
        {
            var mockedConsoleRenderer = new Mock<IConsoleRenderer>();
            var mockedInputProvider = new Mock<IConsoleInputProvider>();
            mockedInputProvider.Setup(o => o.IsKeyAvailable).Returns(true);
            var gameModes = new List<IGameMode>();
            gameModes.Add(new BeginnerMode());

            var consoleMenuHandler = new ConsoleMenuHandler(mockedInputProvider.Object, mockedConsoleRenderer.Object, gameModes, 0, 0);

            consoleMenuHandler.RequestUserSelection();
        }

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetStdHandle(uint nStdHandle);
        [DllImport("kernel32.dll")]
        private static extern void SetStdHandle(uint nStdHandle, IntPtr handle);
        [DllImport("kernel32")]
        public static extern bool AllocConsole();
    }
}
