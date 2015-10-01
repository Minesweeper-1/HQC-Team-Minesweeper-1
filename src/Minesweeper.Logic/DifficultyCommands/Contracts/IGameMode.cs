namespace Minesweeper.Logic.DifficultyCommands.Contracts
{
    using Boards;

    public interface IGameMode
    {
        string Value { get; }

        BoardSettings Settings { get; }

        IGameMode GetNext();

        IGameMode GetPrevious();
    }
}
