namespace Minesweeper.UI.Console.Renderers.Contracts
{
    using System.Collections.Generic;

    using Logic.Renderers.Contracts;
    using Logic.DifficultyCommands.Contracts;

    public interface IConsoleRenderer : IRenderer
    {
        void Render(string line);

        void RenderLine(string line);

        void RenderWelcomeScreen(string welcomeScreen);

        void RenderNewPlayerCreationRequest();

        void RenderMenu(IEnumerable<IGameMode> menuItems, int row, int col);

        int[] GetCursor();

        void SetCursor(bool visible);

        void SetCursor(int row, int col);

        void ClearScreen();

        void ClearCurrentLine();
    }
}
