namespace Minesweeper.Renderers.Contracts
{
    public interface IRenderer
    {
        void Render(string line);

        void RenderLine(string line);

        void RenderMatrix(char[,] matrix);

        void Clear();
    }
}
