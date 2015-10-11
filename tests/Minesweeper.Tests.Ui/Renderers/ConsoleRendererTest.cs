namespace Minesweeper.Tests.Ui.Renderers
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using UI.Console.Renderers.Contracts;
    using UI.Console.Renderers;
    using System.Runtime.InteropServices;
    using UI.Console.Engine.Initializations;
    using Logic.Contents;
    using Logic.Boards;
    using Logic.Boards.Contracts;
    using Logic.Boards.Settings;
    using System.Collections.Generic;
    using System.IO;
    using Logic.DifficultyCommands.Contracts;
    using Logic.DifficultyCommands;
    using System.Collections;

    [TestClass]
    public class ConsoleRendererTest
    {
        private const UInt32 StdOutputHandle = 0xFFFFFFF5;
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetStdHandle(UInt32 nStdHandle);
        [DllImport("kernel32.dll")]
        private static extern void SetStdHandle(UInt32 nStdHandle, IntPtr handle);
        [DllImport("kernel32")]
        static extern bool AllocConsole();

        [TestMethod]
        public void NoExceptionIsTrownByRenderLine()
        {
            AllocConsole();
            var renderer = new ConsoleRenderer();

            renderer.RenderLine("Haha");
            //Console.ReadLine();     

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

            renderer.RenderBoard(board,board.Cols,board.Rows);
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

            renderer.SetCursor(0,0);
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
            renderer.RenderMenu(gameModes,1,1);
            
        }

    }
}
