namespace Minesweeper.Logic.CommandOperators
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    using Boards.Contracts;
    using Common;
    using Contracts;
    using Scoreboards.Contracts;

    /// <summary>
    /// A class implementing the ICommandOperator interface and dealing appropriately with the incoming command
    /// </summary>
    public class CommandOperator : ICommandOperator
    {
        private readonly IDictionary<string, Action<string>> commandExecutor;

        /// <summary>
        /// The constructor setting a dictionary of commands and corresponding actions
        /// </summary>
        /// <param name="board">The current playing board</param>
        /// <param name="scoreboard">The current scoreboard</param>
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

        /// <summary>
        /// The concrete implementation of the Execute method
        /// </summary>
        /// <param name="command"></param>
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