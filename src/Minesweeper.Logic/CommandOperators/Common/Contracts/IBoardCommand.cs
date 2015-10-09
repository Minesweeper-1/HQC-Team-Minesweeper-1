namespace Minesweeper.Logic.CommandOperators.Common.Contracts
{
    /// <summary>
    /// Interface containing the common base method for the different commands that can be applied to the board
    /// </summary>
    public interface IBoardCommand
    {
        void Execute(string command = "");
    }
}
