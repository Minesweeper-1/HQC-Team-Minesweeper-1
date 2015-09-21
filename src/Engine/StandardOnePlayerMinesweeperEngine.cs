namespace Minesweeper.Engine
{
    using Boards.Contracts;
    using Common;
    using Contracts;
    using InputProviders.Contracts;
    using BoardOperators.Contracts;
    using Renderers.Contracts;
    using Players;
    using Players.Contracts;
    using DataManagers;

    public class StandardOnePlayerMinesweeperEngine : IMinesweeperEngine, IBoardObserver
    {
        private IPlayer currentPlayer;

        public StandardOnePlayerMinesweeperEngine(IBoard board, IRenderer renderer, IInputProvider inputProvider, IBoardOperator boardOperator)
        {
            this.Board = board;
            this.BoardOperator = boardOperator;
            this.Renderer = renderer;
            this.InputProvider = inputProvider;
            this.GameState = this.Board.BoardState;
        }

        public IBoard Board { get; set; }

        public IBoardOperator BoardOperator { get; set; }

        public IRenderer Renderer { get; set; }

        public IInputProvider InputProvider { get; set; }

        public BoardState GameState { get; set; }

        public void Initialize(IGameInitializationStrategy initializationStrategy)
        {
            initializationStrategy.Initialize(this.Board);
        }

        public void Run()
        {
            this.Renderer.RenderWelcomeScreen(GlobalConstants.DefaultWelcomeScreen);
            this.RequestNewPlayerCreation();
            this.StartGame();
        }

        public void Update(BoardState boardState)
        {
            this.GameState = boardState;
        }

        // TODO: Extract these magic coordinates
        private void StartGame()
        {
            int boardStartRenderX = 5;
            int boardStartRenderY = 5;

            this.Renderer.RenderBoard(this.Board, boardStartRenderX, boardStartRenderY);
            this.Renderer.SetCursorPosition(boardStartRenderX + this.Board.Rows + 1, col: 0);

            while (true)
            {
                string command = this.InputProvider.ReadLine();
                this.BoardOperator.ExecuteCommand(command);

                if (this.GameState == BoardState.Closed)
                {
                    this.SavePlayerScore(this.currentPlayer);
                    return;
                }
                else if (this.GameState == BoardState.Pending)
                {
                    continue;
                }
                else if (this.GameState == BoardState.Open)
                {
                    this.Renderer.RenderBoard(this.Board, boardStartRenderX, boardStartRenderY);
                    this.Renderer.SetCursorPosition(boardStartRenderX + this.Board.Rows + 1, col: 0);
                }

                this.Renderer.ClearCurrentConsoleLine();
            }
        }

        private void RequestNewPlayerCreation()
        {
            this.Renderer.Render(line: "Enter your name: ");
            string username = this.InputProvider.ReadLine();

            var player = new Player(username, score: 0);
            this.currentPlayer = player;
        }

        private void SavePlayerScore(IPlayer player)
        {
            string contents = string.Format(format: "{0} --- {1}", arg0: player.Name, arg1: player.Score);

            var dataWriter = new FileWriter();
            dataWriter.WriteLine(path: "leaders.msr", contents: contents);
        }
    }
}
