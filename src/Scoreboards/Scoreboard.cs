namespace Minesweeper.Scoreboards
{
    using System.Collections.Generic;
    using System.Linq;

    using Common;
    using Contracts;
    using DataManagers;
    using Players;
    using Players.Contracts;

    public class Scoreboard : IScoreboard
    {
        public Scoreboard()
        {

        }

        public IList<IPlayer> GetAll()
        {
            // Fetch players from file
            var jsonManager = new JsonManager();
            var dataReader = new FileReader();

            string leadersAsString = dataReader.ReadAllText(GlobalConstants.ScoreboardFilePath);
            List<Player> leaders = jsonManager.Parse<List<Player>>(leadersAsString);

            // Sort leaders by score just in case
            leaders = leaders.OrderBy(player => -player.Score).ToList();

            return leaders.ToList<IPlayer>();
        }

        public void RegisterNewPlayerScore(IPlayer player)
        {
            IList<IPlayer> leaders = this.GetAll();
            leaders.Add(player);
            leaders = leaders.OrderBy(x => -x.Score).ToList();

            var jsonManager = new JsonManager();
            string result = jsonManager.Stringify(leaders);

            var dataWriter = new FileWriter();
            dataWriter.WriteAllText(GlobalConstants.ScoreboardFilePath, result);
        }
    }
}
