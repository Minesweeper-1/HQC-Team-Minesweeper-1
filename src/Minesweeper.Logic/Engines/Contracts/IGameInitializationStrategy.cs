namespace Minesweeper.Logic.Engines.Contracts
{
    using Boards.Contracts;

    /// <summary>
    /// An interface providing a board-initializing method
    /// </summary>
    public interface IGameInitializationStrategy
    {
        /// <summary>
        /// A method for board initialization of a given board
        /// </summary>
        /// <param name="board">The playing board to be initialized</param>
        IBoard Initialize(IBoard board);
    }
}
