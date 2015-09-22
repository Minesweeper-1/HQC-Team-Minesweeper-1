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

        public override void HandleRequest(int row, int col, IBoard board, IRenderer renderer)
        {
            if(!board.IsInsideBoard(row, col))
            {
                renderer.RenderLine(GlobalMessages.OutOfBorders);
                board.ChangeBoardState(BoardState.Pending);
            }
            else if(this.Successor != null)
            {
                this.Successor.HandleRequest(row, col, board, renderer);
            }
        }
    }
}
