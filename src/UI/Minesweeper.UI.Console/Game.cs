namespace Minesweeper.UI.Console
{
    using System;
    using System.Collections.Generic;

    using Engine;
    using Engine.Initializations;
    using InputProviders;
    using InputProviders.Contracts;
    using Logic.Boards;
    using Logic.Boards.Contracts;
    using Logic.Boards.Settings.Contracts;
    using Logic.CommandOperators;
    using Logic.Contents;
    using Logic.DifficultyCommands;
    using Logic.DifficultyCommands.Contracts;
    using Logic.Players;
    using Logic.Scoreboards;
    using MenuHandlers;
    using Renderers;
    using Renderers.Common;
    using Renderers.Contracts;

    /// <summary>
    /// Game facade
    /// </summary>
    public class Game
    {
        private static readonly Lazy<Game> LazyInstance = new Lazy<Game>(() => new Game());

        private IConsoleInputProvider inputProvider;

        private IConsoleRenderer outputRenderer;

        private Game()
        {
        }

        /// <summary>
        /// Facade singleton instance
        /// </summary>
        public static Game Instance => LazyInstance.Value;

        /// <summary>
        /// The facade input provider
        /// </summary>
        public IConsoleInputProvider InputProvider
        {
            get
            {
                return this.inputProvider;
            }

            set
            {
                this.inputProvider = value;
            }
        }

        /// <summary>
        /// The facade renderer
        /// </summary>
        public IConsoleRenderer OutputRenderer
        {
            get
            {
                return this.outputRenderer;
            }

            set
            {
                this.outputRenderer = value;
            }
        }

        /// <summary>
        /// Start Game logic
        /// </summary>
        public void Start()
        {
            // Initialize the two basic objects needed for user interactions
            this.InputProvider = this.inputProvider ?? new ConsoleInputProvider();
            this.OutputRenderer = this.outputRenderer ?? new ConsoleRenderer();

            // Render initial UI
            this.OutputRenderer.RenderWelcomeScreen(string.Join(string.Empty, RenderersConstants.GameTitle));
            this.OutputRenderer.RenderNewPlayerCreationRequest();

            // Create the active player
            var player = new Player(this.InputProvider.ReceiveInputLine());

            // Render console menu handler and execute logic for requesting board settings
            // TODO: Refactor menu handler logic
            int[] cursorPosition = this.OutputRenderer.GetCursor();
            var menuItems = new List<IGameMode>()
            {
                new BeginnerMode(),
                new IntermediateMode(),
                new ExpertMode()
            };

            var menuHandler = new ConsoleMenuHandler(this.inputProvider, this.outputRenderer, menuItems, cursorPosition[0] + 1, cursorPosition[1]);

            menuHandler.ShowSelections();

            BoardSettings boardSettings = menuHandler.RequestUserSelection();
            this.OutputRenderer.ClearScreen();
            this.OutputRenderer.SetCursor(visible: true);
            //// End of menu handler logic

            var board = new Board(boardSettings, new List<IBoardObserver>());
            var scoreboard = new Scoreboard();
            var contentFactory = new ContentFactory();
            var initializationStrategy = new StandardGameInitializationStrategy(contentFactory);
            var boardOperator = new CommandOperator(board, scoreboard);
            var engine = new StandardOnePlayerMinesweeperEngine(board, this.inputProvider, this.outputRenderer, boardOperator, scoreboard, player);

            engine.Initialize(initializationStrategy);
            board.Subscribe(engine);
            engine.Run();
        }
    }
}
