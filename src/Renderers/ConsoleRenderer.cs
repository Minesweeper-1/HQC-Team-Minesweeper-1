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

        public void RenderBoard(IBoard board, int row, int col)
        {
            this.RenderLeftSidebar(board, row, col);
            this.RenderTopBar(board, row, col + 1);
            this.RenderBoardCells(board, row, col + 1);

            // Lines for debugging purposes
            // this.RenderRevealedBoard(board, row + board.Rows + 3, col);
        }

        private void RenderLeftSidebar(IBoard board, int row, int col)
        {
            for (int boardRow = 0; boardRow < board.Rows; boardRow++)
            {
                this.SetCursorPosition(row + boardRow, col);
                string sidebarRow = boardRow + " *";
                this.RenderLine(sidebarRow);
            }
        }

        private void RenderTopBar(IBoard board, int row, int col)
        {
            string topBarCols = "";
            string topBarSeparators = "";
            for (int boardCol = 0; boardCol < board.Cols; boardCol++)
            {
                topBarCols += boardCol + GlobalConstants.GameCellsDivider;
                topBarSeparators += GlobalConstants.ColsRenderingDivider;
            }

            this.SetCursorPosition(row - GlobalConstants.TopBarColsOffset, col + GlobalConstants.LeftSidebarWidth);
            this.Render(topBarCols);
            this.SetCursorPosition(row - GlobalConstants.TopBarSeparatorsOffset, col + GlobalConstants.LeftSidebarWidth);
            this.Render(topBarSeparators);
        }

        private void RenderBoardCells(IBoard board, int row, int col)
        {
            for (int boardRow = 0; boardRow < board.Rows; boardRow++)
            {
                this.SetCursorPosition(row + boardRow, col + GlobalConstants.LeftSidebarWidth);
                for (int boardCol = 0; boardCol < board.Cols; boardCol++)
                {
                    string charToRenderAsString = this.GetCellCharAsString(board.Cells[boardRow, boardCol]);
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

                    this.Render(charToRenderAsString + " ");
                    this.ResetForegroundColor();
                }
            }

            this.ResetForegroundColor();
        }

        private void RenderRevealedBoard(IBoard board, int row, int col)
        {
            this.RenderLeftSidebar(board, row, col);
            this.RenderTopBar(board, row, col + 1);
            this.RenderRevealedBoardCells(board, row, col + 1);
        }

        private void RenderRevealedBoardCells(IBoard board, int row, int col)
        {
            for (int boardRow = 0; boardRow < board.Rows; boardRow++)
            {
                this.SetCursorPosition(row + boardRow, col + GlobalConstants.LeftSidebarWidth);
                for (int boardCol = 0; boardCol < board.Cols; boardCol++)
                {
                    string charToRenderAsString = this.GetCellContentValue(board.Cells[boardRow, boardCol]);
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

                    this.Render(charToRenderAsString + " ");
                    this.ResetForegroundColor();
                }
            }

            this.ResetForegroundColor();
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

        public void SetCursorPosition(int row, int col)
        {
            Console.SetCursorPosition(col, row);
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

        public void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            this.SetCursorPosition(Console.CursorTop, 0);
            this.Render(new string(' ', Console.WindowWidth));
            this.SetCursorPosition(currentLineCursor, 0);
        }
    }
}
