namespace Minesweeper.Logic.Boards
{
    using System.Collections.Generic;

    using Settings.Contracts;
    using Cells.Contracts;
    using Common;
    using Contracts;

    public class Board : IBoard, IBoardSubject
    {
        public Board(BoardSettings settings, List<IBoardObserver> subscribers)
        {
            this.InitializeBoard(
                settings.Rows, 
                settings.Cols,
                settings.NumberOfBombs);
            this.Subscribers = subscribers;
        }

        public int NumberOfMines
        {
            get;
            private set;
        }

        public int Cols
        {
            get;
            private set;
        }

        public int Rows
        {
            get;
            private set;
        }

        public ICell[,] Cells
        {
            get;
            private set;
        }

        public BoardState BoardState
        {
            get;
            private set;
        }

        public IList<IBoardObserver> Subscribers
        {
            get;
            private set;
        }

        public int CalculateNumberOfSurroundingBombs(int cellRow, int cellCol)
        {
            int result = 0;
            for (int row = cellRow - 1; row <= cellRow + 1; row++)
            {
                for (int col = cellCol - 1; col <= cellCol + 1; col++)
                {
                    if (this.IsInsideBoard(row, col) && this.IsBomb(row, col))
                    {
                        ++result;
                    }
                }
            }

            if (this.IsBomb(cellRow, cellCol))
            {
                result -= 1;
            }

            return result;
        }

        public void RevealCell(int cellRow, int cellCol) =>
            this.Cells[cellRow, cellCol].State = CellState.Revealed;

        public bool IsInsideBoard(int cellRow, int cellCol) =>
            (0 <= cellRow && cellRow < this.Rows) && (0 <= cellCol && cellCol < this.Cols);

        public bool IsBomb(int cellRow, int cellCol) =>
            this.Cells[cellRow, cellCol].Content.ContentType == ContentType.Bomb;

        public bool IsAlreadyShown(int cellRow, int cellCol) =>
            this.Cells[cellRow, cellCol].State == CellState.Revealed;

        public void ChangeBoardState(Notification notification)
        {
            this.BoardState = notification.State;
            this.Notify(notification);
        }

        public void Subscribe(IBoardObserver boardObserverToSubscribe) =>
            this.Subscribers.Add(boardObserverToSubscribe);

        public void Unsubscribe(IBoardObserver boardObserverToUnsubscribe) =>
            this.Subscribers.Remove(boardObserverToUnsubscribe);

        public void Notify(Notification boardState)
        {
            foreach (var observer in this.Subscribers)
            {
                observer.Update(boardState);
            }
        }

        private void InitializeBoard(int rows, int cols, int numberOfBombs)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.NumberOfMines = numberOfBombs;
            this.Cells = new ICell[this.Rows, this.Cols];
            this.BoardState = BoardState.Open;
        }
    }
}
