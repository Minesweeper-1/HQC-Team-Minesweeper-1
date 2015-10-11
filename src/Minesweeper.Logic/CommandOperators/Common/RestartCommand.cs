namespace Minesweeper.Logic.CommandOperators.Common
{
    using Boards.Contracts;
    using Contracts;
    using Logic.Common;

    /// <summary>
    /// A concrete implementation of the IBoardCommand interface as a Restart command
    /// </summary>
    public class RestartCommand : IBoardCommand
    {
        /// <summary>
        /// The board to execute a command on
        /// </summary>
        private readonly IBoard board;

        /// <summary>
        /// Creates a new RestartCommand instance
        /// </summary>
        /// <param name="board"></param>
        public RestartCommand(IBoard board)
        {
            this.board = board;
        }

        /// <summary>
        /// Changes the board state to Reset through a notification
        /// </summary>
        /// <param name="command">Additional command text</param>
        public void Execute(string command) =>
            this.board.ChangeBoardState(new Notification(string.Empty, BoardState.Reset));
    }
}
