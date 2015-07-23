namespace Minesweeper.InputProviders
{
    using Minesweeper.InputProviders.Contracts;

    using System;

    internal class ConsoleInputProvider : IInputProvider
    {
        public ConsoleInputProvider()
        {
        }

        public string Read()
        {
            var currentCommand = Console.ReadLine();
            return currentCommand;
        }
    }
}
