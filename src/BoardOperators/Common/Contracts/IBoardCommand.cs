namespace Minesweeper.BoardOperators.Common.Contracts
{
    public interface IBoardCommand
    {
        void Execute(string commandText = "");
    }
}
