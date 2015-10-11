namespace Minesweeper.Logic.Tests.Common
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Logic.Common;

    /// <summary>
    /// Testclass for the Notification class
    /// </summary>
    [TestClass]
    public class NotificationTests
    {
        [TestMethod]
        public void NotificationShouldContainMessageAndState()
        {
            var testNotification = new Notification("testMessage", BoardState.Open);
            Assert.AreEqual("testMessage", testNotification.Message);
            Assert.AreEqual(BoardState.Open, testNotification.State);
        }
    }
}