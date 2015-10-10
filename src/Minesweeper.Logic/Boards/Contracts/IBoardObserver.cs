namespace Minesweeper.Logic.Boards.Contracts
{
    using Common;

    /// <summary>
    /// Interface of the board observer, defining an Update method
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
