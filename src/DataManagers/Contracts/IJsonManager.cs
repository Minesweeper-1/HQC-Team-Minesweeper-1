namespace Minesweeper.DataManagers.Contracts
{
    public interface IJsonManager
    {
        T Parse<T>(string jsonString);

        string Stringify<T>(T jsonObject);
    }
}
