namespace Minesweeper.Logic.CommandOperators.Common
{
    using Boards.Contracts;
    using Contracts;
    using PlayCommandHandlers;

    public class PlayCommand : IBoardCommand
    {
        private readonly IBoard board;

        public PlayCommand(IBoard board)
        {
            this.board = board;
        }

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
