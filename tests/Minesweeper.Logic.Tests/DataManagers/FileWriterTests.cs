namespace Minesweeper.Logic.Tests.DataManagers
{
    using Logic.DataManagers;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FileWriterTests
    {
        [TestMethod]
        public void WriteAllTextShouldWriteAllTextToTheFile()
        {
            string path = "../../DataManagers/answer-to-the-universe.txt";
            string text = "42";
            var reader = new FileReader();
            var writer = new FileWriter();

            writer.WriteAllText(path, text);
            Assert.AreEqual(text, reader.ReadAllText(path));
        }
    }
}
