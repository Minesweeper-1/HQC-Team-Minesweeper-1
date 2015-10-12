namespace Minesweeper.UI.Wpf.Engine
{
    using InputProviders.Contracts;
    using Logic.Boards.Contracts;
    using Logic.CommandOperators.Contracts;
    using Logic.Common;
    using Logic.Engines.Contracts;
    using Logic.Players;
    using Logic.Players.Contracts;
    using Logic.Renderers.Contracts;
    using Logic.Scoreboards.Contracts;

    public class StandardOnePlayerMinesweeperEngine : IMinesweeperEngine, IBoardObserver
    {
        private readonly IScoreboard scoreboard;
        private readonly IBoard board;
        private readonly ICommandOperator commandOperator;
        private readonly IWpfInputProvider inputProvider;
        private readonly IRenderer renderer;
        private readonly IPlayer currentPlayer;
        private Notification currentGameStateChange;

        public StandardOnePlayerMinesweeperEngine(IBoard board, IWpfInputProvider inputProvider, IRenderer renderer, ICommandOperator commandOperator, IScoreboard scoreboard, Player player)
        {
            this.board = board;
            this.inputProvider = inputProvider;
            this.renderer = renderer;
            this.commandOperator = commandOperator;
            this.scoreboard = scoreboard;
            this.currentPlayer = player;
            this.currentGameStateChange = new Notification(string.Empty, this.board.BoardState);
        }

        public void Initialize(IGameInitializationStrategy initializationStrategy) =>
           initializationStrategy.Initialize(this.board);

        public void Run()
        {
            this.renderer.RenderBoard(this.board);
        }

        public void Update(Notification newGameState) =>
            this.currentGameStateChange = newGameState;

        private void SavePlayerScore(IPlayer player) =>
            this.scoreboard.RegisterNewPlayerScore(player);
    }
}