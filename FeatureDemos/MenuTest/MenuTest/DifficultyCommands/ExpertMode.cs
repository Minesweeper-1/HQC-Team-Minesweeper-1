namespace MenuTest.DifficultyCommands
{
    using Contracts;

    public class ExpertMode : IGameMode
    {
        public string Value { get; } = nameof(ExpertMode);

        public IGameMode GetNext() => new BeginnerMode();

        public IGameMode GetPrevious() => new IntermediateMode();
    }
}
