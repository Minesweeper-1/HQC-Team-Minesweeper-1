namespace Minesweeper.BoardOperators.Common.PlayCommandHandlers.Contracts
{
    using Boards.Contracts;
    using Renderers.Contracts;

    public abstract class PlayCommandHandler
    {
        protected PlayCommandHandler successor;

        public PlayCommandHandler()
        {

        }

        public void SetSuccessor(PlayCommandHandler successor)
        {
            this.successor = successor;
        }

        public virtual void HandleRequest(int x, int y, IBoard board, IRenderer renderer)
        {

        }

        public virtual void HandleRequest(string command, IBoard board, IRenderer renderer)
        {

        }
    }
}
