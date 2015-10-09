namespace Minesweeper.Logic.DataManagers
{
    using System.Web.Script.Serialization;

    using Contracts;

    /// <summary>
    /// An interface providing an implementation of the IJsonManager interface
    /// </summary>
    public class JsonManager : IJsonManager
    {
        private readonly JavaScriptSerializer serializer = new JavaScriptSerializer();

        /// <summary>
        /// A generic method for parsing a JSON string to a generic type
        /// </summary>
        /// <typeparam name="T">The type to be returned</typeparam>
        /// <param name="jsonValue">The string to be parsed to the given generic type</param>
        /// <returns>An object of generic type obtained from the parsing</returns>
        public T Parse<T>(string jsonValue) => this.serializer.Deserialize<T>(jsonValue);

        /// <summary>
        /// A generic method for parsing a generic object to string
        /// </summary>
        /// <typeparam name="T">The generic type of the parameter</typeparam>
        /// <param name="jsonObject">The object to be serialized</param>
        /// <returns>The string representation of the passed generic object</returns>
        public string ToStringRepresentation<T>(T jsonObject) => this.serializer.Serialize(jsonObject);
    }
}
