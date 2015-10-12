namespace Minesweeper.UI.Wpf
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Controls;
    
    using Engine;
    using Engine.Initializations;
    using InputProviders;
    using InputProviders.Contracts;
    using Logic.Boards;
    using Logic.Boards.Contracts;
    using Logic.Boards.Settings;
    using Logic.Boards.Settings.Contracts;
    using Logic.CommandOperators;
    using Logic.Contents;
    using Logic.Players;
    using Logic.Scoreboards;
    using Renderers;
    using Renderers.Contracts;

    /// <summary>
    /// Wpf App facade
    /// </summary>
    public class Game
    {
        private static readonly Lazy<Game> LazyInstance = new Lazy<Game>(() => new Game());

        private IWpfInputProvider inputProvider;

        private IWpfRenderer outputRenderer;

        private Game()
        {
        }

        public static Game Instance => LazyInstance.Value;

        public IWpfInputProvider InputProvider
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

        public IWpfRenderer OutputRenderer
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
        public void Start(Grid root)
        {
            // Initialize the two basic objects needed for user interactions
            this.InputProvider = this.inputProvider ?? new WpfInputProvider();
            this.OutputRenderer = this.outputRenderer ?? new WpfRenderer(root);

            string testPlayerName = "John";

            // Create the active player
            var player = new Player(testPlayerName);

            BoardSettings testBoardSettings = new EasyBoardSettings();

            var board = new Board(testBoardSettings, new List<IBoardObserver>());
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
