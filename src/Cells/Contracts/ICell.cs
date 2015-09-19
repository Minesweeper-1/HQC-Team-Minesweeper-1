namespace Minesweeper.Cells.Contracts
{
    using Contents.Contracts;
    using Common;

    public interface ICell
    {
        int Row
        {
            get;
            set;
        }

        int Col
        {
            get;
            set;
        }

        IContent Content
        {
            get;
            set;
        }

        CellState State
        {
            get;
            set;
        }
    }
}
