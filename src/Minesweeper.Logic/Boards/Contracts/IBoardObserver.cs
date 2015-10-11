namespace Minesweeper.Logic.Boards.Contracts
{
    using Common;

    /// <summary>
    /// Defines the interface for a board observer public members
    /// </summary>
    public interface IBoardObserver
    {
        /// <summary>
        /// The update method of the board observer
        /// </summary>
        /// <param name="notification">Notification containing message and state</param>
        void Update(Notification notification);
    }
}
