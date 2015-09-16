namespace Minesweeper.Engine
{
    using System;

    using Boards.Contracts;
    using Contracts;
    using Renderers.Contracts;
    using InputProviders.Contracts;

    public class StandardOnePlayerMinesweeperEngine : IMinesweeperEngine
    {
        public StandardOnePlayerMinesweeperEngine(IBoard board, IRenderer renderer, IInputProvider inputProvider)
        {
            this.Board = board;
            this.Renderer = renderer;
            this.InputProvider = inputProvider;
        }

        public IBoard Board { get; set; }

        public IRenderer Renderer { get; set; }

        public IInputProvider InputProvider { get; set; }

        public void Initialize()
        {
            string welcomeLine = "Welcome to the all-time classic Minesweeper. Use your mind to tackle the mines.";
            this.Renderer.RenderLine(welcomeLine);
            this.Renderer.RenderMatrix(this.Board.Matrix);
        }

        public void Run()
        {
            while (true)
            {
                string command = this.InputProvider.Read();
                bool? commandResult = this.ExecuteCommand(command);

                if (commandResult == null)
                {
                    return;
                }
                else if (commandResult == false)
                {
                    continue;
                }
                else if (commandResult == true)
                {
                    this.Renderer.RenderMatrix(this.Board.Matrix);
                }
            }
        }

        private bool? ExecuteCommand(string command)
        {
            string commandToLowerCase = command.ToLower();
            switch (commandToLowerCase)
            {
                case "exit":
                    HandleEndGameCommand();
                    return null;
                case "top":
                    HandleShowTopScoresCommand();
                    return false;
                case "restart":
                    HandleRestartCommand();
                    return true;
                default:
                    {
                        bool? result = HandlePlayCommand(commandToLowerCase);
                        return result;
                    }
            }
        }

        private bool? HandlePlayCommand(string command)
        {
            string trimmedCommand = command.Trim();
            string[] commandComponents = command.Split(' ');
            if (commandComponents.Length < 2)
            {
                string invalidCommandLine = "Invalid command";
                this.Renderer.RenderLine(invalidCommandLine);
                return false;
            }

            int x = int.Parse(commandComponents[0]);
            int y = int.Parse(commandComponents[1]);

            if (!this.Board.IsInsideBoard(x, y))
            {
                string outOfBordersLine = "Out of borders";
                this.Renderer.Render(outOfBordersLine);
            }
            else if (this.Board.IsAlreadyShown(x, y))
            {
                string cellAlreadyShownLine = "Cell is already shown";
                this.Renderer.Render(cellAlreadyShownLine);
            }

            else if (this.Board.IsMine(x, y))
            {
                string gameOverLine = "Game over";
                this.Renderer.RenderLine(gameOverLine);
                return null;
            }

            else
            {
                this.Board.RevealCell(x, y);
                this.Renderer.Clear();
            }

            return true;
        }

        private void HandleRestartCommand()
        {

        }

        private void HandleShowTopScoresCommand()
        {

        }

        private bool? HandleEndGameCommand()
        {
            return null;
        }
    }
}
