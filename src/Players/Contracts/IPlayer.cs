namespace Minesweeper.Players.Contracts
{
    public interface IPlayer
    {
        string Name
        {
            get;
            set;
        }

        int Score
        {
            get;
            set;
        }
    }
}
