namespace Minesweeper.Logic.InputProviders.Contracts
{
    /// <summary>
    /// An interface providing a receive input line method
    /// </summary>
    public interface IInputProvider
    {
        /// <summary>
        /// A method receiving an input line and returning it as a string
        /// </summary>
        /// <returns>A string representation of the line received from an input provider</returns>
        string ReceiveInputLine();
    }
}
