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
        private int menuTop = 0;
        private int menuLeft = 0;
        private int selectionCharTop;
        private int selectionCharLeft;

        private IGameMode finalSelection;
        private IRenderer renderer;
        private IInputProvider inputProvider;
        private IEnumerable<IGameMode> menuItems;

        public MenuHandler(IInputProvider inputProvider, IRenderer renderer)
        {
            this.inputProvider = inputProvider;
            this.renderer = renderer;
            this.finalSelection = new BeginnerMode();
            this.menuItems = new List<IGameMode>()
            {
                new BeginnerMode(),
                new IntermediateMode(),
                new ExpertMode()
            };

            this.selectionCharTop = this.menuTop + 1;
            this.selectionCharLeft = this.menuLeft;
        }

        public void ShowSelections()
        {
            this.renderer.RenderMenu(this.menuItems, this.menuTop, this.menuLeft);
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
                    if (this.selectionCharTop > 1)
                    {
                        this.finalSelection = this.finalSelection.GetPrevious();
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
                    if (this.selectionCharTop < 3)
                    {
                        this.finalSelection = this.finalSelection.GetNext();
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
