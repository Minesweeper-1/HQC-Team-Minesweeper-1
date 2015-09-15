namespace Minesweeper.Players
{
    using Contracts;

    public class Player : IPlayer
    {
        public Player(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }

        public string Name
        {
            get;
            private set;
        }

        public int Score
        {
            get;
            private set;
        }
    }
}
