namespace Minesweeper.Renderers
{
    using System;
    using Contracts;

    public class ConsoleRenderer : IRenderer
    {
        public ConsoleRenderer()
        {

        }

        private void Write(string line)
        {
            Console.WriteLine(line);
        }

        public void RenderWelcomeLine()
        {
            string welcomeLine = "Welcome to the all-time classic Minesweeper. Use your mind to tackle the mines.";
            this.Write(welcomeLine);
        }
    }
}
