namespace MenuTest.Renderers
{
    using System.Collections.Generic;
    using static System.Console;

    using Common;
    using Contracts;
    using DifficultyCommands.Contracts;

    public class ConsoleRenderer : IRenderer
    {
        public void Render(string text) => Write(text);

        public void RenderLine(string text) => WriteLine(text);

        public void SetCursor(int row, int col) => SetCursorPosition(col, row);

        public void RenderMenu(IEnumerable<IGameMode> menuItems, int row, int col)
        {
            int linesCountBeforeFirstMenuItem = 1;

            CursorVisible = false;
            this.SetCursor(row, col);
            this.RenderLine("[===== Select game mode =====]");
            foreach (var item in menuItems)
            {
                this.RenderLine(RenderersConstants.SelectionPrefix + item.Value);
            }

            var cursorPosition = this.GetCursor();

            // Set default menu item selection
            this.SetCursor(row + linesCountBeforeFirstMenuItem, col);
            this.Render(RenderersConstants.SelectionChar);

            // Reset cursor position
            this.SetCursor(cursorPosition[0], cursorPosition[1]);
        }

        public int[] GetCursor()
        {
            return new int[] { CursorTop, CursorLeft };
        }
    }
}
