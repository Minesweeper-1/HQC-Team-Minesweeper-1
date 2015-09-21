namespace Minesweeper.Players
{
    using Contracts;
    using System;

    public class Player : IPlayer, IComparable
    {
        public Player()
        {

        }

        public Player(string name, int score)
        {
            this.Name = name;
            this.Score = score;
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

        public int CompareTo(object anotherPlayerAsObject)
        {
            var anotherPlayer = anotherPlayerAsObject as IPlayer;
            if(anotherPlayer.Score > this.Score)
            {
                return 1;
            }
            else if(anotherPlayer.Score > this.Score)
            {
                return -1;
            }
            else
            {
                return string.Compare(anotherPlayer.Name, this.Name);
            }
        }
    }
}
