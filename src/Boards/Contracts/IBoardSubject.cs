
namespace Minesweeper.Boards.Contracts
{
    using System.Collections.Generic;

    using Engine.Contracts;
    using Common;

    public interface IBoardSubject
    {
        IList<IBoardObserver> Subscribers
        {
            get;
        }

        void Subscribe(IBoardObserver boardObserverToSubscribe);

        void Unsubscribe(IBoardObserver boardObserverToUnsubscribe);

        void Notify(BoardState boardState);
    }
}
