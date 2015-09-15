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
            Console.Write(line);
        }

        public void RenderLine(string line)
        {
            Console.WriteLine(line);
        }

        public void RenderMatrix(char[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            this.RenderLine(string.Empty);
            for (int row = -2; row < rows; row++)
            {
                if (row >= 0)
                {
                    this.Render(row + " |");
                }

                for (int col = 0; col < cols; col++)
                {
                    if (row < 0)
                    {
                        if (row == -1)
                        {
                            if (col == 0)
                            {
                                this.Render("    _");
                            }

                            else
                            {
                                this.Render(" _");
                            }
                        }

                        else
                        {
                            if (col == 0)
                            {
                                this.Render("    " + col);
                            }

                            else
                            {
                                this.Render(" " + col);
                            }
                        }
                    }
                    else
                    {
                        this.Render(" ");
                        this.Render(matrix[row, col].ToString());
                    }
                }

                this.RenderLine(string.Empty);
            }
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
