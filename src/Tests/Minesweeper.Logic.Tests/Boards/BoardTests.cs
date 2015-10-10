using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Minesweeper.Logic.Tests.Boards
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;

    using Common;
    using Logic.Boards;
    using Logic.Boards.Contracts;
    using Logic.Boards.Settings.Contracts;
    using Logic.Cells.Contracts;
    using Moq;
    using Logic.Cells;
    using Logic.Contents;

    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void BoardConstructorShouldSetProvidedParameters()
        {
            var settings = new EasyBoardSettings();
            var subscribers = new List<IBoardObserver>()
            {

            };

            var board = new Board(settings, subscribers);

            Assert.AreEqual(settings.Rows, board.Rows);
            Assert.AreEqual(settings.Cols, board.Cols);
            Assert.AreEqual(settings.NumberOfBombs, board.NumberOfMines);
            Assert.AreEqual(subscribers, board.Subscribers);
            Assert.AreEqual(BoardState.Open, board.BoardState);
            Assert.AreNotEqual(default(ICell[,]), board.Cells);
        }

        [TestMethod]
        public void SubscribeShouldAddTheObjectToTheBoardSubscribers()
        {
            IBoardObserver mockedBoardObserver = new Mock<IBoardObserver>().Object;
            var settings = new EasyBoardSettings();
            var subscribers = new List<IBoardObserver>()
            {

            };

            var board = new Board(settings, subscribers);
            board.Subscribe(mockedBoardObserver);

            Assert.AreEqual(!default(bool), board.Subscribers.Contains(mockedBoardObserver));
        }

        [TestMethod]
        public void UnsubscribeShouldRemoveTheObjectFromTheBoardSubscribers()
        {
            IBoardObserver mockedBoardObserver = new Mock<IBoardObserver>().Object;
            var settings = new EasyBoardSettings();
            var subscribers = new List<IBoardObserver>()
            {
                mockedBoardObserver
            };

            var board = new Board(settings, subscribers);

            Assert.AreEqual(default(int) + 1, board.Subscribers.Count);

            board.Unsubscribe(mockedBoardObserver);

            Assert.AreEqual(default(int), board.Subscribers.Count);
        }

        [TestMethod]
        public void CalculateSurroundingBombsOnEmptyBoardShouldReturnZero()
        {
            var settings = new EasyBoardSettings();
            var subscribers = new List<IBoardObserver>()
            {

            };

            var board = new Board(settings, subscribers);
            this.FillBoard(board);

            int result = board.CalculateNumberOfSurroundingBombs(default(int), default(int));

            Assert.AreEqual(default(int), result);
        }

        [TestMethod]
        public void CalculateSurroundingBombsOnCellWithBombShouldReturnZero()
        {
            var contentFactory = new ContentFactory();
            var settings = new EasyBoardSettings();
            var subscribers = new List<IBoardObserver>()
            {

            };

            var board = new Board(settings, subscribers);
            this.FillBoard(board);

            board.Cells[default(int), default(int)].Content = contentFactory.GetContent(ContentType.Bomb);

            int result = board.CalculateNumberOfSurroundingBombs(default(int), default(int));

            Assert.AreEqual(default(int), result);
        }

        [TestMethod]
        public void CalculateSurroundingBombsWithSurroundingBombShouldReturnOne()
        {
            var contentFactory = new ContentFactory();
            var settings = new EasyBoardSettings();
            var subscribers = new List<IBoardObserver>()
            {

            };

            var board = new Board(settings, subscribers);
            this.FillBoard(board);

            board.Cells[default(int) + 1, default(int)].Content = contentFactory.GetContent(ContentType.Bomb);

            int result = board.CalculateNumberOfSurroundingBombs(default(int), default(int));

            Assert.AreEqual(default(int) + 1, result);
        }

        [TestMethod]
        public void IsAlreadyShownShouldReturnFalseWhenCalledUponSealedCell()
        {
            var settings = new EasyBoardSettings();
            var subscribers = new List<IBoardObserver>()
            {

            };

            var board = new Board(settings, subscribers);
            this.FillBoard(board);

            bool result = board.IsAlreadyShown(default(int), default(int));

            Assert.AreEqual(default(bool), result);
        }

        [TestMethod]
        public void IsAlreadyShownShouldReturnTrueWhenCalledUponRevealedCell()
        {
            var settings = new EasyBoardSettings();
            var subscribers = new List<IBoardObserver>()
            {

            };

            var board = new Board(settings, subscribers);
            this.FillBoard(board);
            board.RevealCell(default(int), default(int));

            bool result = board.IsAlreadyShown(default(int), default(int));

            Assert.AreEqual(!default(bool), result);
        }

        [TestMethod]
        public void ChangeBoardStateShouldChangeBoardStateAndNotifySubscribers()
        {
            var templateNotification = new Notification(string.Empty, BoardState.Open);
            var mockedBoardObserver = new Mock<IBoardObserver>();
            mockedBoardObserver.Setup(o => o.Update(templateNotification)).Verifiable();

            var settings = new EasyBoardSettings();
            var subscribers = new List<IBoardObserver>()
            {
                mockedBoardObserver.Object
            };

            var board = new Board(settings, subscribers);
            board.ChangeBoardState(templateNotification);
            mockedBoardObserver.Verify(o => o.Update(templateNotification), Times.AtMostOnce);

        }

        private void FillBoard(IBoard board)
        {
            var contentFactory = new ContentFactory();
            for (var row = 0; row < board.Rows; row++)
            {
                for (int col = 0; col < board.Cols; col++)
                {
                    board.Cells[row, col] = new Cell()
                        .SetContent(contentFactory.GetContent(ContentType.Empty))
                        .SetState(CellState.Sealed)
                        .GetContext();
                }
            }
        }
    }
}
