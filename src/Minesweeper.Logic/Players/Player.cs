namespace Minesweeper.Logic.Players
{
    using Contracts;

    /// <summary>
    /// A class implementing the Player logic
    /// </summary>
    public class Player : IPlayer
    {
        // Needed for the parsing of objects from the deserialization for the scoreboard
        /// <summary>
        /// The player empty constructor
        /// </summary>
        public Player()
        {
            this.Name = string.Empty;
            this.Score = default(int);
        }

        /// <summary>
        /// Player constructor setting player name and score
        /// </summary>
        /// <param name="name">The name of the player</param>
        public Player(string name)
            : this()
        {
            this.Name = name;
            this.Score = default(int);
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
