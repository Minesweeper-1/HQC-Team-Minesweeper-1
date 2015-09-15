namespace Minesweeper.Engine
{
    using Renderers.Contracts;
    using Boards.Contracts;
    using Contracts;

    public class StandardOnePlayerMinesweepwerEngine : IMinesweeperEngine
    {
        public StandardOnePlayerMinesweepwerEngine(IBoard board, IRenderer renderer)
        {
            this.Board = board;
            this.Renderer = renderer;
        }

        public IBoard Board { get; set; }

        public IRenderer Renderer { get; set; }

        public void Initialize()
        {
            string welcomeLine = "Welcome to the all-time classic Minesweeper. Use your mind to tackle the mines.";
            this.Renderer.Write(welcomeLine);
            this.Board.Display();
        }
    }
}
