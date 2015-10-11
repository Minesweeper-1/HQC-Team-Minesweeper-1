namespace Minesweeper.Logic.CommandOperators.Common
{
    using Boards.Contracts;
    using Contracts;
    using Logic.Common;

    /// <summary>
    /// Concrete implementation of the IBoardCommand interface as an End Game command
    /// </summary>
    public class EndGameCommand : IBoardCommand
    {
        /// <summary>
        /// The board to execute the command on
        /// </summary>
        private readonly IBoard board;

        /// <summary>
        /// Creates a new End Game command
        /// </summary>
        /// <param name="board">The board to execute the command on</param>
        public EndGameCommand(IBoard board)
        {
            this.board = board;
        }

        /// <summary>
        /// Sets the board state to Closed with a new notification
        /// </summary>
        /// <param name="command">A message to pass with the notification</param>
        public void Execute(string command) => 
            this.board.ChangeBoardState(new Notification(GlobalMessages.GameOver, BoardState.Closed));
    }
}
