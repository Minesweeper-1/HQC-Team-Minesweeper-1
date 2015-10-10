namespace Minesweeper.Logic.Engines.Contracts
{
    using Boards.Contracts;

    /// <summary>
    /// An interface providing Initialize and Run methods for an application engine
    /// </summary>
    public interface IMinesweeperEngine : IBoardObserver
    {
        /// <summary>
        /// A method initializing a given initialization strategy
        /// </summary>
        /// <param name="initializationStrategy">The strategy to be initialized</param>
        void Initialize(IGameInitializationStrategy initializationStrategy);

        /// <summary>
        /// The method running the game engine
        /// </summary>
        void Run();
    }
}
