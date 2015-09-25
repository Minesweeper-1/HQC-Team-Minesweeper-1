namespace Minesweeper.Cells
{
    using Contents.Contracts;
    using Contracts;

    public class CellContext : ICell
    {
        public CellContext()
        {
        }

        public IContent Content
        {
            get;
            set;
        }

        public Common.CellState State
        {
            get;
            set;
        }
    }
}
