namespace Minesweeper.Logic.Common.BoardObserverContracts
{
    using System.Collections.Generic;

    using Common;

    public interface IBoardSubject
    {
        IList<IBoardObserver> Subscribers
        {
            get;
        }

        void Subscribe(IBoardObserver boardObserverToSubscribe);

        void Unsubscribe(IBoardObserver boardObserverToUnsubscribe);

        void Notify(Notification newGameState);
    }
}
