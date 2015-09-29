namespace Minesweeper.Logic.CommandOperators.Common.PlayCommandHandlers
{
    using Boards.Contracts;
    using Contracts;
    using Minesweeper.Logic.Common;

    public class IsBombHandler : PlayCommandHandler
    {
        public override void HandleRequest(int row, int col, IBoard board)
        {
            if (board.IsBomb(row, col))
            {
                board.ChangeBoardState(new Notification(GlobalMessages.GameOver, BoardState.Closed));
            }
            else if (this.Successor != null)
            {
                this.Successor.HandleRequest(row, col, board);
            }
        }
    }
}
