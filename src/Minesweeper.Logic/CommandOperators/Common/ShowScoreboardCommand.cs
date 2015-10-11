namespace Minesweeper.Logic.CommandOperators.Common
{
    using System.Collections.Generic;
    using System.Linq;

    using Boards.Contracts;
    using Contracts;
    using Logic.Common;
    using Players.Contracts;
    using Scoreboards.Contracts;

    /// <summary>
    /// The class containing the implementation of the IBoardCommand dealing with showing the score
    /// </summary>
    public class ShowScoreboardCommand : IBoardCommand
    {
        /// <summary>
        /// The board toexecute a command on
        /// </summary>
        private readonly IBoard board;

        /// <summary>
        /// The scoreboard to show
        /// </summary>
        private readonly IScoreboard scoreboard;

        /// <summary>
        /// Creates a ShowScoreboard command instance
        /// </summary>
        /// <param name="board">The current playing board</param>
        /// <param name="scoreboard">The current scoreboard</param>
        public ShowScoreboardCommand(IBoard board, IScoreboard scoreboard)
        {
            this.board = board;
            this.scoreboard = scoreboard;
        }

        /// <summary>
        /// Displays the scores and changes the board state to Pending through notification
        /// </summary>
        /// <param name="command"></param>
        public void Execute(string command)
        {
            IList<IPlayer> leaders = this.scoreboard
                .GetAll()
                .OrderBy(player => -player.Score)
                .Take(count: 10)
                .ToList();

            // Render players and scores in a user-friendly manner
            // TODO: Extract as a method in the IRenderer interface
            string message = "\n";
            message += "===============\n";
            message += "  SCOREBOARD  \n";
            message += "===============\n";
            foreach (var player in leaders)
            {
                message += $"{player.Name} {player.Score}\n";
            }

            this.board.ChangeBoardState(new Notification(message, BoardState.Pending));
        }
    }
}
