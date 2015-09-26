namespace Minesweeper.Renderers
{
    using System;
    using static System.Console;
    using System.Globalization;

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
            Write(line);
        }

        public void RenderLine(string line)
        {
            WriteLine(line);
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

        public void SetCursor(int row, int col)
        {
            SetCursorPosition(col, row);
        }

        public void SetForegroundColor(ConsoleColor color)
        {
            ForegroundColor = color;
        }

        public void ResetForegroundColor()
        {
            this.SetForegroundColor(ConsoleColor.White);
        }

        public void ClearScreen()
        {
            Clear();
        }

        public void ClearCurrentConsoleLine()
        {
            int currentLineCursor = CursorTop;
            this.SetCursor(CursorTop, col: 0);
            this.Render(new string(c: ' ', count: WindowWidth));
            this.SetCursor(currentLineCursor, col: 0);
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
                    cellCharAsString = cell.Content.Value.ToString(CultureInfo.InvariantCulture);
                    break;
                default:
                    break;
            }

            return cellCharAsString;
        }

        private void RenderLeftSidebar(IBoard board, int row, int col)
        {
            for (int boardRow = 0; boardRow < board.Rows; boardRow++)
            {
                this.SetCursor(row + boardRow, col);
                string sidebarRow = boardRow + " *";
                this.RenderLine(sidebarRow);
            }
        }

        private void RenderTopBar(IBoard board, int row, int col)
        {
            string topBarCols = GlobalConstants.GameCellsDivider;
            string topBarSeparators = GlobalConstants.GameCellsDivider;
            for (int boardCol = 0; boardCol < board.Cols; boardCol++)
            {
                topBarCols += boardCol + GlobalConstants.GameCellsDivider;
                topBarSeparators += GlobalConstants.ColsRenderingDivider;
            }

            this.SetCursor(row - GlobalConstants.TopBarColsOffset, col + GlobalConstants.LeftSidebarWidth);
            this.Render(topBarCols);
            this.SetCursor(row - GlobalConstants.TopBarSeparatorsOffset, col + GlobalConstants.LeftSidebarWidth);
            this.Render(topBarSeparators);
        }

        private void RenderBoardCells(IBoard board, int row, int col)
        {
            for (int boardRow = 0; boardRow < board.Rows; boardRow++)
            {
                this.SetCursor(row + boardRow, col + GlobalConstants.LeftSidebarWidth);
                for (int boardCol = 0; boardCol < board.Cols; boardCol++)
                {
                    string charToRenderAsString = this.GetCellCharAsString(board.Cells[boardRow, boardCol]);
                    this.SetCorrespondingForegroundColor(charToRenderAsString);
                    this.Render(charToRenderAsString.PadLeft(totalWidth: 3));
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
