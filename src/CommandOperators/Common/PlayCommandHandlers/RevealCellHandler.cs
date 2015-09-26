namespace Minesweeper.CommandOperators.Common.PlayCommandHandlers
{
    using Boards.Contracts;
    using Contracts;
    using Minesweeper.Common;
    using Renderers.Contracts;

    public class RevealCellHandler : PlayCommandHandler
    {
        public RevealCellHandler()
        {
        }

        public override void HandleRequest(int row, int col, IBoard board, IRenderer renderer)
        {
            board.RevealCell(row, col);
            renderer.ClearScreen();

            board.ChangeBoardState(BoardState.Open);
        }
    }
}
