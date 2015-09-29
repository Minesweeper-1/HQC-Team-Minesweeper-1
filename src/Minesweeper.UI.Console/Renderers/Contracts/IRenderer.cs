namespace Minesweeper.UI.Renderers.Contracts
{
    using System;
    using System.Collections.Generic;

    using Minesweeper.Logic.Boards.Contracts;
    using Minesweeper.Logic.DifficultyCommands.Contracts;

    public interface IRenderer
    {
        void Render(string line);

        void RenderLine(string line);

        void RenderBoard(IBoard board, int row, int col);

        void RenderWelcomeScreen(string welcomeScreen);

        void RenderNewPlayerCreationRequest();

        void RenderMenu(IEnumerable<IGameMode> menuItems, int row, int col);

        int[] GetCursor();

        void SetCursor(bool visible);

        void SetCursor(int row, int col);

        void ClearScreen();

        void ClearCurrentLine();

        void SetForegroundColor(Enum color);

        void SetBackgroundColor(Enum color);

        void ResetForegroundColor();

        void ResetBackgroundColor();
    }
}
