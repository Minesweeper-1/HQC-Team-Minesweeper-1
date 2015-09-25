namespace Minesweeper.InputProviders
{
    using System;

    using Contracts;

    public class ConsoleInputProvider : IInputProvider
    {
        public ConsoleInputProvider()
        {
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
