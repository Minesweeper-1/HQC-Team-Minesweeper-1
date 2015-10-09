namespace Minesweeper.Logic.Boards.Contracts
{
    using Cells.Contracts;
    using Common;

    /// <summary>
    /// Interface defining the playing board
    /// </summary>
    public interface IBoard : IBoardSubject
    {
        ICell[,] Cells
        {
            get;
        }

        int Rows
        {
            get;
        }

        int Cols
        {
            get;
        }

        int NumberOfMines
        {
            get;
        }

        BoardState BoardState
        {
            get;
        }

        /// <summary>
        /// Notifies the board observers for changes in the board state
        /// </summary>
        /// <param name="boardState">Notification containing message and state</param>
        void ChangeBoardState(Notification boardState);

        /// <summary>
        /// Calculates the number of bombs, surrounding the cell with coordinates passed as parameters
        /// </summary>
        /// <param name="cellRow">The row of the cell</param>
        /// <param name="cellCol">The column of the cell</param>
        /// <returns>The number of surrounding bombs as an integer</returns>
        int CalculateNumberOfSurroundingBombs(int cellRow, int cellCol);

        /// <summary>
        /// Reveals the cell whose coordinates are passed as parameters
        /// </summary>
        /// <param name="cellRow">The row of the cell to be revealed</param>
        /// <param name="cellCol">The column of the cell to be revealed</param>
        void RevealCell(int cellRow, int cellCol);

        /// <summary>
        /// Checks whether a cell with given coordinates is within the playing board
        /// </summary>
        /// <param name="cellRow">The row of the cell to be checked</param>
        /// <param name="cellCol">The column of the cell to be checked</param>
        /// <returns>Boolean showing whether the cell is within the board</returns>
        bool IsInsideBoard(int cellRow, int cellCol);

        /// <summary>
        /// Checks whether the given cell contains a bomb
        /// </summary>
        /// <param name="cellRow">The row of the cell to be checked</param>
        /// <param name="cellCol">The column of the cell to be checked</param>
        /// <returns>Boolean showing whether the cell contains a bomb</returns>
        bool IsBomb(int cellRow, int cellCol);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cellRow"></param>
        /// <param name="cellCol"></param>
        /// <returns></returns>
        bool IsAlreadyShown(int cellRow, int cellCol);
    }
}
