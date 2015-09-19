namespace Minesweeper.Cells.Common
{
    using Contracts;
    using Contents.Contracts;

    public class Cell : ICell
    {
        public Cell(int row, int col, IContent content)
        {
            this.Row = row;
            this.Col = col;
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
    }
}
