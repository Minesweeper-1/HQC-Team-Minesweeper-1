namespace Minesweeper.Logic.CommandOperators
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    using Boards.Contracts;
    using Common;
    using Contracts;
    using Scoreboards.Contracts;

    public class CommandOperator : ICommandOperator
    {
        private readonly IDictionary<string, Action<string>> commandExecutor;

        public CommandOperator(IBoard board, IScoreboard scoreboard)
        {
            this.commandExecutor = new Dictionary<string, Action<string>>()
            {
                ["exit"] = new EndGameCommand(board).Execute,
                ["top"] = new ShowScoreboardCommand(board, scoreboard).Execute,
                ["restart"] = new RestartCommand(board).Execute,
                ["play"] = new PlayCommand(board).Execute,
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