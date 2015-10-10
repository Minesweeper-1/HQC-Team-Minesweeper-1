namespace Minesweeper.UI.Console.MenuHandlers
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Logic.Boards.Settings.Contracts;
    using Logic.DifficultyCommands;
    using Logic.DifficultyCommands.Contracts;
    using InputProviders.Contracts;
    using Renderers.Contracts;
    using Renderers.Common;

    // The engine will observe whether the MenuHandler has come to a final game mode resolution
    public class ConsoleMenuHandler : IMenuHandler
    {
        private readonly int menuBodyTop = 10;
        private readonly int menuBodyLeft = 5;
        private int selectionCharTop;
        private readonly int selectionCharLeft;

        private IGameMode currentSelection;
        private readonly IConsoleRenderer renderer;
        private readonly IConsoleInputProvider inputProvider;
        private readonly IEnumerable<IGameMode> menuItems;

        public ConsoleMenuHandler(IConsoleInputProvider inputProvider, IConsoleRenderer renderer, IEnumerable<IGameMode> menuItems, int menuTop, int menuLeft)
        {
            this.inputProvider = inputProvider;
            this.renderer = renderer;
            this.currentSelection = new BeginnerMode();
            this.menuItems = menuItems;
            this.menuBodyTop = menuTop + RenderersConstants.MenuTitleRowsCount;
            this.menuBodyLeft = menuLeft;
            this.selectionCharTop = menuTop + RenderersConstants.MenuTitleRowsCount;
            this.selectionCharLeft = this.menuBodyLeft;

        }

        /// <summary>
        /// Indicates the seleted menu option
        /// </summary>
        public void ShowSelections()
        {
            this.renderer.RenderMenu(this.menuItems, this.menuBodyTop - RenderersConstants.MenuTitleRowsCount, this.menuBodyLeft);
        }

        /// <summary>
        /// Wait for user input to modify board settings
        /// </summary>
        /// <returns>Returs board settings</returns>
        public BoardSettings RequestUserSelection()
        {
            while (!this.inputProvider.IsKeyAvailable)
            {
                int[] cursor = this.renderer.GetCursor();
                ConsoleKey key = this.GetKey();

                if (key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (key == ConsoleKey.UpArrow && this.selectionCharTop > this.menuBodyTop)
                {
                    this.SetPreviousMenuItem(cursor);
                }
                else if (key == ConsoleKey.DownArrow && this.selectionCharTop < this.menuBodyTop + 2)
                {
                    this.SetNextMenuItem(cursor);
                }
            }

            return this.currentSelection.Settings;
        }

        /// <summary>
        /// Redraw deselected menu option
        /// </summary>
        /// <param name="cursor"></param>
        private void SetPreviousMenuItem(int[] cursor)
        {
            this.currentSelection = this.currentSelection.GetPrevious();
            this.renderer.SetCursor(this.selectionCharTop, this.selectionCharLeft);
            this.renderer.Render(" ");
            this.renderer.SetCursor(this.selectionCharTop - 1, this.selectionCharLeft);
            this.selectionCharTop -= 1;
            this.renderer.Render(RenderersConstants.SelectionChar);
            this.renderer.SetCursor(cursor[0], cursor[1]);
        }

        /// <summary>
        /// Draw current option
        /// </summary>
        /// <param name="cursor"></param>
        private void SetNextMenuItem(int[] cursor)
        {
            this.currentSelection = this.currentSelection.GetNext();
            this.renderer.SetCursor(this.selectionCharTop, this.selectionCharLeft);
            this.renderer.Render(" ");
            this.renderer.SetCursor(this.selectionCharTop + 1, this.selectionCharLeft);
            this.selectionCharTop += 1;
            this.renderer.Render(RenderersConstants.SelectionChar);
            this.renderer.SetCursor(cursor[0], cursor[1]);
        }

        /// <summary>
        /// Returns pressed key
        /// </summary>
        /// <returns></returns>
        private ConsoleKey GetKey()
        {
            ConsoleKey keyPressed;
            keyPressed = (ConsoleKey)this.inputProvider.GetKeyChar(true);
            return keyPressed;
        }

        /// <summary>
        /// Generate board settings to be passed to enigne
        /// </summary>
        /// <returns>Updated board settings</returns>
        private BoardSettings SetSettings()
        {
            return this.currentSelection.Settings;
        }
    }
}
