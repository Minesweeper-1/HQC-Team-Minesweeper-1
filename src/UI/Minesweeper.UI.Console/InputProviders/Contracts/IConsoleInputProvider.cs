namespace Minesweeper.UI.Console.InputProviders.Contracts
{
    using Logic.InputProviders.Contracts;

    public interface IConsoleInputProvider : IInputProvider
    {
        /// <summary>
        /// Chekc if there is keyboard input
        /// </summary>
        bool IsKeyAvailable { get; }

        /// <summary>
        /// Gets the char correspoding to the press key
        /// </summary>
        /// <param name="justABool"></param>
        /// <returns>Char int code</returns>
        int GetKeyChar(bool justABool);

        /// <summary>
        /// Transforms the command input from (int char) to (int int)
        /// </summary>
        /// <param name="initialCommandInput">(int char) command to transform</param>
        /// <returns>Command of type (int int)</returns>
        string TransformCommandToNumbersOnly(string initialCommandInput);
    }
}
