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
    }
}
