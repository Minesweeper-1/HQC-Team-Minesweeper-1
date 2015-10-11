namespace Minesweeper.Logic.Boards.Settings.Contracts
{
    /// <summary>
    /// Defines an abstract class for a set of board settings
    /// </summary>
    public abstract class BoardSettings
    {
        /// <summary>
        /// Base constructor for all board settings
        /// </summary>
        /// <param name="rows">Number of board rows</param>
        /// <param name="cols">Number of board columns</param>
        /// <param name="numberOfBombs">Numer of board bombs</param>
        protected BoardSettings(int rows, int cols, int numberOfBombs)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.NumberOfBombs = numberOfBombs;
        }

        /// <summary>
        /// The number of board rows
        /// </summary>
        public int Rows { get; private set; }

        /// <summary>
        /// The number of board columns
        /// </summary>
        public int Cols { get; private set; }

        /// <summary>
        /// The number of board bombs
        /// </summary>
        public int NumberOfBombs { get; private set; }
    }
}