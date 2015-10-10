namespace Minesweeper.Logic.CommandOperators.Common
{
    using Boards.Contracts;
    using Contracts;
    using Minesweeper.Logic.Common;

    /// <summary>
    /// Class dealing with the end game command
    /// </summary>
    public class EndGameCommand : IBoardCommand
    {
        private readonly IBoard board;

        /// <summary>
        /// The constructor of the class
        /// </summary>
        /// <param name="board">the current playing board</param>
        public EndGameCommand(IBoard board)
        {
            this.board = board;
        }

        /// <summary>
        /// The method ending the game, changing the board state to closed
        /// </summary>
        /// <param name="command">The command</param>
        public void Execute(string command) => 
            this.board.ChangeBoardState(new Notification(GlobalMessages.GameOver, BoardState.Closed));
    }
}
