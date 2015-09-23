namespace Minesweeper.DataManagers.Contracts
{
    public interface IWriter
    {
        void WriteAllText(string path, string contents);
    }
}
