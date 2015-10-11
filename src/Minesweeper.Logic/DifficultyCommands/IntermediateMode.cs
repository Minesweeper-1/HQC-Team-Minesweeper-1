namespace Minesweeper.Logic.DifficultyCommands
{
    using System.Linq;

    using Boards.Settings.Contracts;
    using Common.Utils;
    using Contracts;

    /// <summary>
    /// A class implementing the IGameMode interface for the intermediate mode option
    /// </summary>
    public class IntermediateMode : IGameMode
    {
        /// <summary>
        /// Intermediate mode value
        /// </summary>
        public string Value { get; } = nameof(IntermediateMode).SplitByUpperCase().First();

        /// <summary>
        /// Intermediate mode settings
        /// </summary>
        public BoardSettings Settings => new NormalBoardSettings();


        /// <summary>
        /// A method returning an expert game mode
        /// </summary>
        /// <returns>An expert game mode</returns>
        public IGameMode GetNext() => new ExpertMode();
        
        /// <summary>
        /// A method returning a beginner game mode
        /// </summary>
        /// <returns>A beginner game mode</returns>
        public IGameMode GetPrevious() => new BeginnerMode();
    }
}
