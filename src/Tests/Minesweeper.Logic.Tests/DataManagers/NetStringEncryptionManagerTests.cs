namespace Minesweeper.Logic.Tests.DataManagers
{
    using Logic.DataManagers;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class NetStringEncryptionManagerTests
    {
        [TestMethod]
        public void EncryptAndDecryptOnSameKeyShouldReturnCorrectEncryptedString()
        {
            string key = "Pesho";
            string text = "Gosho";
            string expected = text;

            var cryptoManager = new NetStringEncryptionManager();
            string result = cryptoManager.Encrypt(key, text);
            string actual = cryptoManager.Decrypt(key, result);

            Assert.AreEqual(expected, actual);
        }
    }
}
