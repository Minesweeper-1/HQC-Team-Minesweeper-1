namespace Minesweeper.UI.Renderers
{
    using System;
    using System.Collections.Generic;
    using static System.Console;
    using System.Globalization;

    using Minesweeper.Logic.Boards.Contracts;
    using Minesweeper.Logic.Cells.Contracts;
    using Minesweeper.Logic.Common;
    using Contracts;
    using Minesweeper.Logic.DifficultyCommands.Contracts;

    public class ConsoleRenderer : IRenderer
    {
        public ConsoleRenderer()
        {
            CursorVisible = false;
            Title = "Minesweeper.UI";

            // TODO: Refactor so that it depends on the level
            SetWindowSize(GlobalConstants.ConsoleWidth, GlobalConstants.ConsoleHeight);
            SetBufferSize(GlobalConstants.ConsoleWidth, GlobalConstants.ConsoleHeight);
        }

        public void Render(string line) => Write(line);

        public void RenderLine(string line) => WriteLine(line);

        public void RenderBoard(IBoard board, int row, int col)
        {
            this.RenderLeftSidebar(board, row, col);
            this.RenderTopBar(board, row, col + 1);
            this.RenderBoardCells(board, row, col + 1);
        }

        public void RenderWelcomeScreen(string welcomeScreen)
        {
            this.SetForegroundColor(ConsoleColor.White);
            this.SetBackgroundColor(ConsoleColor.DarkMagenta);
            this.Render(welcomeScreen);
            this.ResetForegroundColor();
            this.ResetBackgroundColor();
        }

        public void RenderNewPlayerCreationRequest()
        {
            this.SetBackgroundColor(ConsoleColor.DarkCyan);
            this.SetForegroundColor(ConsoleColor.White);

            // Fill the whole next 3 lines
            this.Render(new string(' ', GlobalConstants.ConsoleWidth));
            this.Render(new string(' ', GlobalConstants.ConsoleWidth));
            this.Render(new string(' ', GlobalConstants.ConsoleWidth));

            // Set the cursor back at the beginning of the second line
            var cursor = this.GetCursor();
            this.SetCursor(cursor[0] - 2, 0);

            this.Render(line: "ENTER YOUR NAME: ");
        }

        public void SetCursor(int row, int col) => SetCursorPosition(col, row);

        public void SetCursor(bool visible) => CursorVisible = visible;

        public void SetForegroundColor(Enum color) => ForegroundColor = (ConsoleColor)color;

        public void SetBackgroundColor(Enum color) => BackgroundColor = (ConsoleColor)color;

        public void ResetForegroundColor() => this.SetForegroundColor(ConsoleColor.White);

        public void ResetBackgroundColor() => this.SetBackgroundColor(ConsoleColor.Black);

        public void ClearScreen() => Clear();

        public void ClearCurrentLine()
        {
            int currentLineCursor = CursorTop;
            this.SetCursor(CursorTop, col: 0);
            this.Render(new string(c: ' ', count: WindowWidth));
            this.SetCursor(currentLineCursor, col: 0);
        }

        public void RenderMenu(IEnumerable<IGameMode> menuItems, int row, int col)
        {
            this.ResetBackgroundColor();
            this.ResetForegroundColor();

            int linesCountBeforeFirstMenuItem = GlobalConstants.MenuTitleRowsCount;
            var cursorRow = row + linesCountBeforeFirstMenuItem;

            CursorVisible = false;

            this.RenderMenuTitle(row, col);
            foreach (var item in menuItems)
            {
                this.SetCursor(cursorRow++, col);
                this.RenderLine(GlobalConstants.SelectionPrefix + item.Value);
            }

            var cursorPosition = this.GetCursor();

            // Set default menu item selection
            this.SetCursor(row + linesCountBeforeFirstMenuItem, col);
            this.Render(GlobalConstants.SelectionChar);

            // Reset cursor position
            this.SetCursor(cursorPosition[0], cursorPosition[1]);
        }

        public int[] GetCursor() => new int[] { CursorTop, CursorLeft };

        private void RenderMenuTitle(int row, int col)
        {
            this.SetCursor(row, col);
            foreach (var line in GlobalConstants.MenuTitle)
            {
                this.SetCursor(row++, col);
                this.RenderLine(line);
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
