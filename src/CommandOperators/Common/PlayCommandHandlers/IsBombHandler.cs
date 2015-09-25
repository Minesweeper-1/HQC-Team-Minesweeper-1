namespace Minesweeper.CommandOperators.Common.PlayCommandHandlers
{
    using Boards.Contracts;
    using Contracts;
    using Minesweeper.Common;
    using Renderers.Contracts;

    public class IsBombHandler : PlayCommandHandler
    {
        public IsBombHandler()
        {
        }

        public override void HandleRequest(int row, int col, IBoard board, IRenderer renderer)
        {
            if (board.IsBomb(row, col))
            {
                renderer.RenderLine(GlobalMessages.GameOver);
                board.ChangeBoardState(BoardState.Closed);
            }
            else if (this.Successor != null)
            {
                this.Successor.HandleRequest(row, col, board, renderer);
            }
        }
    }
}
