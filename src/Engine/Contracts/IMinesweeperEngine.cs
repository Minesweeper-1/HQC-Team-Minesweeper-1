namespace Minesweeper.Engine.Contracts
{
    public interface IMinesweeperEngine : IBoardObserver
    {
        void Initialize(IGameInitializationStrategy initializationStrategy);

        void Run();
    }
}
