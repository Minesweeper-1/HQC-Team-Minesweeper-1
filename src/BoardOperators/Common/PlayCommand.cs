namespace Minesweeper.BoardOperators.Common
{
    using Contracts;
    using Boards.Contracts;
    using Renderers.Contracts;
    using Minesweeper.Common;

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
            string trimmedCommand = command.Trim();
            string[] commandComponents = trimmedCommand.Split(GlobalConstants.CommandParametersDivider);
            if (commandComponents.Length < 2 || commandComponents.Length > 2)
            {
                this.renderer.RenderLine(GlobalMessages.InvalidCommand);
                this.board.ChangeBoardState(BoardState.Pending);
                return;
            }

            int x, y;
            bool xIsNumeric = int.TryParse(commandComponents[0], out x);
            bool yIsNumeric = int.TryParse(commandComponents[1], out y);

            this.renderer.ClearCurrentConsoleLine();
            if (!(xIsNumeric && yIsNumeric))
            {
                this.renderer.RenderLine(GlobalMessages.InvalidCommand);
                this.board.ChangeBoardState(BoardState.Pending);
                return;
            }

            if (!this.board.IsInsideBoard(x, y))
            {
                this.renderer.RenderLine(GlobalMessages.OutOfBorders);
            }
            else if (this.board.IsAlreadyShown(x, y))
            {
                this.renderer.RenderLine(GlobalMessages.CellAlreadyRevealed);
            }

            else if (this.board.IsBomb(x, y))
            {
                this.renderer.RenderLine(GlobalMessages.GameOver);
                this.board.ChangeBoardState(BoardState.Closed);
                return;
            }

            else
            {
                this.board.RevealCell(x, y);
                this.renderer.Clear();
            }

            this.board.ChangeBoardState(BoardState.Open);
        }
    }
}
