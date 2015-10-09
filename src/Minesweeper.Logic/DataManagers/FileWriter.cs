namespace Minesweeper.Logic.DataManagers
{
    using System.IO;

    using Contracts;

    /// <summary>
    /// A class providing an implementation of the IWriter interface
    /// </summary>
    public class FileWriter : IWriter
    {
        /// <summary>
        /// A method writing all text from a given string to a given path
        /// </summary>
        /// <param name="path">The path to write to</param>
        /// <param name="contents">The string to be written</param>
        public void WriteAllText(string path, string contents) => File.WriteAllText(path, contents);
    }
}
