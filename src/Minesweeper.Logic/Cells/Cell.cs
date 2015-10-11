namespace Minesweeper.Logic.Cells
{
    using Common;
    using Contents.Contracts;
    using Contracts;

    /// <summary>
    /// A fluent interface wrapper for the ICell interface
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// The wrapped concrete ICell implementation
        /// </summary>
        private readonly CellContext context = new CellContext();
        
        /// <summary>
        /// Sets the content of the cell context
        /// </summary>
        /// <param name="content">The content to be set</param>
        /// <returns>The context wrapper</returns>
        public Cell SetContent(IContent content)
        {
            this.context.Content = content;
            return this;
        }

        /// <summary>
        /// Sets the state of the cell context
        /// </summary>
        /// <param name="state">The state to be set</param>
        /// <returns>The context wrapper</returns>
        public Cell SetState(CellState state)
        {
            this.context.State = state;
            return this;
        }

        /// <summary>
        /// Removes the context wrapper and returns the context
        /// </summary>
        /// <returns>The cell context</returns>
        public ICell GetContext() => this.context;
    }
}
