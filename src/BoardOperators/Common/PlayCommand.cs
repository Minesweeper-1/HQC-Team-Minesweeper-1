namespace Minesweeper.BoardOperators.Common
{
    using Contracts;
    using Boards.Contracts;
    using Renderers.Contracts;
    using global::Minesweeper.Common;
    using PlayCommandHandlers;

    public class PlayCommand : IBoardCommand
    {
        private readonly IBoard board;
        private readonly IRenderer renderer;

        public PlayCommand(IBoard board, IRenderer renderer)
        {
            this.board = board;
            this.renderer = renderer;
        }

        //TODO: Implement chain of responsibility pattern
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
