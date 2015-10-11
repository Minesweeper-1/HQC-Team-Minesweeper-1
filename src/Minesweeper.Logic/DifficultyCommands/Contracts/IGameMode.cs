namespace Minesweeper.Logic.DifficultyCommands.Contracts
{
    using Boards.Settings.Contracts;

    /// <summary>
    /// An interface providing the methods and properties for choosing of the board settings
    /// </summary>
    public interface IGameMode
    {
        /// <summary>
        /// Mode value
        /// </summary>
        string Value { get; }

        /// <summary>
        /// Mode settings
        /// </summary>
        BoardSettings Settings { get; }

        /// <summary>
        /// A method for getting the next board settings
        /// </summary>
        /// <returns>The corresponding IGameMode</returns>
        IGameMode GetNext();

        /// <summary>
        /// A method for getting the previous board settings
        /// </summary>
        /// <returns>The corresponding IGameMode</returns>
        IGameMode GetPrevious();
    }
}
