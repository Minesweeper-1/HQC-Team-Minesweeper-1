namespace Minesweeper.DataManagers
{
    using System.IO;

    using Contracts;

    public class FileReader : IReader
    {
        public FileReader()
        {
        }

        public string ReadAllText(string source) => File.ReadAllText(source);
    }
}
