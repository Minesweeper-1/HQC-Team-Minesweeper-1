namespace Minesweeper.UI.Console.InputProviders
{
    using System;
    using static System.Console;

    using Contracts;
    using Logic.InputProviders.Contracts;
    using Renderers.Common;

    /// <summary>
    /// Concrete implementation of the IConsoleInputProvider and IInputProvider interfaces
    /// </summary>
    public class ConsoleInputProvider : IConsoleInputProvider, IInputProvider
    {
        /// <summary>
        /// Reads user input from console
        /// </summary>
        /// <returns>User input as a string</returns>
        public string ReceiveInputLine() => ReadLine();

        /// <summary>
        /// Returns whether there is a key available for pressing
        /// </summary>
        public bool IsKeyAvailable { get; } = KeyAvailable;

        /// <summary>
        /// Returns the character code of the pressed key
        /// </summary>
        /// <returns>The charcter code of the pressed key</returns>
        public int GetKeyChar() => (int)ReadKey(intercept: true).Key;

        /// <summary>
        /// Converts a command from (int)(char) type to (int)(int) type
        /// </summary>
        /// <param name="initialCommandInput">Command of type (int)(char)</param>
        /// <returns>Command of type (int)(int)</returns>
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
