namespace Minesweeper.Logic.DataManagers
{
    using System.IO;

    using Contracts;

    public class FileReader : IReader
    {
        public string ReadAllText(string source) => File.ReadAllText(source);
    }
}
