namespace Minesweeper.Logic.DifficultyCommands
{
    using System.Linq;

    using Boards.Settings.Contracts;
    using Common.Utils;
    using Contracts;

    /// <summary>
    /// A class implementing the IGameMode interface for the expert mode option
    /// </summary>
    public class ExpertMode : IGameMode
    {
        /// <summary>
        /// Expert mode value
        /// </summary>
        public string Value { get; } = nameof(ExpertMode).SplitByUpperCase().First();

        /// <summary>
        /// Expert mode settings
        /// </summary>
        public BoardSettings Settings => new HardBoardSettings();

        /// <summary>
        /// A method returning a beginner game mode
        /// </summary>
        /// <returns>A beginner game mode</returns>
        public IGameMode GetNext() => new BeginnerMode();

        /// <summary>
        /// A method returning an intermediate game mode
        /// </summary>
        /// <returns>An intermediate game mode</returns>
        public IGameMode GetPrevious() => new IntermediateMode();
    }
}
