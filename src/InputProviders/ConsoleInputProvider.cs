namespace Minesweeper.InputProviders
{
    using static System.Console;

    using Contracts;

    public class ConsoleInputProvider : IInputProvider
    {
        public string GetLine() => ReadLine();
    }
}
