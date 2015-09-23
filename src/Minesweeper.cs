namespace Minesweeper
{
    using CommandOperators;
    using CommandOperators.Contracts;
    using Boards;
    using Boards.Contracts;
    using Engine;
    using Engine.Contracts;
    using Engine.Initializations;
    using InputProviders;
    using InputProviders.Contracts;
    using Renderers;
    using Renderers.Contracts;
    using Scoreboards;
    using Scoreboards.Contracts;
    using Contents;

    public class Minesweeper
    {
        private static readonly Minesweeper instance = new Minesweeper();

        private  readonly IBoard board = new Board();
        private  readonly IRenderer renderer = new ConsoleRenderer();
        private readonly IScoreboard scoreboard = new Scoreboard();
        private readonly IInputProvider inputProvider = new ConsoleInputProvider();
        private readonly ContentFactory contentFactory = new ContentFactory();
        private readonly IGameInitializationStrategy initializationStrategy;
        private readonly ICommandOperator boardOperator;
        private readonly IMinesweeperEngine engine;

        private Minesweeper()
        {
            this.boardOperator = new CommandOperator(this.board, this.renderer, this.scoreboard);
            this.initializationStrategy = new StandardGameInitializationStrategy(this.contentFactory);
            this.engine = new StandardOnePlayerMinesweeperEngine(this.board, this.renderer, this.inputProvider, this.boardOperator, this.scoreboard);
        }

        public static Minesweeper Instance
        {
            get
            {
                return instance;
            }
        }

        public void Start()
        {
            this.engine.Initialize(this.initializationStrategy);
            this.board.Subscribe(this.engine);
            this.engine.Run();
        }
    }
}
