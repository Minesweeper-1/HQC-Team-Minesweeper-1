namespace Minesweeper.Logic.CommandOperators.Common.PlayCommandHandlers
{
    using Boards.Contracts;
    using Contracts;
    using Minesweeper.Logic.Common;

    public class IsAlreadyShownHandler : PlayCommandHandler
    {
        public override void HandleRequest(int row, int col, IBoard board)
        {
            if (board.IsAlreadyShown(row, col))
            {
                board.ChangeBoardState(new Notification(GlobalMessages.CellAlreadyRevealed, BoardState.Pending));
            }
            else if (this.Successor != null)
            {
                this.Successor.HandleRequest(row, col, board);
            }
        }
    }
}
