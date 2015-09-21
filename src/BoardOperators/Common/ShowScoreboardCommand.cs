namespace Minesweeper.BoardOperators.Common
{
    using System.Collections.Generic;
    using System.Linq;

    using Boards.Contracts;
    using Contracts;
    using DataManagers;
    using Minesweeper.Common;
    using Players;
    using Renderers.Contracts;
    

    public class ShowScoreboardCommand : IBoardCommand
    {
        private readonly IBoard board;
        private readonly IRenderer renderer;
        
        public ShowScoreboardCommand(IBoard board, IRenderer renderer)
        {
            this.board = board;
            this.renderer = renderer;
        }

        public void Execute(string commandText)
        {
            // Fetch players from file
            var jsonManager = new JsonManager();
            var dataReader = new FileReader();

            string leadersAsString = dataReader.ReadAllText(GlobalConstants.ScoreboardFilePath);
            List<Player> leaders = jsonManager.Parse<List<Player>>(leadersAsString);

            // Sort leaders by score just in case
            IOrderedEnumerable<Player> sortedLeaders = leaders.OrderBy(player => -player.Score);

            // Render players and scores in a user-friendly manner
            // TODO: Extract as a method in the IRenderer interface
            //this.renderer.RenderLine(line: "");
            this.renderer.RenderLine(line: "===============");
            this.renderer.RenderLine(line: "  SCOREBOARD  ");
            this.renderer.RenderLine(line: "===============");
            foreach (var player in sortedLeaders)
            {
                string line = string.Format(format: "{0} {1}", arg0: player.Name, arg1: player.Score);
                this.renderer.RenderLine(line);
            }
        }
    }
}
