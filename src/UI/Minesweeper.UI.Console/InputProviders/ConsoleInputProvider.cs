namespace Minesweeper.UI.Console.InputProviders
{
    using static System.Console;

    using Contracts;

    /// <summary>
    /// 
    /// </summary>
    public class ConsoleInputProvider : IConsoleInputProvider
    {
        /// <summary>
        /// Reads user input from console
        /// </summary>
        /// <returns>User input as a string</returns>
        public string ReceiveInputLine() => ReadLine();

        public bool IsKeyAvailable { get; } = KeyAvailable;

        public int GetKeyChar(bool justABool) => (int)ReadKey(true).Key;
    }
}
