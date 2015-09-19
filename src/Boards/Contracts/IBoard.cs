namespace Minesweeper.Boards.Contracts
{
    using Cells.Contracts;

    public interface IBoard
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

        int CalculateNumberOfSurroundingBombs(int cellRow, int cellCol);

        void RevealCell(int cellRow, int cellCol);

        bool IsInsideBoard(int cellRow, int cellCol);

        bool IsBomb(int cellRow, int cellCol);

        bool IsAlreadyShown(int cellRow, int cellCol);
    }
}
