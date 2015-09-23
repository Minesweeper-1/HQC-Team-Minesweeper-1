namespace Minesweeper.CommandOperators.Common.PlayCommandHandlers.Contracts
{
    using Boards.Contracts;
    using Renderers.Contracts;

    public abstract class PlayCommandHandler
    {
        private PlayCommandHandler successor;

        protected PlayCommandHandler()
        {

        }

        protected PlayCommandHandler Successor
        {
            get
            {
                return successor;
            }

            private set
            {
                this.successor = value;
            }
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
