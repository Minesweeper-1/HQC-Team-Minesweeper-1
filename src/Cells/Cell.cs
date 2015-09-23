namespace Minesweeper.Cells
{
    using Common;
    using Contents.Contracts;
    using Contracts;

    public class Cell : ICell
    {
        private readonly int row;
        private readonly int col;

        public Cell(int row, int col)
        {
            this.row = row;
            this.col = col;
            this.State = CellState.Sealed;
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
