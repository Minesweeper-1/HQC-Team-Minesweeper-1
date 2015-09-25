namespace Minesweeper.DataManagers
{
    using System.Web.Script.Serialization;

    using Contracts;

    public class JsonManager : IJsonManager
    {
        private readonly JavaScriptSerializer serializer = new JavaScriptSerializer();

        public JsonManager()
        {
        }

        public T Parse<T>(string jsonValue)
        {
            return this.serializer.Deserialize<T>(jsonValue);
        }

        public string ToStringRepresentation<T>(T jsonObject)
        {
            return this.serializer.Serialize(jsonObject);
        }
    }
}
