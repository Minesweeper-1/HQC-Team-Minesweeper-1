namespace Minesweeper.Engine.Contracts
{
    using Boards.Contracts;
    using Renderers.Contracts;

    public interface IMinesweeperEngine
    {
        IBoard Board { get; set; }

        IRenderer Renderer { get; set; }

        void Initialize();

        void Run();
    }
}
