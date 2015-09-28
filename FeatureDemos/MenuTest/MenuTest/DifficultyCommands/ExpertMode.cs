namespace MenuTest.DifficultyCommands
{
    using System.Linq;
    
    using Common;
    using Contracts;

    public class ExpertMode : IGameMode
    {
        public string Value { get; } = nameof(ExpertMode).SplitByUpperCase().First();

        public IGameMode GetNext() => new BeginnerMode();

        public IGameMode GetPrevious() => new IntermediateMode();
    }
}
