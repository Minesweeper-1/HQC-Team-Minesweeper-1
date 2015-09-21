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
        private IDictionary<string, IBoardCommand> commandExecutor;
        private readonly IScoreboard scoreboard;

        public BoardOperator(IBoard board, IRenderer renderer, IScoreboard scoreboard)
        {
            this.Board = board;
            this.Renderer = renderer;
            this.scoreboard = scoreboard;

            this.Initialize();
        }

        private void Initialize()
        {
            IBoardCommand playCommand = new PlayCommand(this.Board, this.Renderer);
            IBoardCommand restartCommand = new RestartCommand(this.Board);
            IBoardCommand showScoreboardCommand = new ShowScoreboardCommand(this.Board, this.Renderer, this.scoreboard);
            IBoardCommand endGameCommand = new EndGameCommand(this.Board);

            this.commandExecutor = new Dictionary<string, IBoardCommand>()
            {
                {
                    "exit",  endGameCommand
                },
                {
                    "top", showScoreboardCommand
                },
                {
                    "restart", restartCommand
                },
                {
                    "play", playCommand
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
            if (!this.commandExecutor.ContainsKey(commandToLowerCase))
            {
                this.commandExecutor["play"].Execute(commandToLowerCase);
                return;
            }

            this.commandExecutor[commandToLowerCase].Execute();
        }
    }
}