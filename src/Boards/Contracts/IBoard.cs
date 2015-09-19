namespace Minesweeper.Boards.Contracts
{
    public interface IBoard
    {
        char[,] Matrix
        {
            get;
        }

        bool[,] Bombs
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

        char UnrevealedCellChar
        {
            get;
        }

        void RevealCell(int x, int y);

        bool IsInsideBoard(int x, int y);

        bool IsBomb(int x, int y);

        bool IsAlreadyShown(int x, int y);
    }
}
