namespace Minesweeper.BoardOperators.Common.PlayCommandHandlers
{
    using Contracts;
    using Boards.Contracts;
    using Renderers.Contracts;
    using Minesweeper.Common;

    public class IsAlreadyShownHandler : PlayCommandHandler
    {
        public IsAlreadyShownHandler()
        {

        }

        public override void HandleRequest(int x, int y, IBoard board, IRenderer renderer)
        {
            if(board.IsAlreadyShown(x, y))
            {
                renderer.RenderLine(GlobalMessages.CellAlreadyRevealed);
                board.ChangeBoardState(BoardState.Pending);
            }
            else if(this.successor != null)
            {
                this.successor.HandleRequest(x, y, board, renderer);
            }
        }
    }
}
