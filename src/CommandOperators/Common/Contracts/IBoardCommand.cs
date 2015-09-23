namespace Minesweeper.CommandOperators.Common.Contracts
{
    public interface IBoardCommand
    {
        void Execute(string command = "");
    }
}
