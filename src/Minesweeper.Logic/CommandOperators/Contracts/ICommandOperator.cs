namespace Minesweeper.Logic.CommandOperators.Contracts
{
    /// <summary>
    /// An interface containing the common Execute() method for all inheriting classes to implement
    /// </summary>
    public interface ICommandOperator
    {
        void Execute(string command);
    }
}
