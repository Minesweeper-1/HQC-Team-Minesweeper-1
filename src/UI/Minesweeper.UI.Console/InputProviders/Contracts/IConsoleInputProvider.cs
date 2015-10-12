namespace Minesweeper.UI.Console.InputProviders.Contracts
{
    using Logic.InputProviders.Contracts;

    /// <summary>
    /// Provides an interface for a console input provider public members
    /// </summary>
    public interface IConsoleInputProvider : IInputProvider
    {
        /// <summary>
        /// Check if there is an available key
        /// </summary>
        bool IsKeyAvailable { get; }

        /// <summary>
        /// Gets the character correspoding to the pressed key
        /// </summary>
        /// <returns>Char int code</returns>
        int GetKeyChar();

        /// <summary>
        /// Transforms the command input from (int char) to (int int)
        /// </summary>
        /// <param name="initialCommandInput">(int char) command to transform</param>
        /// <returns>Command of type (int int)</returns>
        string TransformCommandToNumbersOnly(string initialCommandInput);
    }
}
