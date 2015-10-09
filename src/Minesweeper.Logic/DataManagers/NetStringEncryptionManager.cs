namespace Minesweeper.Logic.DataManagers
{
    using Contracts;
    using KellermanSoftware.NetEncryptionLibrary;

    /// <summary>
    /// A class providing implementation of the IStringEncryptionManager interface
    /// </summary>
    public class NetStringEncryptionManager : IStringEncryptionManager
    {
        private readonly Encryption netEncryption = new Encryption();

        /// <summary>
        /// The base method for encrypting given string using given key
        /// </summary>
        /// <param name="key">The key for the encryption</param>
        /// <param name="source">The string to be encrypted</param>
        /// <returns>The encrypted string</returns>
        public string Encrypt(string key, string source)
        {
            string result = netEncryption.EncryptString(EncryptionProvider.Rijndael, key, source);
            return result;
        }

        /// <summary>
        /// The base method for decrypting given string using given key
        /// </summary>
        /// <param name="key">The key for the decryption</param>
        /// <param name="source">The string to be decrypted</param>
        /// <returns>The decrypted string</returns>
        public string Decrypt(string key, string source)
        {
            string result = netEncryption.DecryptString(EncryptionProvider.Rijndael, key, source);
            return result;
        }
    }
}
