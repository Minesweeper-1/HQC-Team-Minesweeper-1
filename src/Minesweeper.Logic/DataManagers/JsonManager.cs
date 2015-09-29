namespace Minesweeper.Logic.DataManagers
{
    using System.Web.Script.Serialization;

    using Contracts;

    public class JsonManager : IJsonManager
    {
        private readonly JavaScriptSerializer serializer = new JavaScriptSerializer();

        public T Parse<T>(string jsonValue) => this.serializer.Deserialize<T>(jsonValue);

        public string ToStringRepresentation<T>(T jsonObject) => this.serializer.Serialize(jsonObject);
    }
}
