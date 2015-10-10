namespace Minesweeper.UI.Console.Engine
{
    using System;

    using InputProviders.Contracts;
    using Logic.Boards.Contracts;
    using Logic.CommandOperators.Contracts;
    using Logic.Common;
    using Logic.Engines.Contracts;
    using Logic.Players;
    using Logic.Players.Contracts;
    using Logic.Scoreboards.Contracts;
    using Renderers.Contracts;
    using Renderers.Common;

    public class StandardOnePlayerMinesweeperEngine : IMinesweeperEngine, IBoardObserver
    {
        private readonly IScoreboard scoreboard;
        private readonly IBoard board;
        private readonly ICommandOperator commandOperator;
        private readonly IConsoleInputProvider inputProvider;
        private readonly IConsoleRenderer renderer;
        private readonly IPlayer currentPlayer;
        private Notification currentGameStateChange;

        /// <summary>
        /// Construct game Engine
        /// </summary>
        /// <param name="board">IBoard Object</param>
        /// <param name="inputProvider">Console input provider</param>
        /// <param name="renderer">Console renderer</param>
        /// <param name="commandOperator">Coomand interpreter</param>
        /// <param name="scoreboard">Score board</param>
        /// <param name="player">player </param>
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
        /// Use game initialization strategy
        /// </summary>
        /// <param name="initializationStrategy"></param>
        public void Initialize(IGameInitializationStrategy initializationStrategy) =>
            initializationStrategy.Initialize(this.board);

        /// <summary>
        /// Start game
        /// </summary>
        public void Run()
        {
            this.StartGame();
        }

        /// <summary>
        /// Updates upon notification
        /// </summary>
        /// <param name="newGameState"></param>
        public void Update(Notification newGameState) =>
            this.currentGameStateChange = newGameState;


        private void StartGame()
        {
            this.renderer.RenderBoard(this.board, RenderersConstants.BoardStartRenderRow, RenderersConstants.BoardStartRenderCol);
            this.renderer.SetCursor(RenderersConstants.BoardStartRenderRow + this.board.Rows + 1, col: 0);

            while (true)
            {
                string command = this.inputProvider.ReceiveInputLine();
                string[] commandParts = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                commandParts[1] = RenderersConstants.IndexLetters.ToLowerInvariant().IndexOf(commandParts[1].ToLowerInvariant(), StringComparison.InvariantCulture).ToString();
                this.commandOperator.Execute(string.Join(" ", commandParts));

                if (this.currentGameStateChange.State == BoardState.Closed)
                {
                    this.SavePlayerScore(this.currentPlayer);
                    return;
                }
                else if (this.currentGameStateChange.State == BoardState.Pending)
                {
                    this.renderer.RenderLine(this.currentGameStateChange.Message);
                    this.renderer.SetCursor(RenderersConstants.BoardStartRenderRow + this.board.Rows + 1, col: 0);
                    this.renderer.ClearCurrentLine();
                    continue;
                }
                else if (this.currentGameStateChange.State == BoardState.Open)
                {
                    this.currentPlayer.Score += 10;
                    this.renderer.RenderBoard(this.board, RenderersConstants.BoardStartRenderRow, RenderersConstants.BoardStartRenderCol);
                    this.renderer.SetCursor(RenderersConstants.BoardStartRenderRow + this.board.Rows + 1, col: 0);
                }

                this.renderer.ClearCurrentLine();
            }
        }

        private void SavePlayerScore(IPlayer player) =>
            this.scoreboard.RegisterNewPlayerScore(player);
    }
}
