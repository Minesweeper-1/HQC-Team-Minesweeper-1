namespace Minesweeper.Logic.Tests.DataManagers
{
    using Logic.DataManagers;
    using Logic.Players;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class JsonManagerTests
    {
        [TestMethod]
        public void ParseShouldGenerateSpecifiedObject()
        {
            string playerJson = "{\"Name\":\"Mara\",\"Score\":1024}";
            var jsonManager = new JsonManager();

            Player mara = jsonManager.Parse<Player>(playerJson);

            Assert.AreEqual(expected: "Mara", actual: mara.Name);
            Assert.AreEqual(expected: 1024, actual: mara.Score);
        }

        [TestMethod]
        public void ToStringRepresentationShouldGenerateCorrectJsonString()
        {
            string playerJson = "{\"Name\":\"Mara\",\"Score\":1024}";
            var jsonManager = new JsonManager();
            var mara = new Player()
            {
                Name = "Mara",
                Score = 1024
            };

            string stringMara = jsonManager.ToStringRepresentation(mara);

            Assert.AreEqual(playerJson, stringMara);
        }
    }
}
