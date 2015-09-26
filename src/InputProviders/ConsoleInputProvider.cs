namespace Minesweeper.InputProviders
{
    using static System.Console;

    using Contracts;

    public class ConsoleInputProvider : IInputProvider
    {
        public ConsoleInputProvider()
        {
        }

        public string GetLine()
        {
            return ReadLine();
        }
    }
}
