namespace Minesweeper.Logic.CommandOperators.Common.PlayCommandHandlers
{
    using Boards.Contracts;
    using Contracts;
    using Logic.Common;

    /// <summary>
    /// A class which inherits the PlayCommandHandler and handles the request if the cell is already revealed
    /// </summary>
    public class IsAlreadyShownHandler : PlayCommandHandler
    {
        /// <summary>
        /// The implementation of the request handler dealing with already revealed cells
        /// </summary>
        /// <param name="row">The row of the cell</param>
        /// <param name="col">The column of the cell</param>
        /// <param name="board">The current playing board</param>
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
