

namespace Minesweeper.Tests.Ui.Engine
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using UI.Console.Engine.Initializations;
    using Logic.Contents;
    using Logic.Boards.Settings;
    using Logic.Boards.Contracts;
    using System.Collections.Generic;
    using Logic.Boards;
    using Logic.Common;

    [TestClass]
    public class StandardGameInitializationStrategyTests
    {
        [TestMethod]
        public void InitializationStrategyForEasyGame()
        {

            var settings = new EasyBoardSettings();
            var subscribers = new List<IBoardObserver>()
            {
            };
            var board = new Board(settings, subscribers);

            var strategy = new StandardGameInitializationStrategy(new ContentFactory());

            var newBoard = strategy.Initialize(board);
            var bombCount = 0;
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

        [TestMethod]
        public void InitializationStrategyForNormalGame()
        {

            var settings = new NormalBoardSettings();
            var subscribers = new List<IBoardObserver>()
            {
            };
            var board = new Board(settings, subscribers);

            var strategy = new StandardGameInitializationStrategy(new ContentFactory());

            var newBoard = strategy.Initialize(board);
            var bombCount = 0;
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

        [TestMethod]
        public void InitializationStrategyForHardGame()
        {

            var settings = new HardBoardSettings();
            var subscribers = new List<IBoardObserver>()
            {
            };
            var board = new Board(settings, subscribers);

            var strategy = new StandardGameInitializationStrategy(new ContentFactory());

            var newBoard = strategy.Initialize(board);
            var bombCount = 0;
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
