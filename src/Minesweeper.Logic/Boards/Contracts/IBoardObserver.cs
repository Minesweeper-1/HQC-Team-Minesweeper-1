namespace Minesweeper.Logic.Boards.Contracts
{
    using Common;

    public interface IBoardObserver
    {
        void Update(Notification notification);
    }
}
