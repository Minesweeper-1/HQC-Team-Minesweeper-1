namespace Minesweeper.Engine
{
    using CommandOperators.Contracts;
    using Boards.Contracts;
    using Common;
    using Contracts;
    using InputProviders.Contracts;
    using Players;
    using Players.Contracts;
    using Renderers.Contracts;
    using Scoreboards.Contracts;

    public class StandardOnePlayerMinesweeperEngine : IMinesweeperEngine, IBoardObserver
    {
        private IPlayer currentPlayer;
        private readonly IScoreboard scoreboard;

        public StandardOnePlayerMinesweeperEngine(IBoard board, IRenderer renderer, IInputProvider inputProvider, ICommandOperator boardOperator, IScoreboard scoreboard)
        {
            this.Board = board;
            this.BoardOperator = boardOperator;
            this.Renderer = renderer;
            this.InputProvider = inputProvider;
            this.scoreboard = scoreboard;
            this.GameState = this.Board.BoardState;
        }

        public IBoard Board { get; set; }

        public ICommandOperator BoardOperator { get; set; }

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
                this.BoardOperator.Execute(command);

                if (this.GameState == BoardState.Closed)
                {
                    this.SavePlayerScore(this.currentPlayer);
                    return;
                }
                else if (this.GameState == BoardState.Pending)
                {
                    this.Renderer.SetCursorPosition(boardStartRenderX + this.Board.Rows + 1, col: 0);
                    continue;
                }
                else if (this.GameState == BoardState.Open)
                {
                    this.currentPlayer.Score += 10;
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
            this.scoreboard.RegisterNewPlayerScore(player);
        }
    }
}
