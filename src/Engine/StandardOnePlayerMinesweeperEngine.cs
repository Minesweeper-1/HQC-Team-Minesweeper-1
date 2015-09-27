namespace Minesweeper.Engine
{
    using System;

    using Boards.Contracts;
    using CommandOperators.Contracts;
    using Common;
    using Contracts;
    using InputProviders.Contracts;

    using Minesweeper.Boards;

    using Players;
    using Players.Contracts;
    using Renderers.Contracts;
    using Scoreboards.Contracts;

    public class StandardOnePlayerMinesweeperEngine : IMinesweeperEngine, IBoardObserver
    {
        private readonly IScoreboard scoreboard;
        private readonly IBoard board;
        private readonly ICommandOperator commandOperator;
        private readonly IRenderer renderer;
        private readonly IInputProvider inputProvider;
        private IPlayer currentPlayer;
        private BoardState gameState;

        public StandardOnePlayerMinesweeperEngine(IBoard board, IRenderer renderer, IInputProvider inputProvider, ICommandOperator commandOperator, IScoreboard scoreboard)
        {
            this.board = board;
            this.commandOperator = commandOperator;
            this.renderer = renderer;
            this.inputProvider = inputProvider;
            this.scoreboard = scoreboard;
            this.gameState = this.board.BoardState;
        }

        public void Initialize(IGameInitializationStrategy initializationStrategy) =>
            initializationStrategy.Initialize(this.board);

        public void Run()
        {
            this.renderer.RenderWelcomeScreen(GlobalConstants.DefaultWelcomeScreen);
            this.RequestNewPlayerCreation();
            this.StartGame();
        }

        public void Update(BoardState boardState) =>
            this.gameState = boardState;

        private void StartGame()
        {
            this.renderer.RenderBoard(this.board, GlobalConstants.BoardStartRenderRow, GlobalConstants.BoardStartRenderCol);
            this.renderer.SetCursor(GlobalConstants.BoardStartRenderRow + this.board.Rows + 1, col: 0);

            while (true)
            {
                string command = this.inputProvider.GetLine();
                this.commandOperator.Execute(command);

                if (this.gameState == BoardState.Closed)
                {
                    this.SavePlayerScore(this.currentPlayer);
                    return;
                }
                else if (this.gameState == BoardState.Pending)
                {
                    this.renderer.SetCursor(GlobalConstants.BoardStartRenderRow + this.board.Rows + 1, col: 0);
                    this.renderer.ClearCurrentConsoleLine();
                    continue;
                }
                else if (this.gameState == BoardState.Open)
                {
                    this.currentPlayer.Score += 10;
                    this.renderer.RenderBoard(this.board, GlobalConstants.BoardStartRenderRow, GlobalConstants.BoardStartRenderCol);
                    this.renderer.SetCursor(GlobalConstants.BoardStartRenderRow + this.board.Rows + 1, col: 0);
                }

                this.renderer.ClearCurrentConsoleLine();
            }
        }

        private void RequestNewPlayerCreation()
        {
            this.renderer.Render(line: "Enter your name: ");
            this.currentPlayer = new Player(this.inputProvider.GetLine());
        }

        private void SavePlayerScore(IPlayer player) =>
            this.scoreboard.RegisterNewPlayerScore(player);
    }
}
