namespace Minesweeper.CommandOperators.Common.PlayCommandHandlers
{
    using Contracts;
    using Boards.Contracts;
    using Renderers.Contracts;
    using global::Minesweeper.Common;

    public class IsAlreadyShownHandler : PlayCommandHandler
    {
        public IsAlreadyShownHandler()
        {

        }

        public override void HandleRequest(int row, int col, IBoard board, IRenderer renderer)
        {
            if(board.IsAlreadyShown(row, col))
            {
                renderer.RenderLine(GlobalMessages.CellAlreadyRevealed);
                board.ChangeBoardState(BoardState.Pending);
            }
            else if(this.Successor != null)
            {
                this.Successor.HandleRequest(row, col, board, renderer);
            }
        }
    }
}
