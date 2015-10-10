namespace Minesweeper.Logic.CommandOperators.Common
{
    using Boards.Contracts;
    using Contracts;

    /// <summary>
    /// 
    /// </summary>
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
