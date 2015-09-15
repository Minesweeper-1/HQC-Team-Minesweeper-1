namespace Minesweeper.Renderers
{
    using System;
    using Contracts;

    public class ConsoleRenderer : IRenderer
    {
        public ConsoleRenderer()
        {

        }

        public void Render(string line)
        {
            Console.WriteLine(line);
        }
    }
}
