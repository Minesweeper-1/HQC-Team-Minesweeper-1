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
            this.Renderer.RenderWelcomeLine();
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
                    HandlePlayCommand(commandToLowerCase);
                    return true;
            }
        }

        private void HandlePlayCommand(string command)
        {

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
