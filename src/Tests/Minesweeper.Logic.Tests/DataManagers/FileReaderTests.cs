namespace Minesweeper.Logic.Tests.DataManagers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Logic.DataManagers;

    [TestClass]
    public class FileReaderTests
    {
        [TestMethod]
        public void ReadAllTextShouldReadAllOfTheFileContents()
        {
            string source = "../../DataManagers/top-secret.txt";
            string result = "Pesho";
            var reader = new FileReader();
            var writer = new FileWriter();
            writer.WriteAllText(source, result);

            Assert.AreEqual(result, reader.ReadAllText(source));
        }
    }
}
