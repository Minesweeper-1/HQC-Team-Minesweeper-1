namespace Minesweeper.Logic.Boards
{
    using System.Collections.Generic;

    using Settings.Contracts;
    using Cells.Contracts;
    using Common;
    using Contracts;

    /// <summary>
    /// The class containing the logic for setting up and creating the board
    /// </summary>
    public class Board : IBoard, IBoardSubject
    {
        /// <summary>
        /// Creates new board with given settings and subscribers
        /// </summary>
        /// <param name="settings">The difficulty level settings of the board</param>
        /// <param name="subscribers">The list of subscribers of the board</param>
        public Board(BoardSettings settings, List<IBoardObserver> subscribers)
        {
            this.InitializeBoard(settings.Rows, settings.Cols, settings.NumberOfBombs);
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

        /// <summary>
        /// A method for calculating the number of surrounding bombs of a given cell
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
        /// A method revealing the given cell
        /// </summary>
        /// <param name="cellRow">The row of the given cell</param>
        /// <param name="cellCol">The column of the given cell</param>
        public void RevealCell(int cellRow, int cellCol) =>
            this.Cells[cellRow, cellCol].State = CellState.Revealed;

        /// <summary>
        /// A method for checking whether the given cell is inside the board
        /// </summary>
        /// <param name="cellRow">The row of the given cell</param>
        /// <param name="cellCol">The column of the given cell</param>
        /// <returns>Boolean showing whether the cell is inside the board</returns>
        public bool IsInsideBoard(int cellRow, int cellCol) =>
            (0 <= cellRow && cellRow < this.Rows) && (0 <= cellCol && cellCol < this.Cols);

        /// <summary>
        /// A method for checking whether the given cell contains a bomb
        /// </summary>
        /// <param name="cellRow">The row of the given cell</param>
        /// <param name="cellCol">The column of the given cell</param>
        /// <returns>Boolean showing whether the cell contains a bomb</returns>
        public bool IsBomb(int cellRow, int cellCol) =>
            this.Cells[cellRow, cellCol].Content.ContentType == ContentType.Bomb;

        /// <summary>
        /// A method for checking whether the given cell is revealed
        /// </summary>
        /// <param name="cellRow">The row of the given cell</param>
        /// <param name="cellCol">The column of the given cell</param>
        /// <returns>Boolean showing whether the cell is revealed</returns>
        public bool IsAlreadyShown(int cellRow, int cellCol) =>
            this.Cells[cellRow, cellCol].State == CellState.Revealed;

        /// <summary>
        /// A method for changing the board state and notifying the observers based on a given notification
        /// </summary>
        /// <param name="notification">The notification containing a message and a state</param>
        public void ChangeBoardState(Notification notification)
        {
            this.BoardState = notification.State;
            this.Notify(notification);
        }

        /// <summary>
        /// A method for subscribing a new observer to the board
        /// </summary>
        /// <param name="boardObserverToSubscribe">The observer to be subscribed</param>
        public void Subscribe(IBoardObserver boardObserverToSubscribe) =>
            this.Subscribers.Add(boardObserverToSubscribe);

        /// <summary>
        /// A method for unsubscribing an existing observer of the board
        /// </summary>
        /// <param name="boardObserverToUnsubscribe">The observer to be unsubscribed</param>
        public void Unsubscribe(IBoardObserver boardObserverToUnsubscribe) =>
            this.Subscribers.Remove(boardObserverToUnsubscribe);

        /// <summary>
        /// A method for notifying the observers for a change in the board state
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
        /// A method for initiliazation of the board setting size, number of bombs and the state of the board
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
