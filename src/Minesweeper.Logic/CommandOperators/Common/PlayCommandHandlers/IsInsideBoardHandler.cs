namespace Minesweeper.Logic.CommandOperators.Common.PlayCommandHandlers
{
    using Boards.Contracts;
    using Contracts;
    using Minesweeper.Logic.Common;

    /// <summary>
    /// A class which inherits the PlayCommandHandler and handles the request if the passed row and/or col are outside the board
    /// </summary>
    public class IsInsideBoardHandler : PlayCommandHandler
    {
        /// <summary>
        /// The implementation of the request handler dealing with coordinates outside of the board
        /// </summary>
        /// <param name="row">The passed int for row</param>
        /// <param name="col">The passed int for column</param>
        /// <param name="board">The current playing board</param>
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
