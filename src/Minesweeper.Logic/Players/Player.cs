namespace Minesweeper.Logic.Players
{
    using Contracts;

    public class Player : IPlayer
    {
        // Needed for the parsing of objects from the deserialization for the scoreboard
        public Player()
        {
            this.Name = string.Empty;
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
