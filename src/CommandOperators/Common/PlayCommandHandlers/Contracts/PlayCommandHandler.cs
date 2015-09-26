namespace Minesweeper.CommandOperators.Common.PlayCommandHandlers.Contracts
{
    using Boards.Contracts;
    using Renderers.Contracts;

    public abstract class PlayCommandHandler
    {
        protected PlayCommandHandler Successor
        {
            get;
            private set;
        }

        public void SetSuccessor(PlayCommandHandler successorToSet)
        {
            this.Successor = successorToSet;
        }

        public virtual void HandleRequest(int row, int col, IBoard board, IRenderer renderer)
        {
        }

        public virtual void HandleRequest(string command, IBoard board, IRenderer renderer)
        {
        }
    }
}
