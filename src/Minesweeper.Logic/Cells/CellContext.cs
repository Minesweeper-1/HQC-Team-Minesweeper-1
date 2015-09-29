namespace Minesweeper.Logic.Cells
{
    using Common;
    using Contents.Contracts;
    using Contracts;

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
