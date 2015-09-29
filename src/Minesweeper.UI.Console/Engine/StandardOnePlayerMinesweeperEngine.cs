namespace Minesweeper.UI.Console.Engine
{
    using System.Collections.Generic;

    using Contracts;
    using MenuHandlers;
    using Minesweeper.Logic.Boards.Contracts;
    using Minesweeper.Logic.CommandOperators.Contracts;
    using Minesweeper.Logic.Common;
    using Minesweeper.Logic.Common.BoardObserverContracts;
    using Minesweeper.Logic.DifficultyCommands;
    using Minesweeper.Logic.DifficultyCommands.Contracts;
    using InputProviders.Contracts;
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
        private readonly IRenderer renderer = new ConsoleRenderer();
        private IPlayer currentPlayer;
        private Notification currentGameStateChange;

        public StandardOnePlayerMinesweeperEngine(IBoard board, IInputProvider inputProvider, ICommandOperator commandOperator, IScoreboard scoreboard)
        {
            this.board = board;
            this.commandOperator = commandOperator;
            this.inputProvider = inputProvider;
            this.scoreboard = scoreboard;
            this.currentGameStateChange = new Notification(string.Empty, this.board.BoardState);
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

        private void RequestNewPlayerCreation()
        {
            this.renderer.RenderNewPlayerCreationRequest();
            this.currentPlayer = new Player(this.inputProvider.GetLine());
        }

        private void SavePlayerScore(IPlayer player) =>
            this.scoreboard.RegisterNewPlayerScore(player);
    }
}
