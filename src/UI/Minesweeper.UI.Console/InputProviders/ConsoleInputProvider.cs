namespace Minesweeper.UI.Console.InputProviders
{
    using static System.Console;

    using Contracts;
    using System;
    using Renderers.Common;

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

        public string TransformCommandToNumbersOnly(string initialCommandInput)
        {
            string result = initialCommandInput;

            string[] commandParts = initialCommandInput.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (commandParts.Length == 2 && commandParts[1].Length == 1)
            {
                commandParts[1] = RenderersConstants.IndexLetters.ToLowerInvariant()
                                  .IndexOf(commandParts[1][0].ToString().ToLowerInvariant(),
                                           StringComparison.InvariantCulture)
                                  .ToString();

                result = string.Join(separator: " ", value: commandParts);
            }

            return result;
        }
    }
}
