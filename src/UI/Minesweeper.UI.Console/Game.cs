namespace Minesweeper.UI.Console
{
    using System;
    using System.Collections.Generic;

    using Engine;
    using Engine.Initializations;
    using InputProviders;
    using MenuHandlers;
    using Logic.Boards;
    using Logic.Boards.Contracts;
    using Logic.CommandOperators;
    using Logic.Contents;
    using Logic.DifficultyCommands;
    using Logic.DifficultyCommands.Contracts;
    using Logic.Players;
    using Logic.Scoreboards;
    using Renderers;
    using Renderers.Common;

    /// <summary>
    /// Game facade
    /// </summary>
    public class Game
    {
        private static readonly Lazy<Game> instance = new Lazy<Game>(() => new Game());

        private Game()
        {
        }

        public static Game Instance => instance.Value;

        /// <summary>
        /// Start Game logic
        /// </summary>
        public void Start()
        {
            // Initialize the two basic objects needed for user interactions
            var inputProvider = new ConsoleInputProvider();
            var renderer = new ConsoleRenderer();

            // Render initial UI
            renderer.RenderWelcomeScreen(string.Join(string.Empty, RenderersConstants.GameTitle));
            renderer.RenderNewPlayerCreationRequest();

            // Create the active player
            var player = new Player(inputProvider.ReceiveInputLine());

            // Render console menu handler and execute logic for requesting board settings
            // TODO: Refactor menu handler logic
            int[] cursorPosition = renderer.GetCursor();
            var menuItems = new List<IGameMode>()
            {
                new BeginnerMode(),
                new IntermediateMode(),
                new ExpertMode()
            };

            var menuHandler = new ConsoleMenuHandler(inputProvider, renderer, menuItems, cursorPosition[0] + 1, cursorPosition[1]);

            menuHandler.ShowSelections();

            var boardSettings = menuHandler.RequestUserSelection();
            renderer.ClearScreen();
            renderer.SetCursor(true);
            //// End of menu handler logic

            var board = new Board(boardSettings, new List<IBoardObserver>());
            var scoreboard = new Scoreboard();
            var contentFactory = new ContentFactory();
            var initializationStrategy = new StandardGameInitializationStrategy(contentFactory);
            var boardOperator = new CommandOperator(board, scoreboard);
            var engine = new StandardOnePlayerMinesweeperEngine(board, inputProvider, renderer, boardOperator, scoreboard, player);

            engine.Initialize(initializationStrategy);
            board.Subscribe(engine);
            engine.Run();
        }
    }
}
