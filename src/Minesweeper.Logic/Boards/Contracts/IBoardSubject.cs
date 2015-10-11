namespace Minesweeper.Logic.Boards.Contracts
{
    using System.Collections.Generic;

    using Common;

    /// <summary>
    /// Defines the interface for board subject public members
    /// </summary>
    public interface IBoardSubject
    {
        /// <summary>
        /// Collection of all board subscribers
        /// </summary>
        IList<IBoardObserver> Subscribers
        {
            get;
        }

        /// <summary>
        /// A method for subscribing a new board observer
        /// </summary>
        /// <param name="boardObserverToSubscribe">The board observer to be subscribed</param>
        void Subscribe(IBoardObserver boardObserverToSubscribe);

        /// <summary>
        /// A method for unsubscribing an existing board observer
        /// </summary>
        /// <param name="boardObserverToUnsubscribe">The board observer to be unsubscribed</param>
        void Unsubscribe(IBoardObserver boardObserverToUnsubscribe);

        /// <summary>
        /// A method for notifying the observers for changes in the game state
        /// </summary>
        /// <param name="newGameState">A notification, containing message and state</param>
        void Notify(Notification newGameState);
    }
}
