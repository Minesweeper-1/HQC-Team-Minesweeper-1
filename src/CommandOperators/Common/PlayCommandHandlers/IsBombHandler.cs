namespace Minesweeper.CommandOperators.Common.PlayCommandHandlers
{
    using Contracts;
    using Boards.Contracts;
    using Renderers.Contracts;
    using global::Minesweeper.Common;

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
            else if(this.Successor != null)
            {
                this.Successor.HandleRequest(row, col, board, renderer);
            }
        }
    }
}
