namespace Minesweeper.Logic.DataManagers
{
    using System.IO;

    using Contracts;

    /// <summary>
    /// Class implementing the IReader interface providing an implementation of the ReadAllText() method
    /// </summary>
    public class FileReader : IReader
    {
        /// <summary>
        /// A method reading all text from a source and returning it as a string
        /// </summary>
        /// <param name="source">The text to be read</param>
        /// <returns>The read text</returns>
        public string ReadAllText(string source) => File.ReadAllText(source);
    }
}
