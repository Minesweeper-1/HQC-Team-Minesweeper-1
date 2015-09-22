namespace Minesweeper.BoardOperators.Common.PlayCommandHandlers
{
    using Contracts;
    using Boards.Contracts;
    using Renderers.Contracts;
    using Minesweeper.Common;

    public class RevealCellHandler : PlayCommandHandler
    {
        public RevealCellHandler()
        {

        }

        public override void HandleRequest(int x, int y, IBoard board, IRenderer renderer)
        {
            board.RevealCell(x, y);
            renderer.Clear();

            board.ChangeBoardState(BoardState.Open);
        }
    }
}
