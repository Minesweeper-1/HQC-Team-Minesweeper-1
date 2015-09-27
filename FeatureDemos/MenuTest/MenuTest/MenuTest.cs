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
            var handler = new MenuHandler(inputProvider, renderer);
            handler.ShowSelections();
            handler.RequestUserSelection();
        }
    }
}
