namespace Minesweeper.DataManagers
{
    using System.IO;

    using Contracts;

    public class FileWriter : IWriter
    {
        public FileWriter()
        {

        }

        public void WriteAllText(string path, string contents)
        {
            File.WriteAllText(path, contents);
        }

        public void WriteLine(string path, string contents)
        {
            using (StreamWriter file =
            new StreamWriter(path, append: true))
            {
                file.WriteLine(contents);
            }
        }
    }
}
