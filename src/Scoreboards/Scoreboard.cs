namespace Minesweeper.Scoreboards
{
    using System.Collections.Generic;
    using System.Linq;

    using Common;
    using Contracts;
    using DataManagers;
    using DataManagers.Contracts;
    using Players;
    using Players.Contracts;

    public class Scoreboard : IScoreboard
    {
        private readonly IJsonManager jsonManager = new JsonManager();
        private readonly IReader dataReader = new FileReader();
        private readonly IWriter dataWriter = new FileWriter();

        public Scoreboard()
        {
        }

        public IList<IPlayer> GetAll()
        {
            string leadersAsString = this.dataReader.ReadAllText(GlobalConstants.ScoreboardFilePath);
            IList<IPlayer> leaders = this.jsonManager.Parse<List<Player>>(leadersAsString).ToList<IPlayer>();

            return leaders;
        }

        public void RegisterNewPlayerScore(IPlayer player)
        {
            IList<IPlayer> leaders = this.GetAll();
            leaders.Add(player);
            string result = this.jsonManager.ToStringRepresentation(leaders);
            this.dataWriter.WriteAllText(GlobalConstants.ScoreboardFilePath, result);
        }
    }
}
