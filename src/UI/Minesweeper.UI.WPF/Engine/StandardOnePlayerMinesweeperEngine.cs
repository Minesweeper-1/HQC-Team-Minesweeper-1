namespace MineSweeper_WPF.Engine
{
    using System;

    using Minesweeper.Logic.CommandOperators.Contracts;
    using Minesweeper.Logic.Common;
    using Minesweeper.Logic.Engines.Contracts;
    using Minesweeper.Logic.Players;
    using Minesweeper.Logic.Players.Contracts;
    using Minesweeper.Logic.Scoreboards.Contracts;
    using Minesweeper.Logic.Boards.Contracts;
    using Renderers.Contracts;
    using Renderers;

    class StandardOnePlayerMinesweeperEngine: IMinesweeperEngine, IBoardObserver
    {
        private readonly IScoreboard scoreboard;
        private readonly IBoard board;
        private readonly ICommandOperator commandOperator;
        private readonly IWpfInputtProvider inputProvider;
        private readonly IWpfRenderer renderer;
        private readonly IPlayer currentPlayer;
        private Notification currentGameStateChange;

        public StandardOnePlayerMinesweeperEngine(IBoard board, IWpfInputtProvider inputProvider, IWpfRenderer renderer, ICommandOperator commandOperator, IScoreboard scoreboard, Player player)
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
            this.StartGame();
        }

        public void Update(Notification newGameState) =>
            this.currentGameStateChange = newGameState;

        private void StartGame()
        {

        }

        private void SavePlayerScore(IPlayer player) =>
            this.scoreboard.RegisterNewPlayerScore(player);
    }
}
