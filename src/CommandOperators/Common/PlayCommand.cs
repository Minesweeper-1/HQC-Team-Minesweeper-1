namespace Minesweeper.CommandOperators.Common
{
    using Boards.Contracts;
    using Contracts;
    using PlayCommandHandlers;
    using Renderers.Contracts;

    public class PlayCommand : IBoardCommand
    {
        private readonly IBoard board;
        private readonly IRenderer renderer;

        public PlayCommand(IBoard board, IRenderer renderer)
        {
            this.board = board;
            this.renderer = renderer;
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

            isValidPlayCommandHandler.HandleRequest(command, this.board, this.renderer);            
        }
    }
}
