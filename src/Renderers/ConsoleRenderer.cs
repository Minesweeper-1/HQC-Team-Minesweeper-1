namespace Minesweeper.Renderers
{
    using System;
    using Contracts;
    using Common;
    using Cells.Contracts;
    using Boards.Contracts;

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

        public void RenderBoard(IBoard board)
        {
            ICell[,] boardCells = board.Cells;

            int rows = boardCells.GetLength(GlobalConstants.MatrixRowsDimensionIndex);
            int cols = boardCells.GetLength(GlobalConstants.MatrixColsDimensionIndex);

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
                                string charToRenderAsString = this.GetCellCharAsString(boardCells[row, col]);
                                if (charToRenderAsString == GlobalConstants.StandardUnrevealedBoardCellCharacter.ToString())
                                {
                                    this.SetForegroundColor("dark cyan");
                                }
                                else if (charToRenderAsString == "0")
                                {
                                    this.SetForegroundColor("magenta");
                                }
                                else if (charToRenderAsString == "1")
                                {
                                    this.SetForegroundColor("blue");
                                }
                                else if (charToRenderAsString == "2")
                                {
                                    this.SetForegroundColor("green");
                                }
                                else if (charToRenderAsString == "3")
                                {
                                    this.SetForegroundColor("red");
                                }
                                else if (charToRenderAsString == "4")
                                {
                                    this.SetForegroundColor("dark green");
                                }
                                else if (charToRenderAsString == "5")
                                {
                                    this.SetForegroundColor("dark magenta");
                                }

                                this.Render(GlobalConstants.GameCellsDivider);
                                this.Render(charToRenderAsString);
                                this.ResetForegroundColor();
                            }
                        }
                    }
                }

                this.RenderLine(string.Empty);
            }

            // Lines for debugging purposes
            this.RenderRevealedCellsBoard(board);
        }

        private void RenderRevealedCellsBoard(IBoard board)
        {
            ICell[,] boardCells = board.Cells;

            int rows = boardCells.GetLength(GlobalConstants.MatrixRowsDimensionIndex);
            int cols = boardCells.GetLength(GlobalConstants.MatrixColsDimensionIndex);

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
                                string charToRenderAsString = this.GetCellContentValue(boardCells[row, col]);
                                if (charToRenderAsString == GlobalConstants.StandardUnrevealedBoardCellCharacter.ToString())
                                {
                                    this.SetForegroundColor("dark cyan");
                                }
                                else if (charToRenderAsString == "0")
                                {
                                    this.SetForegroundColor("magenta");
                                }
                                else if (charToRenderAsString == "1")
                                {
                                    this.SetForegroundColor("blue");
                                }
                                else if (charToRenderAsString == "2")
                                {
                                    this.SetForegroundColor("green");
                                }
                                else if (charToRenderAsString == "3")
                                {
                                    this.SetForegroundColor("red");
                                }
                                else if (charToRenderAsString == "4")
                                {
                                    this.SetForegroundColor("dark green");
                                }
                                else if (charToRenderAsString == "5")
                                {
                                    this.SetForegroundColor("dark magenta");
                                }

                                this.Render(GlobalConstants.GameCellsDivider);
                                this.Render(charToRenderAsString);
                                this.ResetForegroundColor();
                            }
                        }
                    }
                }

                this.RenderLine(string.Empty);
            }
        }

        private string GetCellCharAsString(ICell cell)
        {
            string cellCharAsString = string.Empty;

            CellState cellState = cell.State;
            switch (cellState)
            {
                case CellState.Sealed:
                    cellCharAsString = GlobalConstants.StandardUnrevealedBoardCellCharacter.ToString();
                    break;
                case CellState.Revealed:
                    cellCharAsString = cell.Content.Value.ToString();
                    break;
                default:
                    break;
            }

            return cellCharAsString;
        }

        private string GetCellContentValue(ICell cell)
        {
            string cellCharAsString = string.Empty;

            ContentType cellContentType = cell.Content.ContentType;
            switch (cellContentType)
            {
                case ContentType.Number:
                    cellCharAsString = cell.Content.Value.ToString();
                    break;
                case ContentType.Bomb:
                    cellCharAsString = "-";
                    break;
                default:
                    break;
            }

            return cellCharAsString;
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
                case "magenta":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "dark green":
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case "dark magenta":
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
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
