namespace Minesweeper.Cells
{
    using Common;
    using Contents.Contracts;
    using Contracts;

    public class Cell : ICell
    {
        public Cell(CellState state = CellState.Sealed)
        {
            this.State = state;
            this.Content = default(IContent);
        }

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
