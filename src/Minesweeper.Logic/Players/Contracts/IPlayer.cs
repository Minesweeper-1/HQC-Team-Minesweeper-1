namespace Minesweeper.Logic.Players.Contracts
{
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
