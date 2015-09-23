namespace Minesweeper.Cells.Contracts
{
    using Contents.Contracts;
    using Common;

    public interface ICell
    {
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
