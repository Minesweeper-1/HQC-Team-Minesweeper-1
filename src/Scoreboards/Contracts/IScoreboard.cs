namespace Minesweeper.Scoreboards.Contracts
{
    using System.Collections.Generic;
    
    using Players.Contracts;

    public interface IScoreboard
    {
        IList<IPlayer> GetAll();

        void RegisterNewPlayerScore(IPlayer player);
    }
}
