namespace Minesweeper.DataManagers
{
    using System.Web.Script.Serialization;

    using Contracts;

    public class JsonManager : IJsonManager
    {
        private readonly JavaScriptSerializer serializer;

        public JsonManager()
        {
            this.serializer = new JavaScriptSerializer();
        }

        public T Parse<T>(string jsonValue)
        {
            T result = this.serializer.Deserialize<T>(jsonValue);
            return result;
        }

        public string ToStringRepresentation<T>(T jsonObject)
        {
            string result = this.serializer.Serialize(jsonObject);
            return result;
        }
    }
}
