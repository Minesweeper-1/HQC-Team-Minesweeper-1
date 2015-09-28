namespace Minesweeper.DifficultyCommands
{
    using System.Linq;

    using Common.Utils;
    using Contracts;

    public class BeginnerMode : IGameMode
    {
        public string Value { get; } = nameof(BeginnerMode).SplitByUpperCase().First();

        public IGameMode GetNext() => new IntermediateMode();

        public IGameMode GetPrevious() => new ExpertMode();
    }
}
