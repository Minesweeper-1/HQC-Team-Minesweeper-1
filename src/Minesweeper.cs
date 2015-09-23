namespace Minesweeper
{
    using Engine;
    using Boards;
    using Renderers;
    using InputProviders;
    using Engine.Initializations;
    using BoardOperators;
    using Scoreboards;
    using Boards.Contracts;
    using Renderers.Contracts;
    using Scoreboards.Contracts;
    using BoardOperators.Contracts;
    using InputProviders.Contracts;
    using Engine.Contracts;

    public class Minesweeper
    {
        private static Minesweeper instance;

        private static readonly IBoard board = new Board();
        private static readonly IRenderer renderer = new ConsoleRenderer();
        private static readonly IScoreboard scoreboard = new Scoreboard();
        private static readonly IInputProvider inputProvider = new ConsoleInputProvider();
        private static readonly IBoardOperator boardOperator = new BoardOperator(board, renderer, scoreboard);
        private static readonly IGameInitializationStrategy initializationStrategy = new StandardGameInitializationStrategy();
        private static readonly IMinesweeperEngine engine = new StandardOnePlayerMinesweeperEngine(board, renderer, inputProvider, boardOperator, scoreboard);

        private Minesweeper()
        {

        }

        public static Minesweeper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Minesweeper();
                }

                return instance;
            }
        }

        public void Start()
        {
            engine.Initialize(initializationStrategy);
            board.Subscribe(engine);
            engine.Run();
        }
    }
}
