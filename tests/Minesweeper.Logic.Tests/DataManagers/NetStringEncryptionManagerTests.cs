// <copyright file="NetStringEncryptionManagerTests.cs" company="Team Minesweeper-1">
// Copyright (c) The team. All rights reserved.
// </copyright>
namespace Minesweeper.Logic.Tests.DataManagers
{
    using Logic.DataManagers;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Test class for the NetStringEncryptionManager class
    /// </summary>
    [TestClass]
    public class NetStringEncryptionManagerTests
    {
        /// <summary>
        /// Testing encrypt and decrypt functionality
        /// </summary>
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
