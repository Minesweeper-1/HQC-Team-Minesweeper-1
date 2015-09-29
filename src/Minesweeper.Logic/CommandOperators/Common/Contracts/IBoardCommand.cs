namespace Minesweeper.Logic.CommandOperators.Common.Contracts
{
    public interface IBoardCommand
    {
        void Execute(string command = "");
    }
}
