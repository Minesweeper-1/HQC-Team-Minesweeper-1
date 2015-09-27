namespace MenuTest.Renderers.Contracts
{
    using System.Collections.Generic;

    using DifficultyCommands.Contracts;

    public interface IRenderer
    {
        void Render(string text);

        void RenderLine(string text);

        void SetCursor(int row, int col);

        void RenderMenu(IEnumerable<IGameMode> menuItems, int row, int col);

        int[] GetCursor();
    }
}
