using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper.UI.Console.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.UI.Console.Engine.Tests
{
    using Minesweeper.Logic.Boards;
    using Minesweeper.Logic.Boards.Contracts;
    using Minesweeper.Logic.Boards.Settings;
    using Minesweeper.Logic.CommandOperators;
    using Minesweeper.Logic.Common;
    using Minesweeper.Logic.Contents;
    using Minesweeper.Logic.Players;
    using Minesweeper.Logic.Scoreboards.Contracts;
    using Minesweeper.UI.Console.Engine.Initializations;
    using Minesweeper.UI.Console.InputProviders.Contracts;
    using Minesweeper.UI.Console.Renderers.Contracts;

    using Moq;

    [TestClass]
    public class StandardOnePlayerMinesweeperEngineTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void StandardOnePlayerMinesweeperEngineTest()
        {
            var testInputProvider = new Mock<IConsoleInputProvider>();
            var testOutputRenderer = new Mock<IConsoleRenderer>();
            var testScoreboard = new Mock<IScoreboard>();
            var testBoard = new Board(new EasyBoardSettings(), new List<IBoardObserver>());
            var testEngine = new StandardOnePlayerMinesweeperEngine(
                testBoard,
                testInputProvider.Object,
                testOutputRenderer.Object,
                new CommandOperator(testBoard, testScoreboard.Object),
                testScoreboard.Object,
                new Player("Gosho"));
            testEngine.Initialize(new StandardGameInitializationStrategy(new ContentFactory()));
            testEngine.Update(new Notification("test", BoardState.Closed));
            testEngine.Run();
        }
    }
}