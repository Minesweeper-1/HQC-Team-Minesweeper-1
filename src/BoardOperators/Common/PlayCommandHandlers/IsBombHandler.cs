namespace Minesweeper.BoardOperators.Common.PlayCommandHandlers
{
    using Contracts;
    using Boards.Contracts;
    using Renderers.Contracts;
    using Minesweeper.Common;

    public class IsBombHandler : PlayCommandHandler
    {
        public IsBombHandler()
        {

        }

        public override void HandleRequest(int x, int y, IBoard board, IRenderer renderer)
        {
            if (board.IsBomb(x, y))
            {
                renderer.RenderLine(GlobalMessages.GameOver);
                board.ChangeBoardState(BoardState.Closed);
            }
            else if(this.successor != null)
            {
                this.successor.HandleRequest(x, y, board, renderer);
            }
        }
    }
}
