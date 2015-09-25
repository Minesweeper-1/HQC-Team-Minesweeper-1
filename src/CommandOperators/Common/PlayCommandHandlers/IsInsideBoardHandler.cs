namespace Minesweeper.CommandOperators.Common.PlayCommandHandlers
{
    using Boards.Contracts;
    using Contracts;
    using Minesweeper.Common;
    using Renderers.Contracts;

    public class IsInsideBoardHandler : PlayCommandHandler
    {
        public IsInsideBoardHandler()
        {
        }

        public override void HandleRequest(int row, int col, IBoard board, IRenderer renderer)
        {
            if (!board.IsInsideBoard(row, col))
            {
                renderer.RenderLine(GlobalMessages.OutOfBorders);
                board.ChangeBoardState(BoardState.Pending);
            }
            else if (this.Successor != null)
            {
                this.Successor.HandleRequest(row, col, board, renderer);
            }
        }
    }
}
