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
            int linesCountBeforeFirstMenuItem = RenderersConstants.MenuTitleRowsCount;
            var cursorRow = row + linesCountBeforeFirstMenuItem;

            CursorVisible = false;

            this.RenderMenuTitle(row, col);
            foreach (var item in menuItems)
            {
                this.SetCursor(cursorRow++, col);
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

        private void RenderMenuTitle(int row, int col)
        {
            this.SetCursor(row, col);
            foreach (var line in RenderersConstants.MenuTitle)
            {
                this.SetCursor(row++, col);
                this.RenderLine(line);
            }
        }
    }
}
