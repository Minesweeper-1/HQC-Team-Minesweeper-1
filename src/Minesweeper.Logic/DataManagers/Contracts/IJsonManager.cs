namespace Minesweeper.Logic.DataManagers.Contracts
{
    /// <summary>
    /// Interface for dealing with JSON objects
    /// </summary>
    public interface IJsonManager
    {
        /// <summary>
        /// A generic method for parsing JSON object passed as a string
        /// </summary>
        /// <typeparam name="T">The generic type to be returned as a result</typeparam>
        /// <param name="jsonValue">The stringified JSON object</param>
        /// <returns>The generic type of the result of the parsing</returns>
        T Parse<T>(string jsonValue);

        /// <summary>
        /// A generic method for parsing a generic object to string
        /// </summary>
        /// <typeparam name="T">The generic type of the parameter</typeparam>
        /// <param name="jsonObject">The object to stringify</param>
        /// <returns>The string representation of the passed generic object</returns>
        string ToStringRepresentation<T>(T jsonObject);
    }
}
