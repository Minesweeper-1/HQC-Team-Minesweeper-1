namespace Minesweeper.Logic.Cells.Contracts
{
    using Common;
    using Contents.Contracts;

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
