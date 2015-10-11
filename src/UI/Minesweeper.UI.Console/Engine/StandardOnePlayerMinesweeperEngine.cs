namespace Minesweeper.UI.Console.Engine
{
    using InputProviders.Contracts;
    using Logic.Boards.Contracts;
    using Logic.CommandOperators.Contracts;
    using Logic.Common;
    using Logic.Engines.Contracts;
    using Logic.Players;
    using Logic.Players.Contracts;
    using Logic.Scoreboards.Contracts;
    using Renderers.Common;
    using Renderers.Contracts;

    /// <summary>
    /// Concrete implementation of the IMinesweeperEngine and IBoardObserver interfaces
    /// </summary>
    public class StandardOnePlayerMinesweeperEngine : IMinesweeperEngine, IBoardObserver
    {
        private readonly IScoreboard scoreboard;
        private readonly IBoard board;
        private readonly ICommandOperator commandOperator;
        private readonly IConsoleInputProvider inputProvider;
        private readonly IConsoleRenderer renderer;
        private readonly IPlayer currentPlayer;
        private Notification currentGameStateChange;
        private IGameInitializationStrategy initializationStrategy;

        /// <summary>
        /// Creates a new game engine
        /// </summary>
        /// <param name="board">Board</param>
        /// <param name="inputProvider">Console input provider</param>
        /// <param name="renderer">Console renderer</param>
        /// <param name="commandOperator">Command interpreter</param>
        /// <param name="scoreboard">Scoreboard</param>
        /// <param name="player">Current player</param>
        public StandardOnePlayerMinesweeperEngine(IBoard board, IConsoleInputProvider inputProvider, IConsoleRenderer renderer, ICommandOperator commandOperator, IScoreboard scoreboard, Player player)
        {
            this.board = board;
            this.inputProvider = inputProvider;
            this.renderer = renderer;
            this.commandOperator = commandOperator;
            this.scoreboard = scoreboard;
            this.currentPlayer = player;
            this.currentGameStateChange = new Notification(string.Empty, this.board.BoardState);
        }

        /// <summary>
        /// Initializes the game using a game initialization strategy
        /// </summary>
        /// <param name="initializationStrategy"></param>
        public void Initialize(IGameInitializationStrategy initializationStrategy)
        {
            this.initializationStrategy = initializationStrategy;
            this.initializationStrategy.Initialize(this.board);
        }

        /// <summary>
        /// Runs the game loop
        /// </summary>
        public void Run()
        {
            this.renderer.RenderBoard(this.board, RenderersConstants.BoardStartRenderRow, RenderersConstants.BoardStartRenderCol);
            this.renderer.SetCursor(RenderersConstants.BoardStartRenderRow + this.board.Rows + 1, col: 0);

            while (true)
            {
                string command = this.inputProvider.ReceiveInputLine();
                string adaptedCommand = this.inputProvider.TransformCommandToNumbersOnly(command);
                this.commandOperator.Execute(adaptedCommand);

                if (this.currentGameStateChange.State == BoardState.Closed)
                {
                    this.SavePlayerScore(this.currentPlayer);
                    this.renderer.RenderLine(GlobalMessages.GameOver);
                    return;
                }
                else if (this.currentGameStateChange.State == BoardState.Pending)
                {
                    this.renderer.SetCursor(RenderersConstants.BoardStartRenderRow + this.board.Rows + 2, col: 0);
                    this.renderer.ClearCurrentLine();
                    this.renderer.SetCursor(RenderersConstants.BoardStartRenderRow + this.board.Rows + 2, col: 0);
                    this.renderer.RenderLine(this.currentGameStateChange.Message);
                    this.renderer.SetCursor(RenderersConstants.BoardStartRenderRow + this.board.Rows + 1, col: 0);
                    this.renderer.ClearCurrentLine();
                    continue;
                }
                else if (this.currentGameStateChange.State == BoardState.Open)
                {
                    this.currentPlayer.Score += 10;
                    this.renderer.ClearScreen();
                    this.renderer.RenderBoard(this.board, RenderersConstants.BoardStartRenderRow, RenderersConstants.BoardStartRenderCol);
                    this.renderer.SetCursor(RenderersConstants.BoardStartRenderRow + this.board.Rows + 1, col: 0);
                }
                else if (this.currentGameStateChange.State == BoardState.Reset)
                {
                    this.currentPlayer.Score = 0;
                    this.initializationStrategy.Initialize(this.board);
                    this.board.ChangeBoardState(new Notification(string.Empty, BoardState.Open));
                    this.renderer.ClearScreen();
                    this.renderer.RenderBoard(this.board, RenderersConstants.BoardStartRenderRow, RenderersConstants.BoardStartRenderCol);
                    this.renderer.SetCursor(RenderersConstants.BoardStartRenderRow + this.board.Rows + 1, col: 0);
                }

                this.renderer.ClearCurrentLine();
            }
        }

        /// <summary>
        /// Changes the engine's initial state
        /// </summary>
        /// <param name="newGameState">The new game state</param>
        public void Update(Notification newGameState) =>
            this.currentGameStateChange = newGameState;

        /// <summary>
        /// Saves the current player's score
        /// </summary>
        /// <param name="player">The current player</param>
        private void SavePlayerScore(IPlayer player) =>
            this.scoreboard.RegisterNewPlayerScore(player);
    }
}
