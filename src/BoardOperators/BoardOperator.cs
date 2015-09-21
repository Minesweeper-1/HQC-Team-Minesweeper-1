namespace Minesweeper.BoardOperators
{
    using System;
    using System.Collections.Generic;

    using Boards.Contracts;
    using Common;
    using Common.Contracts;
    using Contracts;
    using Renderers.Contracts;
    using Scoreboards.Contracts;

    public class BoardOperator : IBoardOperator
    {
        private readonly IBoardCommand playCommand;
        private readonly IBoardCommand restartCommand;
        private readonly IBoardCommand showScoreboardCommand;
        private readonly IBoardCommand endGameCommand;

        private readonly IDictionary<string, Action<string>> commandExecutor;
        private readonly IScoreboard scoreboard;

        public BoardOperator(IBoard board, IRenderer renderer, IScoreboard scoreboard)
        {
            this.Board = board;
            this.Renderer = renderer;
            this.scoreboard = scoreboard;

            this.playCommand = new PlayCommand(board, renderer);
            this.restartCommand = new RestartCommand(board);
            this.showScoreboardCommand = new ShowScoreboardCommand(board, renderer, scoreboard);
            this.endGameCommand = new EndGameCommand(board);

            this.commandExecutor = new Dictionary<string, Action<string>>()
            {
                {
                    "exit", (t) => endGameCommand.Execute()
                },
                {
                    "top", (t) => showScoreboardCommand.Execute()
                },
                {
                    "restart", (t) => restartCommand.Execute()
                },
                {
                    "play", (param) => playCommand.Execute(param)
                }
            };
        }

        public IBoard Board
        {
            get;
            private set;
        }

        public IRenderer Renderer
        {
            get;
            private set;
        }

        public void ExecuteCommand(string command)
        {
            string commandToLowerCase = command.ToLower();
            if(!this.commandExecutor.ContainsKey(commandToLowerCase))
            {
                this.commandExecutor["play"](commandToLowerCase);
                return;
            }
           
            this.commandExecutor[commandToLowerCase](string.Empty);
        }

        public void Execute(IBoardCommand command)
        {
            command.Execute();
        }
    }
}