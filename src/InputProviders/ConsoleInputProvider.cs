namespace Minesweeper.InputProviders
{
    using Minesweeper.InputProviders.Contracts;

    using System;

    public class ConsoleInputProvider : IInputProvider
    {
        public ConsoleInputProvider()
        {
        }

        public string Read()
        {
            string currentCommand = Console.ReadLine();
            return currentCommand;
        }
    }
}
