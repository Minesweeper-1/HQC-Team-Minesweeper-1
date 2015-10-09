namespace Minesweeper.Logic.CommandOperators.Common.PlayCommandHandlers.Contracts
{
    using Boards.Contracts;

    public abstract class PlayCommandHandler
    {
        /// <summary>
        /// Abstract class for the Play command handler
        /// </summary>
        protected PlayCommandHandler Successor
        {
            get;
            private set;
        }

        /// <summary>
        /// Method for setting a successor to handle the request
        /// </summary>
        /// <param name="successorToSet">Successor of the type PlayCommandHandler</param>
        public void SetSuccessor(PlayCommandHandler successorToSet)
        {
            this.Successor = successorToSet;
        }

        /// <summary>
        /// One of the overloads of the request handler method, taking row, col and board as parameters
        /// </summary>
        /// <param name="row">The row of the cell</param>
        /// <param name="col">The column of the cell</param>
        /// <param name="board">The current playing board</param>
        public virtual void HandleRequest(int row, int col, IBoard board)
        {
        }

        /// <summary>
        /// One of the overloads of the request handler method, taking command (as a string) and board as parameters
        /// </summary>
        /// <param name="command">String containing the command</param>
        /// <param name="board">The current playing board</param>
        public virtual void HandleRequest(string command, IBoard board)
        {
        }
    }
}
