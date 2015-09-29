namespace Minesweeper.UI.Console.Engine.Contracts
{
    using Minesweeper.Logic.Common.BoardObserverContracts;

    public interface IMinesweeperEngine : IBoardObserver
    {
        void Initialize(IGameInitializationStrategy initializationStrategy);

        void Run();
    }
}
