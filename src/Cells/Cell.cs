namespace Minesweeper.Cells
{
    using Contracts;
    using Contents.Contracts;
    using Common;
    using Contents;

    public class Cell : ICell
    {
        public Cell(int row, int col)
        {
            this.Row = row;
            this.Col = col;
            this.State = CellState.Sealed;
        }

        public Cell(int row, int col, IContent content)
            : this(row, col)
        {
            this.Content = content;
        }

        public int Row
        {
            get;
            set;
        }

        public int Col
        {
            get;
            set;
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
