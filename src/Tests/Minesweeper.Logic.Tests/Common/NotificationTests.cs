namespace Minesweeper.Logic.Tests.Common
{
    using Logic.Common;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Testclass for the Notification class
    /// </summary>
    [TestClass]
    public class NotificationTests
    {
        [TestMethod]
        public void NotificationShouldContainMessageAndState()
        {
            var testNotification = new Notification(message: "testMessage", state: BoardState.Open);
            Assert.AreEqual(expected: "testMessage", actual: testNotification.Message);
            Assert.AreEqual(BoardState.Open, testNotification.State);
        }
    }
}