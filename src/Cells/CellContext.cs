namespace Minesweeper.Cells
{
    using Contracts;
    using Contents.Contracts;

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
