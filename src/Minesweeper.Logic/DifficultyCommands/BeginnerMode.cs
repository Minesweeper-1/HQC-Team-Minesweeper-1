namespace Minesweeper.Logic.DifficultyCommands
{
    using System.Linq;
   
    using Boards.Settings.Contracts;
    using Common.Utils;
    using Contracts;

    /// <summary>
    /// A class implementing the IGameMode interface for the beginner mode option
    /// </summary>
    public class BeginnerMode : IGameMode
    {
        public string Value { get; } = nameof(BeginnerMode).SplitByUpperCase().First();

        public BoardSettings Settings => new EasyBoardSettings();

        /// <summary>
        /// A method returning an intermediate game mode
        /// </summary>
        /// <returns>An intermediate game mode</returns>
        public IGameMode GetNext() => new IntermediateMode();

        /// <summary>
        /// A method returning an expert game mode
        /// </summary>
        /// <returns>An expert game mode</returns>
        public IGameMode GetPrevious() => new ExpertMode();
    }
}
