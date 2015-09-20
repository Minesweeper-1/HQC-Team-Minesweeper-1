namespace Minesweeper.BoardOperators.Common
{
    using Contracts;
    using Boards.Contracts;
    using Minesweeper.Common;

    public class EndGameCommand : IBoardCommand
    {
        private readonly IBoard board;

        public EndGameCommand(IBoard board)
        {
            this.board = board;
        }

        public void Execute(string commandText)
        {
            this.board.ChangeBoardState(BoardState.Closed);
        }
    }
}
