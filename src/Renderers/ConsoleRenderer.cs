namespace Minesweeper.Renderers
{
    using System;

    using Boards.Contracts;
    using Cells.Contracts;
    using Common;
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

        public void RenderBoard(IBoard board, int row, int col)
        {
            this.RenderLeftSidebar(board, row, col);
            this.RenderTopBar(board, row, col + 1);
            this.RenderBoardCells(board, row, col + 1);
        }

        public void RenderWelcomeScreen(string welcomeScreen)
        {
            this.RenderLine(welcomeScreen);
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

        public void SetCursorPosition(int row, int col)
        {
            Console.SetCursorPosition(col, row);
        }

        public void SetForegroundColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public void ResetForegroundColor()
        {
            this.SetForegroundColor(ConsoleColor.White);
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            this.SetCursorPosition(Console.CursorTop, col: 0);
            this.Render(new string(c: ' ', count: Console.WindowWidth));
            this.SetCursorPosition(currentLineCursor, col: 0);
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
                    this.SetCorrespondingForegroundColor(charToRenderAsString);
                    this.Render(charToRenderAsString + " ");
                    this.ResetForegroundColor();
                }
            }

            this.ResetForegroundColor();
        }

        private void SetCorrespondingForegroundColor(string charToRenderAsString)
        {
            if (charToRenderAsString == GlobalConstants.StandardUnrevealedBoardCellCharacter.ToString())
            {
                this.SetForegroundColor(ConsoleColor.DarkCyan);
            }
            else if (charToRenderAsString == "0")
            {
                this.SetForegroundColor(ConsoleColor.Magenta);
            }
            else if (charToRenderAsString == "1")
            {
                this.SetForegroundColor(ConsoleColor.Blue);
            }
            else if (charToRenderAsString == "2")
            {
                this.SetForegroundColor(ConsoleColor.Green);
            }
            else if (charToRenderAsString == "3")
            {
                this.SetForegroundColor(ConsoleColor.Red);
            }
            else if (charToRenderAsString == "4")
            {
                this.SetForegroundColor(ConsoleColor.DarkGreen);
            }
            else if (charToRenderAsString == "5")
            {
                this.SetForegroundColor(ConsoleColor.DarkMagenta);
            }
        }
    }
}
