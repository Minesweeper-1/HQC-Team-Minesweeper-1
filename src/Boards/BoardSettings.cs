namespace Minesweeper.Boards
{
    public class BoardSettings
    {
        internal BoardSettings(int rows, int cols, int numberOfBombs)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.NumberOfBombs = numberOfBombs;
        }

        internal int Rows { get; private set; }
        internal int Cols { get; private set; }
        internal int NumberOfBombs { get; private set; }
    }
}