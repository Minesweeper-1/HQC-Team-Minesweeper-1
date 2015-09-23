namespace Minesweeper.CommandOperators
{
    using System.Collections.Generic;
    using System.Globalization;

    using Boards.Contracts;
    using Common;
    using Common.Contracts;
    using Contracts;
    using Renderers.Contracts;
    using Scoreboards.Contracts;
    using System;

    public class CommandOperator : ICommandOperator
    {
        private IDictionary<string, Action<string>> commandExecutor;
        private readonly IBoard board;
        private readonly IRenderer renderer;
        private readonly IScoreboard scoreboard;

        public CommandOperator(IBoard board, IRenderer renderer, IScoreboard scoreboard)
        {
            this.board = board;
            this.renderer = renderer;
            this.scoreboard = scoreboard;

            //this.Initialize();
        }

        private void Initialize()
        {
            IBoardCommand playCommand = new PlayCommand(this.board, this.renderer);
            IBoardCommand restartCommand = new RestartCommand(this.board);
            IBoardCommand showScoreboardCommand = new ShowScoreboardCommand(this.renderer, this.scoreboard);
            IBoardCommand endGameCommand = new EndGameCommand(this.board);

            this.commandExecutor = new Dictionary<string, Action<string>>()
            {
                {
                    "exit",  endGameCommand.Execute
                },
                {
                    "top", showScoreboardCommand.Execute
                },
                {
                    "restart", restartCommand.Execute
                },
                {
                    "play", playCommand.Execute
                }
            };
        }

        public void Execute(string command)
        {
            string commandToLowerCase = command.ToLower(CultureInfo.InvariantCulture);
            if (!this.commandExecutor.ContainsKey(commandToLowerCase))
            {
                this.commandExecutor["play"](commandToLowerCase);
                return;
            }

            this.commandExecutor[commandToLowerCase](string.Empty);
        }
    }
}