namespace Minesweeper.Logic.CommandOperators.Common.PlayCommandHandlers
{
    using Boards.Contracts;
    using Contracts;
    using Minesweeper.Logic.Common;

    /// <summary>
    /// A class which inherits the PlayCommandHandler and handles the request if the cell contains a bomb
    /// </summary>
    public class IsBombHandler : PlayCommandHandler
    {
        /// <summary>
        /// The implementation of the request handler dealing with cells that contain bombs
        /// </summary>
        /// <param name="row">The row of the cell</param>
        /// <param name="col">The column of the cell</param>
        /// <param name="board">The current playing board</param>
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
