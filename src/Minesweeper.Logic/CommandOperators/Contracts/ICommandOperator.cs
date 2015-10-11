namespace Minesweeper.Logic.CommandOperators.Contracts
{
    /// <summary>
    /// An interface containing the common Execute() method for all inheriting classes to implement
    /// </summary>
    public interface ICommandOperator
    {
        /// <summary>
        /// Executes logic for handling a game command
        /// </summary>
        /// <param name="command">Command to handle</param>
        void Execute(string command);
    }
}
