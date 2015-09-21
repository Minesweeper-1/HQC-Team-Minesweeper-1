namespace Minesweeper.DataManagers.Contracts
{
    public interface IReader
    {
        string ReadAllText(string source);

        //string[] ReadAllLines(string source);
    }
}
