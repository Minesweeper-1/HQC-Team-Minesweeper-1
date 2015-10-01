namespace Minesweeper.Logic.DifficultyCommands
{
    using System.Linq;

    using Common.Utils;
    using Contracts;

    using Minesweeper.Logic.Boards;

    public class IntermediateMode : IGameMode
    {
        public string Value { get; } = nameof(IntermediateMode).SplitByUpperCase().First();

        public IGameMode GetNext() => new ExpertMode();

        public BoardSettings Settings => new NormalBoardSettings();

        public IGameMode GetPrevious() => new BeginnerMode();
    }
}
