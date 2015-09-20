namespace Minesweeper.BoardOperators.Common
{
    using Contracts;
    using Boards.Contracts;

    public class ShowScoreboardCommand : IBoardCommand
    {
        private readonly IBoard board;
        
        public ShowScoreboardCommand(IBoard board)
        {
            this.board = board;
        }

        public void Execute(string commandText)
        {
            // TODO: Implement Show Scoreboard command
        }
    }
}
