namespace Minesweeper.Tests.Ui.Renderers
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using Logic.Boards;
    using Logic.Boards.Contracts;
    using Logic.Boards.Settings;
    using Logic.Contents;
    using Logic.DifficultyCommands;
    using Logic.DifficultyCommands.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using UI.Console.Engine.Initializations;
    using UI.Console.Renderers;
  
    [TestClass]
    public class ConsoleRendererTest
    {
        private const uint StdOutputHandle = 0xFFFFFFF5;

        [TestMethod]
        public void NoExceptionIsTrownByRenderLine()
        {
            AllocConsole();
            var renderer = new ConsoleRenderer();

            renderer.RenderLine("Haha"); 
        }

        [TestMethod]
        public void NoExceptionIsTrownByRender()
        {
            AllocConsole();
            var renderer = new ConsoleRenderer();

            renderer.Render("Haha");
        }

        [TestMethod]
        public void NoExceptionIsTrownByRenderBoard()
        {
            AllocConsole();
            var renderer = new ConsoleRenderer();

            var settings = new EasyBoardSettings();
            var subscribers = new List<IBoardObserver>()
            {
            };
            var board = new Board(settings, subscribers);

            var strategy = new StandardGameInitializationStrategy(new ContentFactory());

            var newBoard = strategy.Initialize(board);

            renderer.RenderBoard(board, board.Cols, board.Rows);
        }

        [TestMethod]
        public void NoExceptionIsTrownByRenderWelcomeScreen()
        {
            AllocConsole();
            var renderer = new ConsoleRenderer();

            renderer.RenderWelcomeScreen("Hello");
        }

        [TestMethod]
        public void NoExceptionIsTrownBySetCursor()
        {
            AllocConsole();
            var renderer = new ConsoleRenderer();

            renderer.SetCursor(0, 0);
        }

        [TestMethod]
        public void NoExceptionIsTrownBySetCursorVisibilityToTrue()
        {
            AllocConsole();
            var renderer = new ConsoleRenderer();

            renderer.SetCursor(true);
        }

        [TestMethod]
        public void NoExceptionIsTrownBySetCursorVisibilityToFalse()
        {
            AllocConsole();
            var renderer = new ConsoleRenderer();

            renderer.SetCursor(false);
        }

        [TestMethod]
        public void NoExceptionIsTrownByClearScreen()
        {
            AllocConsole();
            var renderer = new ConsoleRenderer();

            renderer.ClearScreen();
        }

        [TestMethod]
        public void NoExceptionIsTrownByClearCurrentLine()
        {
            AllocConsole();
            var renderer = new ConsoleRenderer();

            renderer.ClearCurrentLine();
        }

        [TestMethod]
        public void NoExceptionIsTrownByRenderMenu()
        {
            AllocConsole();
            var renderer = new ConsoleRenderer();

            var gameModes = new List<IGameMode>();
            gameModes.Add(new BeginnerMode()); 
            renderer.RenderMenu(gameModes, 1, 1);            
        }
        
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetStdHandle(uint nStdHandle);
        [DllImport("kernel32.dll")]
        private static extern void SetStdHandle(uint nStdHandle, IntPtr handle);
        [DllImport("kernel32")]
        public static extern bool AllocConsole();
    }
}
