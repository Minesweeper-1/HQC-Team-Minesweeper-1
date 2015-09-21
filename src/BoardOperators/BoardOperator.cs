namespace Minesweeper.BoardOperators
{
    using Contracts;
    using Boards.Contracts;
    using Renderers.Contracts;
    using Common.Contracts;
    using Common;

    public class BoardOperator : IBoardOperator
    {
        private readonly IBoardCommand playCommand;
        private readonly IBoardCommand restartCommand;
        private readonly IBoardCommand showScoreboardCommand;
        private readonly IBoardCommand endGameCommand;

        public BoardOperator(IBoard board, IRenderer renderer)
        {
            this.Board = board;
            this.Renderer = renderer;

            this.playCommand = new PlayCommand(board, renderer);
            this.restartCommand = new RestartCommand(board);
            this.showScoreboardCommand = new ShowScoreboardCommand(board, renderer);
            this.endGameCommand = new EndGameCommand(board);
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
                    this.endGameCommand.Execute();
                    break;
                case "top":
                    this.showScoreboardCommand.Execute();
                    break;
                case "restart":
                    this.restartCommand.Execute();
                    break;
                default:
                    this.playCommand.Execute(commandToLowerCase);
                    break;
            }
        }

        public void Execute(IBoardCommand command)
        {
            command.Execute();
        }
    }
}