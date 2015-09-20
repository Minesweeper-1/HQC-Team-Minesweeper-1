namespace Minesweeper.BoardOperators
{
    using Contracts;
    using Common;
    using Boards.Contracts;
    using Renderers.Contracts;

    public class BoardOperator : IBoardOperator
    {
        public BoardOperator(IBoard board, IRenderer renderer)
        {
            this.Board = board;
            this.Renderer = renderer;
        }

        public IBoard Board
        {
            get;
            private set;
        }

        public IRenderer Renderer
        {
            get;
            private set;
        }

        public void ExecuteCommand(string command)
        {
            string commandToLowerCase = command.ToLower();
            switch (commandToLowerCase)
            {
                case "exit":
                    this.HandleEndGameCommand();
                    break;
                case "top":
                    this.HandleShowTopScoresCommand();
                    break;
                case "restart":
                    this.HandleRestartCommand();
                    break;
                default:
                    this.HandlePlayCommand(commandToLowerCase);
                    break;
            }
        }

        private void HandlePlayCommand(string command)
        {
            string trimmedCommand = command.Trim();
            string[] commandComponents = trimmedCommand.Split(GlobalConstants.CommandParametersDivider);
            if (commandComponents.Length < 2 || commandComponents.Length > 2)
            {
                this.Renderer.RenderLine(GlobalMessages.InvalidCommand);
                this.Board.ChangeBoardState(BoardState.Pending);
                return;
            }

            int x, y;
            bool xIsNumeric = int.TryParse(commandComponents[0], out x);
            bool yIsNumeric = int.TryParse(commandComponents[1], out y);

            this.Renderer.ClearCurrentConsoleLine();
            if (!(xIsNumeric && yIsNumeric))
            {
                this.Renderer.RenderLine(GlobalMessages.InvalidCommand);
                this.Board.ChangeBoardState(BoardState.Pending);
                return;
            }

            if (!this.Board.IsInsideBoard(x, y))
            {
                this.Renderer.RenderLine(GlobalMessages.OutOfBorders);
            }
            else if (this.Board.IsAlreadyShown(x, y))
            {
                this.Renderer.RenderLine(GlobalMessages.CellAlreadyRevealed);
            }

            else if (this.Board.IsBomb(x, y))
            {
                this.Renderer.RenderLine(GlobalMessages.GameOver);
                this.Board.ChangeBoardState(BoardState.Closed);
                return;
            }

            else
            {
                this.Board.RevealCell(x, y);
                this.Renderer.Clear();
            }

            this.Board.ChangeBoardState(BoardState.Open);
        }

        private void HandleRestartCommand()
        {
            this.Board.ChangeBoardState(BoardState.Open);
        }

        private void HandleShowTopScoresCommand()
        {
            this.Board.ChangeBoardState(BoardState.Pending);
        }

        private void HandleEndGameCommand()
        {
            this.Board.ChangeBoardState(BoardState.Closed);
        }
    }
}