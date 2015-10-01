namespace Minesweeper.UI.Console
{
    using Engine;
    using Engine.Initializations;
    using InputProviders;
    using Minesweeper.Logic.Boards;
    using Minesweeper.Logic.CommandOperators;
    using Minesweeper.Logic.Common;
    using Minesweeper.Logic.Common.BoardObserverContracts;
    using Minesweeper.Logic.Contents;
    using Minesweeper.Logic.DifficultyCommands;
    using Minesweeper.Logic.DifficultyCommands.Contracts;
    using Minesweeper.Logic.Players;
    using Minesweeper.Logic.Scoreboards;
    using MenuHandlers;
    using Renderers;
    using System;
    using System.Collections.Generic;

    public class Game
    {
        private static Lazy<Game> instance = new Lazy<Game>(() => new Game());

        private Game()
        {
        }

        public static Game Instance => instance.Value;

        public static BoardSettings DifficultyLevel { get; set; }

        public void Start()
        {
            var inputProvider = new ConsoleInputProvider();
            var renderer = new ConsoleRenderer();
            
            renderer.RenderWelcomeScreen(string.Join(string.Empty, GlobalConstants.GameTitle));
            renderer.RenderNewPlayerCreationRequest();
            var player = new Player(inputProvider.GetLine());

            // TODO: Refactor menu handler logic
            var cursorPosition = renderer.GetCursor();
            var menuItems = new List<IGameMode>()
            {
                new BeginnerMode(),
                new IntermediateMode(),
                new ExpertMode()
            };

            var menuHandler = new ConsoleMenuHandler(inputProvider, renderer, menuItems, cursorPosition[0] + 1, cursorPosition[1]);
            menuHandler.ShowSelections();
            menuHandler.RequestUserSelection();
            renderer.ClearScreen();
            renderer.SetCursor(true);
            //// End of menu handler logic

            var board = new Board(DifficultyLevel, new List<IBoardObserver>());
            
            var scoreboard = new Scoreboard();
            
            var contentFactory = new ContentFactory();
            var initializationStrategy = new StandardGameInitializationStrategy(contentFactory);
            var boardOperator = new CommandOperator(board, scoreboard);
            var engine = new StandardOnePlayerMinesweeperEngine(board, inputProvider, boardOperator, scoreboard, player);

            engine.Initialize(initializationStrategy);
            board.Subscribe(engine);
            engine.Run();
        }
    }
}
