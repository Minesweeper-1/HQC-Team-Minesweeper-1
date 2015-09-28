namespace Minesweeper.DifficultyCommands
{
    using System.Linq;
    
    using Common.Utils;
    using Contracts;

    public class ExpertMode : IGameMode
    {
        public string Value { get; } = nameof(ExpertMode).SplitByUpperCase().First();

        public IGameMode GetNext() => new BeginnerMode();

        public IGameMode GetPrevious() => new IntermediateMode();
    }
}
