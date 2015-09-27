namespace MenuTest.DifficultyCommands
{
    using Contracts;

    public class IntermediateMode : IGameMode
    {
        public string Value { get; } = nameof(IntermediateMode);

        public IGameMode GetNext() => new ExpertMode();

        public IGameMode GetPrevious() => new BeginnerMode();
    }
}
