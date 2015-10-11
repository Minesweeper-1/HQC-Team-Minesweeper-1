namespace Minesweeper.Logic.Boards
{
    using System.Collections.Generic;

    using Settings.Contracts;
    using Cells.Contracts;
    using Common;
    using Contracts;

    /// <summary>
    /// Concrete implementation of the IBoard and IBoardSubject interfaces
    /// </summary>
    public class Board : IBoard, IBoardSubject
    {
        /// <summary>
        /// Creates a new board with the given settings and initial collection of subscribers
        /// </summary>
        /// <param name="settings">The difficulty level settings of the board</param>
        /// <param name="subscribers">The initial list of subscribers of the board</param>
        public Board(BoardSettings settings, List<IBoardObserver> subscribers)
        {
            this.InitializeBoard(settings.Rows, settings.Cols, settings.NumberOfBombs);
            this.Subscribers = subscribers;
        }

        /// <summary>
        /// Board number of mines
        /// </summary>
        public int NumberOfMines
        {
            get;
            private set;
        }

        /// <summary>
        /// Board number of columns
        /// </summary>
        public int Cols
        {
            get;
            private set;
        }

        /// <summary>
        /// Board number of rows
        /// </summary>
        public int Rows
        {
            get;
            private set;
        }

        /// <summary>
        /// Board collection of cells
        /// </summary>
        public ICell[,] Cells
        {
            get;
            private set;
        }

        /// <summary>
        /// Current board state
        /// </summary>
        public BoardState BoardState
        {
            get;
            private set;
        }

        /// <summary>
        /// Collection of all board subscribers
        /// </summary>
        public IList<IBoardObserver> Subscribers
        {
            get;
            private set;
        }

        /// <summary>
        /// Calculates the number of surrounding bombs around a given cell
        /// </summary>
        /// <param name="cellRow">The row of the given cell</param>
        /// <param name="cellCol">The column of the given cell</param>
        /// <returns></returns>
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

        /// <summary>
        /// Sets the state of a specified state to Reavealed
        /// </summary>
        /// <param name="cellRow">The row of the given cell</param>
        /// <param name="cellCol">The column of the given cell</param>
        public void RevealCell(int cellRow, int cellCol) =>
            this.Cells[cellRow, cellCol].State = CellState.Revealed;

        /// <summary>
        /// Checks whether the given cell is inside the board
        /// </summary>
        /// <param name="cellRow">The row of the given cell</param>
        /// <param name="cellCol">The column of the given cell</param>
        /// <returns>Boolean showing whether the cell is inside the board</returns>
        public bool IsInsideBoard(int cellRow, int cellCol) =>
            (0 <= cellRow && cellRow < this.Rows) && (0 <= cellCol && cellCol < this.Cols);

        /// <summary>
        /// Checks whether the given cell contains a bomb
        /// </summary>
        /// <param name="cellRow">The row of the given cell</param>
        /// <param name="cellCol">The column of the given cell</param>
        /// <returns>Boolean showing whether the cell contains a bomb</returns>
        public bool IsBomb(int cellRow, int cellCol) =>
            this.Cells[cellRow, cellCol].Content.ContentType == ContentType.Bomb;

        /// <summary>
        /// Checks whether the given cell is already revealed
        /// </summary>
        /// <param name="cellRow">The row of the given cell</param>
        /// <param name="cellCol">The column of the given cell</param>
        /// <returns>Boolean showing whether the cell is revealed</returns>
        public bool IsAlreadyShown(int cellRow, int cellCol) =>
            this.Cells[cellRow, cellCol].State == CellState.Revealed;

        /// <summary>
        /// Changes the board state and notifies the board observers with a provided notification
        /// </summary>
        /// <param name="notification">The notification containing a message and a state</param>
        public void ChangeBoardState(Notification notification)
        {
            this.BoardState = notification.State;
            this.Notify(notification);
        }

        /// <summary>
        /// Subscribes a new observer to the board
        /// </summary>
        /// <param name="boardObserverToSubscribe">The observer to be subscribed</param>
        public void Subscribe(IBoardObserver boardObserverToSubscribe) =>
            this.Subscribers.Add(boardObserverToSubscribe);

        /// <summary>
        /// Unsubscribes an existing observer of the board
        /// </summary>
        /// <param name="boardObserverToUnsubscribe">The observer to be unsubscribed</param>
        public void Unsubscribe(IBoardObserver boardObserverToUnsubscribe) =>
            this.Subscribers.Remove(boardObserverToUnsubscribe);

        /// <summary>
        /// Notifies the observers for a change in the board state
        /// </summary>
        /// <param name="boardState">The notification containing a message and a state the observers will be updated with</param>
        public void Notify(Notification boardState)
        {
            foreach (var observer in this.Subscribers)
            {
                observer.Update(boardState);
            }
        }

        /// <summary>
        /// A method for setting all board settings to an initial state
        /// </summary>
        /// <param name="rows">The number of rows of the board</param>
        /// <param name="cols">The number of columns of the board</param>
        /// <param name="numberOfBombs">The number of bombs the board will contain</param>
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
