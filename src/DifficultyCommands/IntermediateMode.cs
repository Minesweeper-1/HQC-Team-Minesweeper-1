namespace Minesweeper.DifficultyCommands
{
    using System.Linq;

    using Common.Utils;
    using Contracts;

    public class IntermediateMode : IGameMode
    {
        public string Value { get; } = nameof(IntermediateMode).SplitByUpperCase().First();

        public IGameMode GetNext() => new ExpertMode();

        public IGameMode GetPrevious() => new BeginnerMode();
    }
}
