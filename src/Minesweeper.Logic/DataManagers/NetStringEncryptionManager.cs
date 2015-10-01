namespace Minesweeper.Logic.DataManagers
{
    using Contracts;
    using KellermanSoftware.NetEncryptionLibrary;

    public class NetStringEncryptionManager : IStringEncryptionManager
    {
        private readonly Encryption netEncryption = new Encryption();
        
        public string Encrypt(string key, string source)
        {
            string result = netEncryption.EncryptString(EncryptionProvider.Rijndael, key, source);
            return result;
        }

        public string Decrypt(string key, string source)
        {
            string result = netEncryption.DecryptString(EncryptionProvider.Rijndael, key, source);
            return result;
        }
    }
}
