namespace Minesweeper.BoardOperators.Common
{
    using Contracts;
    using Boards.Contracts;
    using global::Minesweeper.Common;

    public class RestartCommand : IBoardCommand
    {
        private readonly IBoard board;

        public RestartCommand(IBoard board)
        {
            this.board = board;
        }

        public void Execute(string command)
        {
            // TODO: Implement Restart command
        }
    }
}
