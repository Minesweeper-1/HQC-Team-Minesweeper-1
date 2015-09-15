namespace Minesweeper.Engine
{
    using Renderers.Contracts;
    using Boards.Contracts;
    using Contracts;
    using System;

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
            this.Renderer.RenderWelcomeLine();
            this.Board.Display();
        }

        public void Run()
        {
            while(true)
            {

            }
        }
    }
}
