// <copyright file="StandardGameInitializationStrategyTests.cs" company="Team Minesweeper-1">
// Copyright (c) The team. All rights reserved.
// </copyright>
namespace Minesweeper.UI.Console.Tests.Engine
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Minesweeper.Logic.Boards;
    using Minesweeper.Logic.Boards.Contracts;
    using Minesweeper.Logic.Boards.Settings;
    using Minesweeper.Logic.Common;
    using Minesweeper.Logic.Contents;
    using Minesweeper.UI.Console.Engine.Initializations;

    /// <summary>
    /// Test class for the StandardGameInitializationStrategy class
    /// </summary>
    [TestClass]
    public class StandardGameInitializationStrategyTests
    {
        /// <summary>
        /// Testing easy game initialization
        /// </summary>
        [TestMethod]
        public void InitializationStrategyForEasyGame()
        {
            var settings = new EasyBoardSettings();
            var subscribers = new List<IBoardObserver>()
            {
            };
            var board = new Board(settings, subscribers);

            var strategy = new StandardGameInitializationStrategy(new ContentFactory());

            IBoard newBoard = strategy.Initialize(board);
            int bombCount = 0;
            for (int i = 0; i < GlobalConstants.BeginnerLevelNumberOfBoardRows; i++)
            {
                for (int j = 0; j < GlobalConstants.BeginnerLevelNumberOfBoardCols; j++)
                {
                    if (newBoard.Cells[i, j].Content.Value == -1)
                    {
                        bombCount++;
                    }
                }
            }

            Assert.AreEqual(newBoard.Rows, GlobalConstants.BeginnerLevelNumberOfBoardRows);
            Assert.AreEqual(newBoard.Cols, GlobalConstants.BeginnerLevelNumberOfBoardCols);
            Assert.AreEqual(bombCount, GlobalConstants.BeginnerLevelNumberOfBoardBombs);
        }

        /// <summary>
        /// Testing normal game initialization
        /// </summary>
        [TestMethod]
        public void InitializationStrategyForNormalGame()
        {
            var settings = new NormalBoardSettings();
            var subscribers = new List<IBoardObserver>()
            {
            };
            var board = new Board(settings, subscribers);

            var strategy = new StandardGameInitializationStrategy(new ContentFactory());

            IBoard newBoard = strategy.Initialize(board);
            int bombCount = 0;
            for (int i = 0; i < GlobalConstants.IntermediateLevelNumberOfBoardRows; i++)
            {
                for (int j = 0; j < GlobalConstants.IntermediateLevelNumberOfBoardCols; j++)
                {
                    if (newBoard.Cells[i, j].Content.Value == -1)
                    {
                        bombCount++;
                    }
                }
            }

            Assert.AreEqual(newBoard.Rows, GlobalConstants.IntermediateLevelNumberOfBoardRows);
            Assert.AreEqual(newBoard.Cols, GlobalConstants.IntermediateLevelNumberOfBoardCols);
            Assert.AreEqual(bombCount, GlobalConstants.IntermediateLevelNumberOfBoardBombs);
        }

        /// <summary>
        /// Testing hard game initialization
        /// </summary>
        [TestMethod]
        public void InitializationStrategyForHardGame()
        {
            var settings = new HardBoardSettings();
            var subscribers = new List<IBoardObserver>()
            {
            };
            var board = new Board(settings, subscribers);

            var strategy = new StandardGameInitializationStrategy(new ContentFactory());

            IBoard newBoard = strategy.Initialize(board);
            int bombCount = 0;
            for (int i = 0; i < GlobalConstants.ExpertLevelNumberOfBoardRows; i++)
            {
                for (int j = 0; j < GlobalConstants.ExpertLevelNumberOfBoardCols; j++)
                {
                    if (newBoard.Cells[i, j].Content.Value == -1)
                    {
                        bombCount++;
                    }
                }
            }

            Assert.AreEqual(newBoard.Rows, GlobalConstants.ExpertLevelNumberOfBoardRows);
            Assert.AreEqual(newBoard.Cols, GlobalConstants.ExpertLevelNumberOfBoardCols);
            Assert.AreEqual(bombCount, GlobalConstants.ExpertLevelNumberOfBoardBombs);
        }
    }
}
