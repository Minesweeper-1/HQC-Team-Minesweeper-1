namespace Minesweeper.Logic.Cells.Contracts
{
    using Common;
    using Contents.Contracts;

    /// <summary>
    /// The public interface of the board cells defining their content and state
    /// </summary>
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
