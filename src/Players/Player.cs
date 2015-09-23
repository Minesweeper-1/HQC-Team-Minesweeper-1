namespace Minesweeper.Players
{
    using Contracts;
    using System;

    public class Player : IPlayer
    {
        public Player()
        {

        }

        public Player(string name)
        {
            this.Name = name;
            this.Score = 0;
        }

        public string Name
        {
            get;
            private set;
        }

        public int Score
        {
            get;
            set;
        }
    }
}
