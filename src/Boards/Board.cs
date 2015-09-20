namespace Minesweeper.Boards
{
    using System.Collections.Generic;

    using Contracts;
    using Common;
    using Cells.Contracts;
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

        private void InitializeBoard()
        {
            this.Rows = GlobalConstants.StandardNumberOfBoardRows;
            this.Cols = GlobalConstants.StandardNumberOfBoardCols;
            this.NumberOfMines = GlobalConstants.StandardNumberOfBoardCols;
            this.Cells = new ICell[this.Rows, this.Cols];
            this.BoardState = BoardState.Open;
            this.Subscribers = new List<IBoardObserver>();
        }

        public int CalculateNumberOfSurroundingBombs(int cellRow, int cellCol)
        {
            int result = 0;

            int rowStart = cellRow - 1;
            int rowEnd = cellRow + 1;
            int colStart = cellCol - 1;
            int colEnd = cellCol + 1;

            for (int row = rowStart; row <= rowEnd; row++)
            {
                for (int col = colStart; col <= colEnd; col++)
                {
                    if (this.IsInsideBoard(row, col))
                    {
                        if(this.IsBomb(row, col))
                        {
                            result += 1;
                        }
                    }
                }
            }
            
            if(this.IsBomb(cellRow, cellCol))
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
    }
}
