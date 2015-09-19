namespace Minesweeper.Renderers.Contracts
{
    using Boards.Contracts;

    public interface IRenderer
    {
        void Render(string line);

        void RenderLine(string line);

        void RenderBoard(IBoard board);

        void Clear();
    }
}
