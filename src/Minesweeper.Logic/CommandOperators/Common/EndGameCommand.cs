namespace Minesweeper.Logic.CommandOperators.Common
{
    using Boards.Contracts;
    using Contracts;
    using Minesweeper.Logic.Common;

    public class EndGameCommand : IBoardCommand
    {
        private readonly IBoard board;

        public EndGameCommand(IBoard board)
        {
            this.board = board;
        }

        public void Execute(string command) => 
            this.board.ChangeBoardState(new Notification(GlobalMessages.GameOver, BoardState.Closed));
    }
}
