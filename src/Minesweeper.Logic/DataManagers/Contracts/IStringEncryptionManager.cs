namespace Minesweeper.Logic.DataManagers.Contracts
{
    /// <summary>
    /// An interface providing methods for encrypting and decrypting given string using given key
    /// </summary>
    public interface IStringEncryptionManager
    {
        /// <summary>
        /// The base method for encrypting given string using given key
        /// </summary>
        /// <param name="key">The key for the encryption</param>
        /// <param name="source">The string to be encrypted</param>
        /// <returns>The encrypted string</returns>
        string Encrypt(string key, string source);

        /// <summary>
        /// The base method for decrypting given string using given key
        /// </summary>
        /// <param name="key">The key for the decryption</param>
        /// <param name="source">The string to be decrypted</param>
        /// <returns>The decrypted string</returns>
        string Decrypt(string key, string source);
    }
}
