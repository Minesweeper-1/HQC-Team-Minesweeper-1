namespace Minesweeper.Logic.CommandOperators.Common
{
    using System.Collections.Generic;
    using System.Linq;

    using Boards.Contracts;
    using Minesweeper.Logic.Common;
    using Contracts;
    using Players.Contracts;
    using Scoreboards.Contracts;

    public class ShowScoreboardCommand : IBoardCommand
    {
        private readonly IBoard board;
        private readonly IScoreboard scoreboard;

        public ShowScoreboardCommand(IBoard board, IScoreboard scoreboard)
        {
            this.board = board;
            this.scoreboard = scoreboard;
        }

        public void Execute(string command)
        {
            IList<IPlayer> leaders = this.scoreboard
                .GetAll()
                .OrderBy(player => -player.Score)
                .Take(count: 10)
                .ToList();

            // Render players and scores in a user-friendly manner
            // TODO: Extract as a method in the IRenderer interface
            var message = string.Empty;
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
