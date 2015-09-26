namespace Minesweeper.Players
{
    using Contracts;

    public class Player : IPlayer
    {
        public Player()
        {
            this.Score = 0;
        }

        public Player(string name)
            : this()
        {
            this.Name = name;
            this.Score = 0;
        }

        public string Name
        {
            get;
            set;
        }

        public int Score
        {
            get;
            set;
        }
    }
}
