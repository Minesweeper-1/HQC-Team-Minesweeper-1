namespace Minesweeper.CommandOperators.Common
{
    using Contracts;
    using Boards.Contracts;
    using global::Minesweeper.Common;

    public class EndGameCommand : IBoardCommand
    {
        private readonly IBoard board;

        public EndGameCommand(IBoard board)
        {
            this.board = board;
        }

        public void Execute(string command)
        {
            this.board.ChangeBoardState(BoardState.Closed);
        }
    }
}
