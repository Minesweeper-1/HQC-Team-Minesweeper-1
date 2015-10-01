﻿namespace Minesweeper.UI.MenuHandlers
{
    using System.Collections.Generic;

    using Minesweeper.Logic.Common;
    using Contracts;

    using Minesweeper.Logic.Boards;
    using Minesweeper.Logic.DifficultyCommands;
    using Minesweeper.Logic.DifficultyCommands.Contracts;
    using Minesweeper.UI.Console;
    using Minesweeper.UI.Console.Engine;
    using Minesweeper.UI.Console.InputProviders;
    using Minesweeper.UI.Console.InputProviders.Contracts;
    using Renderers.Contracts;

    // The engine will observe whether the MenuHandler has come to a final game mode resolution
    public class ConsoleMenuHandler : IMenuHandler
    {
        private int menuBodyTop = 10;
        private int menuBodyLeft = 5;
        private int selectionCharTop;
        private int selectionCharLeft;

        private IGameMode currentSelection;
        private IRenderer renderer;
        private IInputProvider inputProvider;
        private IEnumerable<IGameMode> menuItems;

        public ConsoleMenuHandler(IInputProvider inputProvider, IRenderer renderer, IEnumerable<IGameMode> menuItems, int menuTop, int menuLeft)
        {
            this.inputProvider = inputProvider;
            this.renderer = renderer;
            this.currentSelection = new BeginnerMode();
            this.menuItems = menuItems;
            this.menuBodyTop = menuTop + GlobalConstants.MenuTitleRowsCount;
            this.menuBodyLeft = menuLeft;
            this.selectionCharTop = menuTop + GlobalConstants.MenuTitleRowsCount;
            this.selectionCharLeft = this.menuBodyLeft;
        }

        public void ShowSelections()
        {
            this.renderer.RenderMenu(this.menuItems, this.menuBodyTop - GlobalConstants.MenuTitleRowsCount, this.menuBodyLeft);
        }

        public void RequestUserSelection()
        {
            while (!this.inputProvider.IsKeyAvailable)
            {
                var cursor = this.renderer.GetCursor();

                var key = this.GetKey();
                if (key == ConsoleGameKey.Enter)
                {
                    Game.DifficultyLevel = this.currentSelection.Settings;

                    break;
                }
                else if (key == ConsoleGameKey.Up)
                {
                    if (this.selectionCharTop > this.menuBodyTop)
                    {
                        this.currentSelection = this.currentSelection.GetPrevious();
                        this.renderer.SetCursor(this.selectionCharTop, this.selectionCharLeft);
                        this.renderer.Render(" ");
                        this.renderer.SetCursor(this.selectionCharTop - 1, this.selectionCharLeft);
                        this.selectionCharTop -= 1;
                        this.renderer.Render(GlobalConstants.SelectionChar);
                        this.renderer.SetCursor(cursor[0], cursor[1]);
                    }
                }
                else if (key == ConsoleGameKey.Down)
                {
                    if (this.selectionCharTop < this.menuBodyTop + 2)
                    {
                        this.currentSelection = this.currentSelection.GetNext();
                        this.renderer.SetCursor(this.selectionCharTop, this.selectionCharLeft);
                        this.renderer.Render(" ");
                        this.renderer.SetCursor(this.selectionCharTop + 1, this.selectionCharLeft);
                        this.selectionCharTop += 1;
                        this.renderer.Render(GlobalConstants.SelectionChar);
                        this.renderer.SetCursor(cursor[0], cursor[1]);
                    }
                }
            }
        }

        private ConsoleGameKey GetKey()
        {
            ConsoleGameKey keyPressed;
            keyPressed = (ConsoleGameKey)this.inputProvider.GetKeyChar(true);
            return keyPressed;
        }

        private BoardSettings SetSettings()
        {
            return this.currentSelection.Settings;
        }
    }
}
