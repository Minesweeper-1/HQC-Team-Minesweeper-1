namespace Minesweeper.Logic.Common
{
    /// <summary>
    /// An enumeration containing the possible states of the playing board
    /// </summary>
    public enum BoardState
    {
        /// <summary>
        /// Describes a valid board request
        /// </summary>
        Open,

        /// <summary>
        /// Describes a pending board state, i.e waiting for next command
        /// </summary>
        Pending,

        /// <summary>
        /// Describes end of game board request
        /// </summary>
        Closed,

        /// <summary>
        /// Describes a restart request of the game
        /// </summary>
        Reset
    }
}
