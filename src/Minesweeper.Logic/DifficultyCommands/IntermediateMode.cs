namespace Minesweeper.Logic.DifficultyCommands
{
    using System.Linq;

    using Boards.Settings.Contracts;
    using Common.Utils;
    using Contracts;

    public class IntermediateMode : IGameMode
    {
        public string Value { get; } = nameof(IntermediateMode).SplitByUpperCase().First();

        public IGameMode GetNext() => new ExpertMode();

        public BoardSettings Settings => new NormalBoardSettings();

        public IGameMode GetPrevious() => new BeginnerMode();
    }
}
