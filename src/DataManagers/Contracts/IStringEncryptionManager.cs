namespace Minesweeper.DataManagers.Contracts
{
    public interface IStringEncryptionManager
    {
        string Encrypt(string key, string source);

        string Decrypt(string key, string source);
    }
}
