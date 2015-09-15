namespace Minesweeper.Renderers
{
    using System;
    using Contracts;

    public class ConsoleRenderer : IRenderer
    {
        public ConsoleRenderer()
        {

        }

        public void Write(string line)
        {
            Console.WriteLine(line);
        }
    }
}
