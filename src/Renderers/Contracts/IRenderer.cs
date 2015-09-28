namespace Minesweeper.Renderers.Contracts
{
    using System.Collections.Generic;

    using Boards.Contracts;
    using DifficultyCommands.Contracts;

    public interface IRenderer
    {
        void Render(string line);

        void RenderLine(string line);

        void RenderBoard(IBoard board, int row, int col);

        void RenderWelcomeScreen(string welcomeScreen);

        void RenderMenu(IEnumerable<IGameMode> menuItems, int row, int col);

        int[] GetCursor();

        void SetCursor(bool visible);

        void SetCursor(int row, int col);

        void ClearScreen();

        void ClearCurrentConsoleLine();
    }
}
