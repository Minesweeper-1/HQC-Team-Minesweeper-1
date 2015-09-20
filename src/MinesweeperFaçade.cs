namespace Minesweeper
{
    using Engine;
    using Boards;
    using Renderers;
    using InputProviders;
    using Engine.Initializations;
    using BoardOperators;

    public class MinesweeperFaçade
    {
        private static MinesweeperFaçade instance;

        private MinesweeperFaçade()
        {

        }

        public static MinesweeperFaçade Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MinesweeperFaçade();
                }

                return instance;
            }
        }

        public void Start()
        {
            var board = new Board();
            var renderer = new ConsoleRenderer();
            var boardOperator = new BoardOperator(board, renderer);
            var inputProvider = new ConsoleInputProvider();
            var engine = new StandardOnePlayerMinesweeperEngine(board, renderer, inputProvider, boardOperator);
            var initializationStrategy = new StandardGameInitializationStrategy();
            engine.Initialize(initializationStrategy);
            board.Subscribe(engine);
            engine.Run();
        }
    }
}
