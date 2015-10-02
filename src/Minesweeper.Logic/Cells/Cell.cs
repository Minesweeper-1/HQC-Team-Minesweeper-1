namespace Minesweeper.Logic.Cells
{
    using Common;
    using Contents.Contracts;
    using Contracts;

    public class Cell
    {
        private readonly CellContext context = new CellContext();
        
        public Cell SetContent(IContent content)
        {
            this.context.Content = content;
            return this;
        }

        public Cell SetState(CellState state)
        {
            this.context.State = state;
            return this;
        }

        public ICell GetContext() => this.context;
    }
}
