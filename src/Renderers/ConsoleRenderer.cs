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
            for (int row = -2; row < rows + 1; row++)
            {
                if (row >= 0 && row < rows)
                {
                    this.Render(row + GlobalConstants.ColsRenderingDivider);
                }

                if (row == -1 || row == rows)
                {
                    this.Render(" " + GlobalConstants.ColsRenderingDivider);
                }

                for (int col = 0; col < cols + 1; col++)
                {
                    if (row < 0)
                    {
                        if (row == -1)
                        {
                            this.Render(GlobalConstants.ColsRenderingDivider);
                        }

                        else
                        {
                            if (col == 0)
                            {
                                this.Render("    " + col);
                            }

                            else
                            {
                                if (col < cols)
                                {
                                    this.Render(" " + col);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (row == rows)
                        {
                            this.Render(GlobalConstants.ColsRenderingDivider);
                        }
                        else
                        {
                            if (col == cols)
                            {
                                this.Render(GlobalConstants.ColsRenderingDivider);
                            }
                            else
                            {
                                string charToRender = matrix[row, col].ToString();
                                if (charToRender == GlobalConstants.StandardUnrevealedBoardCellCharacter.ToString())
                                {
                                    this.SetForegroundColor("dark cyan");
                                }
                                else if (charToRender == "1")
                                {
                                    this.SetForegroundColor("blue");
                                }
                                else if (charToRender == "2")
                                {
                                    this.SetForegroundColor("green");
                                }
                                else if (charToRender == "3")
                                {
                                    this.SetForegroundColor("red");
                                }

                                this.Render(GlobalConstants.GameCellsDivider);
                                this.Render(charToRender);
                                this.ResetForegroundColor();
                            }
                        }
                    }
                }

                this.RenderLine(string.Empty);
            }

        }

        public void SetForegroundColor(string color)
        {
            string processedColor = color.Trim().ToLower();
            switch (processedColor)
            {
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "dark cyan":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }

        public void ResetForegroundColor()
        {
            this.SetForegroundColor(string.Empty);
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
