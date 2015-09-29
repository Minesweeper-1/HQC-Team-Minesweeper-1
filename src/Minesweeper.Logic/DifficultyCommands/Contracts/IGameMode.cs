namespace Minesweeper.Logic.DifficultyCommands.Contracts
{
    public interface IGameMode
    {
        string Value { get; }

        IGameMode GetNext();

        IGameMode GetPrevious();
    }
}
