namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    using Boards;
    using CommandOperators;
    using Contents;
    using Engine;
    using Engine.Initializations;
    using InputProviders;

    using Minesweeper.Engine.Contracts;

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
            var board = new Board(this.ChooseDifficultyLevel(), new List<IBoardObserver>());
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

        private BoardSettings ChooseDifficultyLevel()
        {
            //Console.Write("Choose difficulty level (Easy, Medium, Hard) or start with Easy settings: ");
            string level = string.Empty;//Console.ReadLine();
            switch (level)
            {
                case "Easy": return new EasyBoardSettings();
                case "Medium": return new NormalBoardSettings();
                case "Hard": return new HardBoardSettings();
                default: return new EasyBoardSettings();
            }
        }
    }
}
