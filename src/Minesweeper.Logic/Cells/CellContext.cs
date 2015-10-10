namespace Minesweeper.Logic.Cells
{
    using Common;
    using Contents.Contracts;
    using Contracts;

    /// <summary>
    /// A class for getting and setting a cell context consisting of cell state and content
    /// </summary>
    public class CellContext : ICell
    {
        public IContent Content
        {
            get;
            set;
        }

        public CellState State
        {
            get;
            set;
        }
    }
}
