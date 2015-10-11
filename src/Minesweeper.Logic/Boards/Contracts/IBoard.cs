/// <summary>
/// Defines a namespace containing common interfaces for all game board and game board related implementations
/// </summary>
namespace Minesweeper.Logic.Boards.Contracts
{
    using Cells.Contracts;
    using Common;

    /// <summary>
    /// Interface defining the playing board public members
    /// </summary>
    public interface IBoard : IBoardSubject
    {
        /// <summary>
        /// Specifies the algorithmic structure for storing and accessing the board cells
        /// </summary>
        ICell[,] Cells
        {
            get;
        }

        /// <summary>
        /// Specifies board number of rows
        /// </summary>
        int Rows
        {
            get;
        }

        /// <summary>
        /// Specifies board number of columns
        /// </summary>
        int Cols
        {
            get;
        }

        /// <summary>
        /// Specifies board total number of mines
        /// </summary>
        int NumberOfMines
        {
            get;
        }

        /// <summary>
        /// Specifies the current board state
        /// </summary>
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
        /// Checks whether the given cell has already been revealed or not
        /// </summary>
        /// <param name="cellRow">The row of the cell to be checked</param>
        /// <param name="cellCol">The column of the cell to be checked</param>
        /// <returns>Boolean showing whether the cell has already been revealed or not</returns>
        bool IsAlreadyShown(int cellRow, int cellCol);
    }
}
