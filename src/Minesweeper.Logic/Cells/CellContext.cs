namespace Minesweeper.Logic.Cells
{
    using Common;
    using Contents.Contracts;
    using Contracts;

    /// <summary>
    /// Concrete implementation of the ICell interface
    /// </summary>
    public class CellContext : ICell
    {
        /// <summary>
        /// Concrete cell content
        /// </summary>
        public IContent Content
        {
            get;
            set;
        }

        /// <summary>
        /// Concrete cell state
        /// </summary>
        public CellState State
        {
            get;
            set;
        }
    }
}
