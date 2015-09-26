namespace Minesweeper
{
    using System;

    using Boards;
    using CommandOperators;
    using Contents;
    using Engine;
    using Engine.Initializations;
    using InputProviders;
    using Renderers;
    using Scoreboards;

    public class Game
    {
        private static Lazy<Game> instance = new Lazy<Game>(() => new Game());

        private Game()
        {
        }

        public static Game Instance => instance.Value;

        public void Start()
        {
            var board = new Board();
            var renderer = new ConsoleRenderer();
            var scoreboard = new Scoreboard();
            var inputProvider = new ConsoleInputProvider();
            var contentFactory = new ContentFactory();
            var initializationStrategy = new StandardGameInitializationStrategy(contentFactory);
            var boardOperator = new CommandOperator(board, renderer, scoreboard);
            var engine = new StandardOnePlayerMinesweeperEngine(board, renderer, inputProvider, boardOperator, scoreboard);

            engine.Initialize(initializationStrategy);
            board.Subscribe(engine);
            engine.Run();
        }
    }
}
