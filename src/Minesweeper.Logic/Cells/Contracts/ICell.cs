namespace Minesweeper.Logic.Cells.Contracts
{
    using Common;
    using Contents.Contracts;

    /// <summary>
    /// Defines the inerface for all cell public members
    /// </summary>
    public interface ICell
    {
        /// <summary>
        /// Content of the cell
        /// </summary>
        IContent Content
        {
            get;
            set;
        }

        /// <summary>
        /// State of the cell
        /// </summary>
        CellState State
        {
            get;
            set;
        }
    }
}
