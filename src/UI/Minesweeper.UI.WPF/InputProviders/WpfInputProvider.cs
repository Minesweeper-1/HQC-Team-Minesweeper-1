namespace Minesweeper.UI.Console.InputProviders
{
    using static System.Console;

    using Contracts;

    public class ConsoleInputProvider : IConsoleInputProvider
    {
        public string ReceiveInputLine() => ReadLine();

        public bool IsKeyAvailable { get; } = KeyAvailable;

        public int GetKeyChar(bool justABool) => (int)ReadKey(true).Key;
    }
}
