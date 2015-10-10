namespace Minesweeper.Logic.Players.Contracts
{
    /// <summary>
    /// An interface defining an IPlayer by name and score
    /// </summary>
    public interface IPlayer
    {
        string Name
        {
            get;
        }

        int Score
        {
            get;
            set;
        }
    }
}
