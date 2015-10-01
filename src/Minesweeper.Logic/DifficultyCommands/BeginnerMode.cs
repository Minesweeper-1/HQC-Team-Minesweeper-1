namespace Minesweeper.Logic.DifficultyCommands
{
    using System.Linq;

    using Common.Utils;
    using Contracts;

    using Minesweeper.Logic.Boards;

    public class BeginnerMode : IGameMode
    {
        public string Value { get; } = nameof(BeginnerMode).SplitByUpperCase().First();

        public BoardSettings Settings => new EasyBoardSettings();

        public IGameMode GetNext() => new IntermediateMode();

        public IGameMode GetPrevious() => new ExpertMode();
    }
}
