namespace Minesweeper.Logic.CommandOperators.Common.Contracts
{
    /// <summary>
    /// Defines an interface for all public members of board commands that could be applied
    ///</summary>
    public interface IBoardCommand
    {
        /// <summary>
        /// Defines a method for executing a command
        /// </summary>
        /// <param name="command"></param>
        void Execute(string command = "");
    }
}
