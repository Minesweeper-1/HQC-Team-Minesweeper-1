namespace MenuTest.MenuHandlers
{
    using System.Collections.Generic;

    using Contracts;
    using DifficultyCommands;
    using DifficultyCommands.Contracts;
    using InputProviders.Contracts;
    using Renderers.Common;
    using Renderers.Contracts;

    // The engine will observe whether the MenuHandler has come to a final game mode resolution
    public class MenuHandler : IMenuHandler
    {
        private int menuBodyTop = 10;
        private int menuBodyLeft = 5;
        private int selectionCharTop;
        private int selectionCharLeft;

        private IGameMode currentSelection;
        private IRenderer renderer;
        private IInputProvider inputProvider;
        private IEnumerable<IGameMode> menuItems;

        public MenuHandler(IInputProvider inputProvider, IRenderer renderer, IEnumerable<IGameMode> menuItems, int menuTop, int menuLeft)
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

        public void ShowSelections()
        {
            this.renderer.RenderMenu(this.menuItems, this.menuBodyTop - RenderersConstants.MenuTitleRowsCount, this.menuBodyLeft);
        }

        public void RequestUserSelection()
        {
            while (!this.inputProvider.IsKeyAvailable)
            {
                var cursor = this.renderer.GetCursor();

                var key = this.GetKey();
                if (key == GameKey.Enter)
                {
                    // Notify subscribers
                    break;
                }
                else if (key == GameKey.Up)
                {
                    if (this.selectionCharTop > this.menuBodyTop)
                    {
                        this.currentSelection = this.currentSelection.GetPrevious();
                        this.renderer.SetCursor(this.selectionCharTop, this.selectionCharLeft);
                        this.renderer.Render(" ");
                        this.renderer.SetCursor(this.selectionCharTop - 1, this.selectionCharLeft);
                        this.selectionCharTop -= 1;
                        this.renderer.Render(RenderersConstants.SelectionChar);
                        this.renderer.SetCursor(cursor[0], cursor[1]);
                    }
                }
                else if (key == GameKey.Down)
                {
                    if (this.selectionCharTop < this.menuBodyTop + 2)
                    {
                        this.currentSelection = this.currentSelection.GetNext();
                        this.renderer.SetCursor(this.selectionCharTop, this.selectionCharLeft);
                        this.renderer.Render(" ");
                        this.renderer.SetCursor(this.selectionCharTop + 1, this.selectionCharLeft);
                        this.selectionCharTop += 1;
                        this.renderer.Render(RenderersConstants.SelectionChar);
                        this.renderer.SetCursor(cursor[0], cursor[1]);
                    }
                }
            }
        }

        private GameKey GetKey()
        {
            GameKey keyPressed;
            keyPressed = (GameKey)this.inputProvider.GetKeyChar(true);
            return keyPressed;
        }
    }
}
