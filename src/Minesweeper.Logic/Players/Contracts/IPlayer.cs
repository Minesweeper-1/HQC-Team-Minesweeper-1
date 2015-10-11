namespace Minesweeper.Logic.Players.Contracts
{
    /// <summary>
    /// Defines all Player public members
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Name
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// Score
        /// </summary>
        int Score
        {
            get;
            set;
        }
    }
}
