namespace Minesweeper.Logic.DataManagers.Contracts
{
    public interface IJsonManager
    {
        T Parse<T>(string jsonValue);

        string ToStringRepresentation<T>(T jsonObject);
    }
}
