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
                this.ExecuteCommand(command);
            }
        }

        private void ExecuteCommand(string command)
        {
            switch (command)
            {
                case "Exit":
                    HandleEndGameCommand();
                    break;

                case "Top":
                    HandleShowTopScoresCommand();
                    break;

                case "Restart":
                    HandleRestartCommand();
                    break;
                default:
                    HandlePlayCommand(command);
                    break;
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

        private void HandleEndGameCommand()
        {
            Environment.Exit(0);
        }
    }
}
