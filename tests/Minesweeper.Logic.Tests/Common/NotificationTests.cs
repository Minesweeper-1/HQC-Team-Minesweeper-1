// <copyright file="NotificationTests.cs" company="Team Minesweeper-1">
// Copyright (c) The team. All rights reserved.
// </copyright>
namespace Minesweeper.Logic.Tests.Common
{
    using Logic.Common;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Test class for the Notification class
    /// </summary>
    [TestClass]
    public class NotificationTests
    {
        /// <summary>
        /// Testing notification creation
        /// </summary>
        [TestMethod]
        public void NotificationShouldContainMessageAndState()
        {
            var testNotification = new Notification(message: "testMessage", state: BoardState.Open);
            Assert.AreEqual(expected: "testMessage", actual: testNotification.Message);
            Assert.AreEqual(BoardState.Open, testNotification.State);
        }
    }
}