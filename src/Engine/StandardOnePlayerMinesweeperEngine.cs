namespace Minesweeper.Engine
{
    using Boards.Contracts;
    using Common;
    using Contracts;
    using InputProviders.Contracts;
    using Renderers.Contracts;

    public class StandardOnePlayerMinesweeperEngine : IMinesweeperEngine
    {
        public StandardOnePlayerMinesweeperEngine(IBoard board, IRenderer renderer, IInputProvider inputProvider)
        {
            this.Board = board;
            this.Renderer = renderer;
            this.InputProvider = inputProvider;
            this.GameState = GameState.Running;
        }

        public IBoard Board { get; set; }

        public IRenderer Renderer { get; set; }

        public IInputProvider InputProvider { get; set; }

        public GameState GameState { get; set; }

        public void Initialize(IGameInitializationStrategy initializationStrategy)
        {
            initializationStrategy.Initialize(this.Board);
        }

        // TODO: Extract these magic coordinates
        public void Run()
        {
            int boardStartRenderX = 5;
            int boardStartRenderY = 5;
            string welcomeLine = "Welcome to the all-time classic Minesweeper. Use your mind to tackle the mines.";
            this.Renderer.RenderLine(welcomeLine);
            this.Renderer.RenderBoard(this.Board, boardStartRenderX, boardStartRenderY);
            this.Renderer.SetCursorPosition(boardStartRenderX + this.Board.Rows + 1, 0);

            while (true)
            {
                string command = this.InputProvider.Read();
                this.ExecuteCommand(command);

                if (this.GameState == GameState.Terminated)
                {
                    return;
                }
                else if (this.GameState == GameState.Continue)
                {
                    continue;
                }
                else if (this.GameState == GameState.Running)
                {
                    this.Renderer.RenderBoard(this.Board, boardStartRenderX, boardStartRenderY);
                    this.Renderer.SetCursorPosition(boardStartRenderX + this.Board.Rows + 1, 0);
                }

                this.Renderer.ClearCurrentConsoleLine();
            }
        }

        private void ExecuteCommand(string command)
        {
            string commandToLowerCase = command.ToLower();
            switch (commandToLowerCase)
            {
                case "exit":
                    HandleEndGameCommand();
                    break;
                case "top":
                    HandleShowTopScoresCommand();
                    break;
                case "restart":
                    HandleRestartCommand();
                    break;
                default:
                    HandlePlayCommand(commandToLowerCase);
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
                this.GameState = GameState.Continue;
                return;
            }

            int x, y;
            bool xIsNumeric = int.TryParse(commandComponents[0], out x);
            bool yIsNumeric = int.TryParse(commandComponents[1], out y);

            this.Renderer.ClearCurrentConsoleLine();
            if (!(xIsNumeric && yIsNumeric))
            {
                this.Renderer.RenderLine(GlobalMessages.InvalidCommand);
                this.GameState = GameState.Continue;
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
                this.GameState = GameState.Terminated;
                return;
            }

            else
            {
                this.Board.RevealCell(x, y);
                this.Renderer.Clear();
            }

            this.GameState = GameState.Running;
        }

        private void HandleRestartCommand()
        {
            this.GameState = GameState.Running;
        }

        private void HandleShowTopScoresCommand()
        {
            this.GameState = GameState.Continue;
        }

        private void HandleEndGameCommand()
        {
            this.GameState = GameState.Terminated;
        }
    }
}
