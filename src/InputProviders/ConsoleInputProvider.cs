namespace Minesweeper.InputProviders
{
    using static System.Console;

    using Contracts;

    public class ConsoleInputProvider : IInputProvider
    {
        public string GetLine() => ReadLine();

        public bool IsKeyAvailable { get; } = KeyAvailable;

        public int GetKeyChar(bool justABool) => (int)ReadKey(true).Key;
    }
}
