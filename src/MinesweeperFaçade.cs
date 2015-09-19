namespace Minesweeper
{
    using Engine;
    using Boards;
    using Renderers;
    using InputProviders;
    using Engine.Initializations;

    public class MinesweeperFaçade
    {
        private static MinesweeperFaçade instance;

        private MinesweeperFaçade()
        {

        }

        public static MinesweeperFaçade GetInstance()
        {
            if(instance == null)
            {
                instance = new MinesweeperFaçade();
            }

            return instance;
        }

        public void Start()
        {
            var board = new Board();
            var renderer = new ConsoleRenderer();
            var inputProvider = new ConsoleInputProvider();
            var engine = new StandardOnePlayerMinesweeperEngine(board, renderer, inputProvider);
            var initializationStrategy = new StandardGameInitializationStrategy();
            engine.Initialize(initializationStrategy);
            engine.Run();
        }
    }
}
