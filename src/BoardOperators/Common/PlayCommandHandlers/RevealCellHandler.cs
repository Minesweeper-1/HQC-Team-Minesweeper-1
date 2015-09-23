namespace Minesweeper.BoardOperators.Common.PlayCommandHandlers
{
    using Contracts;
    using Boards.Contracts;
    using Renderers.Contracts;
    using global::Minesweeper.Common;

    public class RevealCellHandler : PlayCommandHandler
    {
        public RevealCellHandler()
        {

        }

        public override void HandleRequest(int row, int col, IBoard board, IRenderer renderer)
        {
            board.RevealCell(row, col);
            renderer.Clear();

            board.ChangeBoardState(BoardState.Open);
        }
    }
}
