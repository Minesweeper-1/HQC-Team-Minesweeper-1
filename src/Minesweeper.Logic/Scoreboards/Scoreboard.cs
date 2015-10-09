namespace Minesweeper.Logic.Scoreboards
{
    using System.Collections.Generic;
    using System.Linq;

    using Common;
    using Contracts;
    using DataManagers;
    using DataManagers.Contracts;
    using Players;
    using Players.Contracts;

    // TODO: Separate read and write logic into two separate classes - SRP Violation
    // TODO: Extract crypto key to constants
    /// <summary>
    /// A class implementing the IScoreboard interface
    /// </summary>
    public class Scoreboard : IScoreboard
    {
        private readonly IJsonManager jsonManager = new JsonManager();
        private readonly IReader dataReader = new FileReader();
        private readonly IWriter dataWriter = new FileWriter();
        private readonly IStringEncryptionManager cryptoManager = new NetStringEncryptionManager();

        /// <summary>
        /// A method for getting all players that should be on the scoreboard
        /// </summary>
        /// <returns>An IList of the players</returns>
        public IList<IPlayer> GetAll()
        {
            string leadersAsString = this.cryptoManager.Decrypt("pesho", this.dataReader.ReadAllText(GlobalConstants.ScoreboardFilePath));
            IList<IPlayer> leaders = this.jsonManager.Parse<List<Player>>(leadersAsString).ToList<IPlayer>();

            return leaders;
        }

        /// <summary>
        /// A method for registering a new player on the scoreboard
        /// </summary>
        /// <param name="player">The player to be registered</param>
        public void RegisterNewPlayerScore(IPlayer player)
        {
            IList<IPlayer> leaders = this.GetAll();
            leaders.Add(player);
            string result = this.cryptoManager.Encrypt("pesho", this.jsonManager.ToStringRepresentation(leaders));
            this.dataWriter.WriteAllText(GlobalConstants.ScoreboardFilePath, result);
        }
    }
}
