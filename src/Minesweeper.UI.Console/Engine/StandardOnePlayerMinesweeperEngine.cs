namespace Minesweeper.UI.Console.Engine
{

    using Contracts;
    using InputProviders.Contracts;
    using Minesweeper.Logic.Boards.Contracts;
    using Minesweeper.Logic.CommandOperators.Contracts;
    using Minesweeper.Logic.Common;
    using Minesweeper.Logic.Common.BoardObserverContracts;
    using Minesweeper.Logic.Players;
    using Minesweeper.Logic.Players.Contracts;
    using Minesweeper.Logic.Scoreboards.Contracts;
    using Renderers;
    using Renderers.Contracts;

    public class StandardOnePlayerMinesweeperEngine : IMinesweeperEngine, IBoardObserver
    {
        private readonly IScoreboard scoreboard;
        private readonly IBoard board;
        private readonly ICommandOperator commandOperator;
        private readonly IInputProvider inputProvider;
        private readonly IRenderer renderer;
        private readonly IPlayer currentPlayer;
        private Notification currentGameStateChange;

        public StandardOnePlayerMinesweeperEngine(IBoard board, IInputProvider inputProvider, IRenderer renderer, ICommandOperator commandOperator, IScoreboard scoreboard, Player player)
        {
            this.board = board;
            this.inputProvider = inputProvider;
            this.renderer = renderer;
            this.commandOperator = commandOperator;
            this.scoreboard = scoreboard;
            this.currentPlayer = player;
            this.currentGameStateChange = new Notification(string.Empty, this.board.BoardState);
        }

        public void Initialize(IGameInitializationStrategy initializationStrategy) =>
            initializationStrategy.Initialize(this.board);

        public void Run()
        {
            this.StartGame();
        }

        public void Update(Notification newGameState) =>
            this.currentGameStateChange = newGameState;

        private void StartGame()
        {
            this.renderer.RenderBoard(this.board, GlobalConstants.BoardStartRenderRow, GlobalConstants.BoardStartRenderCol);
            this.renderer.SetCursor(GlobalConstants.BoardStartRenderRow + this.board.Rows + 1, col: 0);

            while (true)
            {
                string command = this.inputProvider.GetLine();
                this.commandOperator.Execute(command);

                if (this.currentGameStateChange.State == BoardState.Closed)
                {
                    this.SavePlayerScore(this.currentPlayer);
                    return;
                }
                else if (this.currentGameStateChange.State == BoardState.Pending)
                {
                    this.renderer.RenderLine(this.currentGameStateChange.Message);
                    this.renderer.SetCursor(GlobalConstants.BoardStartRenderRow + this.board.Rows + 1, col: 0);
                    this.renderer.ClearCurrentLine();
                    continue;
                }
                else if (this.currentGameStateChange.State == BoardState.Open)
                {
                    this.currentPlayer.Score += 10;
                    this.renderer.RenderBoard(this.board, GlobalConstants.BoardStartRenderRow, GlobalConstants.BoardStartRenderCol);
                    this.renderer.SetCursor(GlobalConstants.BoardStartRenderRow + this.board.Rows + 1, col: 0);
                }

                this.renderer.ClearCurrentLine();
            }
        }

        private void SavePlayerScore(IPlayer player) =>
            this.scoreboard.RegisterNewPlayerScore(player);
    }
}
