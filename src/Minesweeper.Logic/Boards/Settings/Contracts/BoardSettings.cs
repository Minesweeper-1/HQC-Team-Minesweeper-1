namespace Minesweeper.Logic.Boards.Settings.Contracts
{
    public abstract class BoardSettings
    {
        protected BoardSettings(int rows, int cols, int numberOfBombs)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.NumberOfBombs = numberOfBombs;
        }

        public int Rows { get; private set; }

        public int Cols { get; private set; }

        public int NumberOfBombs { get; private set; }
    }
}