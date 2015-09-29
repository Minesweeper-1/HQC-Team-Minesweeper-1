namespace Minesweeper.Logic.Common
{
    public class Notification
    {
        public Notification(string message, BoardState state)
        {
            this.Message = message;
            this.State = state;
        }

        public string Message
        {
            get;
            private set;
        }

        public BoardState State
        {
            get;
            private set;
        }
    }
}
