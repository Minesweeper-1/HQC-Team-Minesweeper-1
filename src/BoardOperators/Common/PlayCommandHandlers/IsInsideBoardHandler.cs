namespace Minesweeper.BoardOperators.Common.PlayCommandHandlers
{
    using Contracts;
    using Renderers.Contracts;
    using Boards.Contracts;
    using Minesweeper.Common;

    public class IsInsideBoardHandler : PlayCommandHandler
    {
        public IsInsideBoardHandler()
        {

        }

        public override void HandleRequest(int x, int y, IBoard board, IRenderer renderer)
        {
            if(!board.IsInsideBoard(x, y))
            {
                renderer.RenderLine(GlobalMessages.OutOfBorders);
                board.ChangeBoardState(BoardState.Pending);
            }
            else if(this.successor != null)
            {
                this.successor.HandleRequest(x, y, board, renderer);
            }
        }
    }
}
