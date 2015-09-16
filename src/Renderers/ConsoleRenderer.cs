namespace Minesweeper.Renderers
{
    using System;
    using Contracts;
    using Common;

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

        public void RenderMatrix<T>(T[,] matrix)
        {
            int rows = matrix.GetLength(GlobalConstants.MatrixRowsDimensionIndex);
            int cols = matrix.GetLength(GlobalConstants.MatrixColsDimensionIndex);

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
                                this.Render(GlobalConstants.ColsRenderingStartDivider);
                            }

                            else
                            {
                                this.Render(GlobalConstants.ColsRenderingBaseDivider);
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
                        this.Render(GlobalConstants.GameCellsDivider);
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
