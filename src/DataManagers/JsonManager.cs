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

        public T Parse<T>(string jsonString)
        {
            T result = this.serializer.Deserialize<T>(jsonString);
            return result;
        }

        public string Stringify<T>(T jsonObject)
        {
            string result = this.serializer.Serialize(jsonObject);
            return result;
        }
    }
}
