namespace Minesweeper.Boards
{
    using System.Collections.Generic;

    using Cells.Contracts;
    using Common;
    using Contracts;
    using Engine.Contracts;

    public class Board : IBoard, IBoardSubject
    {
        public Board()
        {
            this.InitializeBoard();
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

        public void RevealCell(int cellRow, int cellCol)
        {
            this.Cells[cellRow, cellCol].State = CellState.Revealed;
        }

        public bool IsInsideBoard(int cellRow, int cellCol)
        {
            return (0 <= cellRow && cellRow < this.Rows) && (0 <= cellCol && cellCol < this.Cols);
        }

        public bool IsBomb(int cellRow, int cellCol)
        {
            return this.Cells[cellRow, cellCol].Content.ContentType == ContentType.Bomb;
        }

        public bool IsAlreadyShown(int cellRow, int cellCol)
        {
            return this.Cells[cellRow, cellCol].State == CellState.Revealed;
        }

        public void ChangeBoardState(BoardState boardState)
        {
            this.BoardState = boardState;
            this.Notify(this.BoardState);
        }

        public void Subscribe(IBoardObserver boardObserverToSubscribe)
        {
            this.Subscribers.Add(boardObserverToSubscribe);
        }

        public void Unsubscribe(IBoardObserver boardObserverToUnsubscribe)
        {
            this.Subscribers.Remove(boardObserverToUnsubscribe);
        }

        public void Notify(BoardState boardState)
        {
            foreach (var observer in this.Subscribers)
            {
                observer.Update(boardState);
            }
        }

        private void InitializeBoard()
        {
            this.Rows = GlobalConstants.BeginnerLevelNumberOfBoardRows;
            this.Cols = GlobalConstants.BeginnerLevelNumberOfBoardCols;
            this.NumberOfMines = GlobalConstants.BeginnerLevelNumberOfBoardBombs;
            this.Cells = new ICell[this.Rows, this.Cols];
            this.BoardState = BoardState.Open;
            this.Subscribers = new List<IBoardObserver>();
        }
    }
}
