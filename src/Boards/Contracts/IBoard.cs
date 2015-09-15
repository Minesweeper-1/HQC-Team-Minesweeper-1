namespace Minesweeper.Boards.Contracts
{
    public interface IBoard
    {
        void Display();

        void RevealCell(int x, int y);

        bool IsInsideTheField(int x, int y);

        bool IsMine(int x, int y);

        bool IsAlreadyShown(int x, int y);
    }
}
