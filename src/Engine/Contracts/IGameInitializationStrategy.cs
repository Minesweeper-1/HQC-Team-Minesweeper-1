namespace Minesweeper.Engine.Contracts
{
    using Boards.Contracts;

    public interface IGameInitializationStrategy
    {
        void Initialize(IBoard board);
    }
}
