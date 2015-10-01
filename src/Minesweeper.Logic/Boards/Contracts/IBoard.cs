namespace Minesweeper.Logic.Boards.Contracts
{
    using Cells.Contracts;
    using Common;

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

        void ChangeBoardState(Notification boardState);

        int CalculateNumberOfSurroundingBombs(int cellRow, int cellCol);

        void RevealCell(int cellRow, int cellCol);

        bool IsInsideBoard(int cellRow, int cellCol);

        bool IsBomb(int cellRow, int cellCol);

        bool IsAlreadyShown(int cellRow, int cellCol);
    }
}
