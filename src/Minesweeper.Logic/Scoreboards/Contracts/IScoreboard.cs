namespace Minesweeper.Logic.Scoreboards.Contracts
{
    using System.Collections.Generic;
    
    using Players.Contracts;

    /// <summary>
    /// An interface providing scoreboard logic
    /// </summary>
    public interface IScoreboard
    {
        /// <summary>
        /// A method for getting all players that should be on the scoreboard
        /// </summary>
        /// <returns>An IList of the players</returns>
        IList<IPlayer> GetAll();

        /// <summary>
        /// A method for registering a new player on the scoreboard
        /// </summary>
        /// <param name="player">The player to be registered</param>
        void RegisterNewPlayerScore(IPlayer player);
    }
}
