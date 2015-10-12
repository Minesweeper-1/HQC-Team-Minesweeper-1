// <copyright file="ConsoleRendererTest.cs" company="Team Minesweeper-1">
// Copyright (c) The team. All rights reserved.
// </copyright>
namespace Minesweeper.UI.Console.Tests.Renderers
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Minesweeper.Logic.Boards;
    using Minesweeper.Logic.Boards.Contracts;
    using Minesweeper.Logic.Boards.Settings;
    using Minesweeper.Logic.Contents;
    using Minesweeper.Logic.DifficultyCommands;
    using Minesweeper.Logic.DifficultyCommands.Contracts;
    using Minesweeper.UI.Console.Engine.Initializations;
    using Minesweeper.UI.Console.Renderers;

    /// <summary>
    /// Test class for the ConsoleRenderer class
    /// </summary>
    [TestClass]
    public class ConsoleRendererTest
    {
        /// <summary>
        /// Standard output handle constant
        /// </summary>
        private const uint StdOutputHandle = 0xFFFFFFF5;

        /// <summary>
        /// Allocates a new console for the calling process.
        /// </summary>
        /// <returns>True upon success and false otherwise</returns>
        [DllImport("kernel32")]
        public static extern bool AllocConsole();

        /// <summary>
        /// Testing that clear current line does not throw an exception
        /// </summary>
        [TestMethod]
        public void NoExceptionIsTrownByClearCurrentLine()
        {
            AllocConsole();
            var renderer = new ConsoleRenderer();

            renderer.ClearCurrentLine();
        }

        /// <summary>
        /// Testing that clear screen does not throw an exception
        /// </summary>
        [TestMethod]
        public void NoExceptionIsTrownByClearScreen()
        {
            AllocConsole();
            var renderer = new ConsoleRenderer();

            renderer.ClearScreen();
        }

        /// <summary>
        /// Testing that rendering line does not throw an exception
        /// </summary>
        [TestMethod]
        public void NoExceptionIsTrownByRender()
        {
            AllocConsole();
            var renderer = new ConsoleRenderer();

            renderer.Render("Haha");
        }

        /// <summary>
        /// Testing that rendering board does not throw an exception
        /// </summary>
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

        /// <summary>
        /// Testing that rendering a line does not throw an exception
        /// </summary>
        [TestMethod]
        public void NoExceptionIsTrownByRenderLine()
        {
            AllocConsole();
            var renderer = new ConsoleRenderer();

            renderer.RenderLine("Haha"); 
        }

        /// <summary>
        /// Testing that rendering the menu does not throw an exception
        /// </summary>
        [TestMethod]
        public void NoExceptionIsTrownByRenderMenu()
        {
            AllocConsole();
            var renderer = new ConsoleRenderer();

            var gameModes = new List<IGameMode>();
            gameModes.Add(new BeginnerMode());
            renderer.RenderMenu(gameModes, 1, 1);
        }

        /// <summary>
        /// Testing that rendering the welcome screen does not throw an exception
        /// </summary>
        [TestMethod]
        public void NoExceptionIsTrownByRenderWelcomeScreen()
        {
            AllocConsole();
            var renderer = new ConsoleRenderer();

            renderer.RenderWelcomeScreen("Hello");
        }

        /// <summary>
        /// Testing that setting the cursor does not throw an exception
        /// </summary>
        [TestMethod]
        public void NoExceptionIsTrownBySetCursor()
        {
            AllocConsole();
            var renderer = new ConsoleRenderer();

            renderer.SetCursor(0, 0);
        }

        /// <summary>
        /// Testing that setting the cursor visibility does not throw an exception
        /// </summary>
        [TestMethod]
        public void NoExceptionIsTrownBySetCursorVisibilityToFalse()
        {
            AllocConsole();
            var renderer = new ConsoleRenderer();

            renderer.SetCursor(false);
        }

        /// <summary>
        /// Testing that setting the cursor visibility does not throw an exception
        /// </summary>
        [TestMethod]
        public void NoExceptionIsTrownBySetCursorVisibilityToTrue()
        {
            AllocConsole();
            var renderer = new ConsoleRenderer();

            renderer.SetCursor(true);
        }

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetStdHandle(uint stdHandle);
        [DllImport("kernel32.dll")]
        private static extern void SetStdHandle(uint stdHandle, IntPtr handle);
    }
}
