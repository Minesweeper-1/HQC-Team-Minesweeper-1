namespace MenuTest
{
    using System.Collections.Generic;

    using DifficultyCommands;
    using DifficultyCommands.Contracts;
    using InputProviders;
    using MenuHandlers;
    using Renderers;

    public class MenuTest
    {
        public static void Main()
        {
            var renderer = new ConsoleRenderer();
            var inputProvider = new ConsoleInputProvider();
            var menuItems = new List<IGameMode>()
            {
                new BeginnerMode(),
                new IntermediateMode(),
                new ExpertMode()
            };

            var handler = new MenuHandler(inputProvider, renderer, menuItems, 0, 0);
            handler.ShowSelections();
            handler.RequestUserSelection();
        }
    }
}
