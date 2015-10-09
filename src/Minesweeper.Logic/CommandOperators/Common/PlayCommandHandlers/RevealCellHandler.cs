namespace Minesweeper.Logic.CommandOperators.Common.PlayCommandHandlers
{
    using Boards.Contracts;
    using Contracts;
    using Minesweeper.Logic.Common;

    /// <summary>
    /// A class which inherits the PlayCommandHandler and finally handles the request revealing the cell and changing the board state
    /// </summary>
    public class RevealCellHandler : PlayCommandHandler
    {
        /// <summary>
        /// Method revealing the cell with the passed row and column and changing the board state
        /// </summary>
        /// <param name="row">The row of the cell</param>
        /// <param name="col">The column of the cell</param>
        /// <param name="board">The current playing board</param>
        public override void HandleRequest(int row, int col, IBoard board)
        {
            board.RevealCell(row, col);
            board.ChangeBoardState(new Notification(string.Empty, BoardState.Open));
        }
    }
}
