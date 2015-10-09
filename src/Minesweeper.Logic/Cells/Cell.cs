namespace Minesweeper.Logic.Cells
{
    using Common;
    using Contents.Contracts;
    using Contracts;

    /// <summary>
    /// A class providing means of setting content and state and getting the context of a cell
    /// </summary>
    public class Cell
    {
        private readonly CellContext context = new CellContext();
        
        /// <summary>
        /// A method for setting the content of a cell and returning it
        /// </summary>
        /// <param name="content">The content to be set</param>
        /// <returns>A cell with the given content</returns>
        public Cell SetContent(IContent content)
        {
            this.context.Content = content;
            return this;
        }

        /// <summary>
        /// A method for setting the state of a cell and returning it
        /// </summary>
        /// <param name="state">The state to be set</param>
        /// <returns>A cell with the given state</returns>
        public Cell SetState(CellState state)
        {
            this.context.State = state;
            return this;
        }

        /// <summary>
        /// A method for getting the context of a cell
        /// </summary>
        /// <returns>The context</returns>
        public ICell GetContext() => this.context;
    }
}
