namespace Minesweeper.Engine
{
    using System.Collections.Generic;

    using Boards.Contracts;
    using CommandOperators.Contracts;
    using Common;
    using Contracts;
    using DifficultyCommands;
    using DifficultyCommands.Contracts;
    using InputProviders.Contracts;
    using MenuHandlers;
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
            this.renderer.RenderWelcomeScreen(string.Join(string.Empty, GlobalConstants.GameTitle));
            this.RequestNewPlayerCreation();

            // TODO: Refactor menu handler logic
            var cursorPosition = this.renderer.GetCursor();
            var menuItems = new List<IGameMode>()
            {
                new BeginnerMode(),
                new IntermediateMode(),
                new ExpertMode()
            };

            var menuHandler = new ConsoleMenuHandler(this.inputProvider, this.renderer, menuItems, cursorPosition[0] + 1, cursorPosition[1]);
            menuHandler.ShowSelections();
            menuHandler.RequestUserSelection();
            this.renderer.ClearScreen();
            this.renderer.SetCursor(true);
            //// End of menu handler logic

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
                    this.renderer.ClearCurrentLine();
                    continue;
                }
                else if (this.gameState == BoardState.Open)
                {
                    this.currentPlayer.Score += 10;
                    this.renderer.RenderBoard(this.board, GlobalConstants.BoardStartRenderRow, GlobalConstants.BoardStartRenderCol);
                    this.renderer.SetCursor(GlobalConstants.BoardStartRenderRow + this.board.Rows + 1, col: 0);
                }

                this.renderer.ClearCurrentLine();
            }
        }

        private void RequestNewPlayerCreation()
        {
            this.renderer.RenderNewPlayerCreationRequest();
            this.currentPlayer = new Player(this.inputProvider.GetLine());
        }

        private void SavePlayerScore(IPlayer player) =>
            this.scoreboard.RegisterNewPlayerScore(player);
    }
}
