namespace Minesweeper.Cells
{
    using Common;
    using Contents.Contracts;
    using Contracts;

    public class Cell
    {
        private readonly CellContext context = new CellContext();

        public Cell()
        {
            
        }

        public Cell Content(IContent content)
        {
            this.context.Content = content;
            return this;
        }

        public Cell State(CellState state)
        {
            this.context.State = state;
            return this;
        }

        public ICell Context()
        {
            return this.context;
        }
    }
}
