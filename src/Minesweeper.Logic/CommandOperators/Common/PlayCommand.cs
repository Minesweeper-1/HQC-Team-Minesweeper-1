namespace Minesweeper.Logic.CommandOperators.Common
{
    using Boards.Contracts;
    using Contracts;
    using PlayCommandHandlers;

    /// <summary>
    /// A class dealing with the play command implementing the IBoardCommand interface
    /// </summary>
    public class PlayCommand : IBoardCommand
    {
        /// <summary>
        /// The board to execute a command on
        /// </summary>
        private readonly IBoard board;

        /// <summary>
        /// Creates a PlayCommand instance
        /// </summary>
        /// <param name="board">The current playing board</param>
        public PlayCommand(IBoard board)
        {
            this.board = board;
        }

        /// <summary>
        /// The concrete implementation of the common method Execute setting up all handlers and successors
        /// and calling the first fro their chain
        /// </summary>
        /// <param name="command">The command to be executed</param>
        public void Execute(string command)
        {
            var isValidPlayCommandHandler = new IsValidPlayCommandHandler();
            var isInsideBoardHandler = new IsInsideBoardHandler();
            var isAlreadyShownHandler = new IsAlreadyShownHandler();
            var isBombHandler = new IsBombHandler();
            var revealCellHandler = new RevealCellHandler();

            isValidPlayCommandHandler.SetSuccessor(isInsideBoardHandler);
            isInsideBoardHandler.SetSuccessor(isAlreadyShownHandler);
            isAlreadyShownHandler.SetSuccessor(isBombHandler);
            isBombHandler.SetSuccessor(revealCellHandler);

            isValidPlayCommandHandler.HandleRequest(command, this.board);            
        }
    }
}
