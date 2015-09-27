namespace MenuTest.DifficultyCommands
{
    using Contracts;

    public class BeginnerMode : IGameMode
    {
        public string Value { get; } = nameof(BeginnerMode);

        public IGameMode GetNext() => new IntermediateMode();

        public IGameMode GetPrevious() => new ExpertMode();
    }
}
