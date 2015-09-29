namespace Minesweeper.Logic.CommandOperators.Common.PlayCommandHandlers
{
    using Boards.Contracts;
    using Contracts;
    using Minesweeper.Logic.Common;

    public class IsInsideBoardHandler : PlayCommandHandler
    {
        public override void HandleRequest(int row, int col, IBoard board)
        {
            if (!board.IsInsideBoard(row, col))
            {
                board.ChangeBoardState(new Notification(GlobalMessages.OutOfBorders, BoardState.Pending));
            }
            else if (this.Successor != null)
            {
                this.Successor.HandleRequest(row, col, board);
            }
        }
    }
}
