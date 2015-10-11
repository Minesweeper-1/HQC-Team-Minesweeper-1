namespace Minesweeper.Logic.Players
{
    using Contracts;

    /// <summary>
    /// A class implementing the IPlayer logic
    /// </summary>
    public class Player : IPlayer
    {
        // Needed for the parsing of objects from the deserialization for the scoreboard

        /// <summary>
        /// Default player constructor
        /// </summary>
        public Player()
        {
            this.Name = string.Empty;
            this.Score = default(int);
        }

        /// <summary>
        /// Player constructor with name and default score
        /// </summary>
        /// <param name="name">The name of the player</param>
        public Player(string name)
            : this()
        {
            this.Name = name;
            this.Score = default(int);
        }

        /// <summary>
        /// Player name
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Player score
        /// </summary>
        public int Score
        {
            get;
            set;
        }
    }
}
