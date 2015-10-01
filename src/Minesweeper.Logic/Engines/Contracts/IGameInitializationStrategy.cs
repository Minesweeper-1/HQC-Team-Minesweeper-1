namespace Minesweeper.Logic.Engines.Contracts
{
    using Boards.Contracts;

    public interface IGameInitializationStrategy
    {
        void Initialize(IBoard board);
    }
}
