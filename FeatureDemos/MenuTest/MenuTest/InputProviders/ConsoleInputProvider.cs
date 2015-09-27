namespace MenuTest.InputProviders
{
    using static System.Console;

    using Contracts;

    public class ConsoleInputProvider : IInputProvider
    {
        public bool IsKeyAvailable { get; } = KeyAvailable;

        public int GetKeyChar() => (int)ReadKey().Key;

        public int GetKeyChar(bool justABool) => (int)ReadKey(true).Key;
    }
}
