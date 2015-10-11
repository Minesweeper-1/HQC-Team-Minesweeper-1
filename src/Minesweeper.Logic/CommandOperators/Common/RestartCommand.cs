namespace Minesweeper.Logic.CommandOperators.Common
{
    using Boards.Contracts;
    using Contracts;
    using Logic.Common;

    /// <summary>
    /// Changes the board state to 'Reset'
    /// </summary>
    public class RestartCommand : IBoardCommand
    {
        private readonly IBoard board;

        public RestartCommand(IBoard board)
        {
            this.board = board;
        }

        /// <summary>
        /// Executes the reset command
        /// </summary>
        /// <param name="command">Additional command text</param>
        public void Execute(string command) =>
            this.board.ChangeBoardState(new Notification(string.Empty, BoardState.Reset));
    }
}
