namespace Minesweeper.Logic.CommandOperators.Common.PlayCommandHandlers
{
    using Boards.Contracts;
    using Contracts;
    using Minesweeper.Logic.Common;

    public class RevealCellHandler : PlayCommandHandler
    {
        public override void HandleRequest(int row, int col, IBoard board)
        {
            board.RevealCell(row, col);
            board.ChangeBoardState(new Notification(string.Empty, BoardState.Open));
        }
    }
}
