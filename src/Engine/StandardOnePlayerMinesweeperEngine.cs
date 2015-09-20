namespace Minesweeper.Engine
{
    using Boards.Contracts;
    using Common;
    using Contracts;
    using InputProviders.Contracts;
    using BoardOperators.Contracts;
    using Renderers.Contracts;

    public class StandardOnePlayerMinesweeperEngine : IMinesweeperEngine, IBoardObserver
    {
        public StandardOnePlayerMinesweeperEngine(IBoard board, IRenderer renderer, IInputProvider inputProvider, IBoardOperator boardOperator)
        {
            this.Board = board;
            this.BoardOperator = boardOperator;
            this.Renderer = renderer;
            this.InputProvider = inputProvider;
            this.GameState = this.Board.BoardState;
        }

        public IBoard Board { get; set; }

        public IBoardOperator BoardOperator { get; set; }

        public IRenderer Renderer { get; set; }

        public IInputProvider InputProvider { get; set; }

        public BoardState GameState { get; set; }

        public void Initialize(IGameInitializationStrategy initializationStrategy)
        {
            initializationStrategy.Initialize(this.Board);
        }

        // TODO: Extract these magic coordinates
        public void Run()
        {
            int boardStartRenderX = 5;
            int boardStartRenderY = 5;
            string welcomeLine = "Welcome to the all-time classic Minesweeper. Use your mind to tackle the mines.";
            this.Renderer.RenderLine(welcomeLine);
            this.Renderer.RenderBoard(this.Board, boardStartRenderX, boardStartRenderY);
            this.Renderer.SetCursorPosition(boardStartRenderX + this.Board.Rows + 1, col: 0);

            while (true)
            {
                string command = this.InputProvider.Read();
                this.BoardOperator.ExecuteCommand(command);

                if (this.GameState == BoardState.Closed)
                {
                    return;
                }
                else if (this.GameState == BoardState.Pending)
                {
                    continue;
                }
                else if (this.GameState == BoardState.Open)
                {
                    this.Renderer.RenderBoard(this.Board, boardStartRenderX, boardStartRenderY);
                    this.Renderer.SetCursorPosition(boardStartRenderX + this.Board.Rows + 1, col: 0);
                }

                this.Renderer.ClearCurrentConsoleLine();
            }
        }

        public void Update(BoardState boardState)
        {
            this.GameState = boardState;
        }
    }
}
