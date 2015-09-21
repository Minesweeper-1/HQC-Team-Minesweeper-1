namespace Minesweeper.Scoreboards
{
    using System.Collections.Generic;
    using System.Linq;

    using Common;
    using Contracts;
    using DataManagers;
    using Players;
    using Players.Contracts;
    using DataManagers.Contracts;

    public class Scoreboard : IScoreboard
    {
        private readonly IJsonManager jsonManager;
        private readonly IReader dataReader;
        private readonly IWriter dataWriter;

        public Scoreboard()
        {
            this.jsonManager = new JsonManager();
            this.dataReader = new FileReader();
            this.dataWriter = new FileWriter();
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
            string result = this.jsonManager.Stringify(leaders);
            this.dataWriter.WriteAllText(GlobalConstants.ScoreboardFilePath, result);
        }
    }
}
