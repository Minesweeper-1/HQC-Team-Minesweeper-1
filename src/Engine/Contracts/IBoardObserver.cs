namespace Minesweeper.Engine.Contracts
{
    using Common;

    public interface IBoardObserver
    {
        void Update(BoardState boardState);
    }
}
