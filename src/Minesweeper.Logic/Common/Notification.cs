namespace Minesweeper.Logic.Common
{
    /// <summary>
    /// The class dealing with the notification initialization
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// Creates a notification object instance
        /// </summary>
        /// <param name="message">Notification message</param>
        /// <param name="state">Board state to notify</param>
        public Notification(string message, BoardState state)
        {
            this.Message = message;
            this.State = state;
        }

        /// <summary>
        /// Notification message
        /// </summary>
        public string Message
        {
            get;
            private set;
        }

        /// <summary>
        /// Notification board state
        /// </summary>
        public BoardState State
        {
            get;
            private set;
        }
    }
}
