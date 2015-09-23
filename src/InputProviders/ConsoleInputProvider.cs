namespace Minesweeper.InputProviders
{
    using global::Minesweeper.InputProviders.Contracts;

    using System;

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
