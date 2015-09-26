namespace Minesweeper.CommandOperators.Common
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Players.Contracts;
    using Renderers.Contracts;
    using Scoreboards.Contracts;

    public class ShowScoreboardCommand : IBoardCommand
    {
        private readonly IRenderer renderer;
        private readonly IScoreboard scoreboard;

        public ShowScoreboardCommand(IRenderer renderer, IScoreboard scoreboard)
        {
            this.renderer = renderer;
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
            this.renderer.RenderLine(line: "===============");
            this.renderer.RenderLine(line: "  SCOREBOARD  ");
            this.renderer.RenderLine(line: "===============");
            foreach (var player in leaders)
            {
                string line = $"{player.Name} {player.Score}";
                this.renderer.RenderLine(line);
            }
        }
    }
}
