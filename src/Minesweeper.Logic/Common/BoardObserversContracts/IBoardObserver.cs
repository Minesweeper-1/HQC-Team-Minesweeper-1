namespace Minesweeper.Logic.Common.BoardObserverContracts
{
    using Common;

    public interface IBoardObserver
    {
        void Update(Notification notification);
    }
}
