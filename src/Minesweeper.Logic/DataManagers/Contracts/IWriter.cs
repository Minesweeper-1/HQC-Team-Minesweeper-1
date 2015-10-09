namespace Minesweeper.Logic.DataManagers.Contracts
{
    /// <summary>
    /// An interface providing the common method for writing a string to a given path
    /// </summary>
    public interface IWriter
    {
        /// <summary>
        /// The common method for writing given string content to a given path
        /// </summary>
        /// <param name="path">The path the text should be written to</param>
        /// <param name="contents">The text to be written</param>
        void WriteAllText(string path, string contents);
    }
}
