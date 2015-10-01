namespace Minesweeper.Logic.Engines.Contracts
{
    using Boards.Contracts;

    public interface IMinesweeperEngine : IBoardObserver
    {
        void Initialize(IGameInitializationStrategy initializationStrategy);

        void Run();
    }
}
