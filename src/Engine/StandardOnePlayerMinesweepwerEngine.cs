namespace Minesweeper.Engine
{
    using System;

    using Boards.Contracts;
    using Contracts;
    using Renderers.Contracts;
    using InputProviders.Contracts;

    public class StandardOnePlayerMinesweepwerEngine : IMinesweeperEngine
    {
        public StandardOnePlayerMinesweepwerEngine(IBoard board, IRenderer renderer, IInputProvider inputProvider)
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
            this.Renderer.Render(welcomeLine);
            this.Board.Display();
        }

        public void Run()
        {
            while (true)
            {
                string command = this.InputProvider.Read();
                bool commandResult = this.ExecuteCommand(command);
                if (!commandResult)
                {
                    break;
                }
            }
        }

        private bool ExecuteCommand(string command)
        {
            string commandToLowerCase = command.ToLower();
            switch (commandToLowerCase)
            {
                case "exit":
                    return HandleEndGameCommand();
                case "top":
                    HandleShowTopScoresCommand();
                    return true;
                case "restart":
                    HandleRestartCommand();
                    return true;
                default:
                    return HandlePlayCommand(commandToLowerCase);
            }
        }

        private bool HandlePlayCommand(string command)
        {
            string[] commandComponents = command.Split(' ');
            int x = int.Parse(commandComponents[0]);
            int y = int.Parse(commandComponents[1]);

            if (!this.Board.IsInsideTheField(x, y))
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
                this.Renderer.Render(gameOverLine);
                return false;
            }
            else
            {
                this.Board.RevealCell(x, y);
                this.Board.Display();
            }

            return true;
        }

        private void HandleRestartCommand()
        {

        }

        private void HandleShowTopScoresCommand()
        {

        }

        private bool HandleEndGameCommand()
        {
            return false;
        }
    }
}
