namespace Minesweeper.BoardOperators.Common
{
    using Contracts;
    using Boards.Contracts;
    using Renderers.Contracts;

    public class ShowScoreboardCommand : IBoardCommand
    {
        private readonly IBoard board;
        private readonly IRenderer renderer;
        
        public ShowScoreboardCommand(IBoard board, IRenderer renderer)
        {
            this.board = board;
            this.renderer = renderer;
        }

        public void Execute(string commandText)
        {
            // TODO: Implement Show Scoreboard command
        }
    }
}
