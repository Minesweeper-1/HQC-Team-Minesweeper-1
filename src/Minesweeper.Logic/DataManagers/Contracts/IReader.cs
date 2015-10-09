namespace Minesweeper.Logic.DataManagers.Contracts
{
    /// <summary>
    /// An interface providing a common text-reading method
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// A method for reading the text from a string source
        /// </summary>
        /// <param name="source">The string to be read</param>
        /// <returns>The text read from the string</returns>
        string ReadAllText(string source);
    }
}
