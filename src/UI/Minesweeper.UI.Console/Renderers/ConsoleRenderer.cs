namespace Minesweeper.UI.Console.Renderers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using static System.Console;

    using Logic.Boards.Contracts;
    using Logic.Cells.Contracts;
    using Logic.Common;
    using Logic.DifficultyCommands.Contracts;
    using Logic.Renderers.Contracts;
    using Contracts;
    using Common;

    /// <summary>
    /// Concrete implementation of the IConsoleRenderer and IRenderer interfaces
    /// </summary>
    public class ConsoleRenderer : IConsoleRenderer, IRenderer
    {
        /// <summary>
        /// Creates a new console renderer
        /// </summary>
        public ConsoleRenderer()
        {
            CursorVisible = false;
            Title = "Minesweeper";

            // TODO: Refactor so that it depends on the level
            SetWindowSize(RenderersConstants.ConsoleWidth, RenderersConstants.ConsoleHeight);
            SetBufferSize(RenderersConstants.ConsoleWidth, RenderersConstants.ConsoleHeight);
        }

        /// <summary>
        /// Renders without line break
        /// </summary>
        /// <param name="line"></param>
        public void Render(string line) => Write(line);

        /// <summary>
        /// Renders with a line break
        /// </summary>
        /// <param name="line"></param>
        public void RenderLine(string line) => WriteLine(line);

        /// <summary>
        /// Renders the game board
        /// </summary>
        /// <param name="values"></param>
        public void RenderBoard(params object[] values)
        {
            var board = (IBoard)values[0];
            var row = (int)values[1];
            var col = (int)values[2];

            this.RenderLeftSidebar(board, row, col);
            this.RenderTopBar(board, row, col + 1);
            this.RenderBoardCells(board, row, col + 1);
        }

        /// <summary>
        /// Renders the welcome screen
        /// </summary>
        /// <param name="welcomeScreen"></param>
        public void RenderWelcomeScreen(string welcomeScreen)
        {
            this.SetForegroundColor(ConsoleColor.White);
            this.SetBackgroundColor(ConsoleColor.DarkMagenta);
            this.Render(welcomeScreen);
            this.ResetForegroundColor();
            this.ResetBackgroundColor();
        }

        /// <summary>
        /// Renders the new player creation request
        /// </summary>
        public void RenderNewPlayerCreationRequest()
        {
            this.SetBackgroundColor(ConsoleColor.DarkCyan);
            this.SetForegroundColor(ConsoleColor.White);

            // Fill the whole next 3 lines
            this.Render(new string(' ', RenderersConstants.ConsoleWidth));
            this.Render(new string(' ', RenderersConstants.ConsoleWidth));
            this.Render(new string(' ', RenderersConstants.ConsoleWidth));

            // Set the cursor back at the beginning of the second line
            var cursor = this.GetCursor();
            this.SetCursor(cursor[0] - 2, 0);

            this.Render(line: "ENTER YOUR NAME: ");
        }

        /// <summary>
        /// Sets the rendering cursor to the specified row and column
        /// </summary>
        /// <param name="row">New cursor row</param>
        /// <param name="col">New cursor column</param>
        public void SetCursor(int row, int col) => SetCursorPosition(col, row);

        /// <summary>
        /// Sets the visibility of the rendering cursor
        /// </summary>
        /// <param name="visible">New rendering cursor visibility</param>
        public void SetCursor(bool visible) => CursorVisible = visible;
        
        /// <summary>
        /// Clears the rendering screen
        /// </summary>
        public void ClearScreen() => Clear();

        /// <summary>
        /// Clears the current rendering line 
        /// </summary>
        public void ClearCurrentLine()
        {
            int currentLineCursor = CursorTop;
            this.SetCursor(CursorTop, col: 0);
            this.Render(new string(c: ' ', count: WindowWidth));
            this.SetCursor(currentLineCursor, col: 0);
        }

        /// <summary>
        /// Renders the menu
        /// </summary>
        /// <param name="menuItems">Collection of menu items</param>
        /// <param name="row">Rendering top row</param>
        /// <param name="col">Rendering left column</param>
        public void RenderMenu(IEnumerable<IGameMode> menuItems, int row, int col)
        {
            this.ResetBackgroundColor();
            this.ResetForegroundColor();

            int linesCountBeforeFirstMenuItem = RenderersConstants.MenuTitleRowsCount;
            var cursorRow = row + linesCountBeforeFirstMenuItem;

            CursorVisible = false;

            this.RenderMenuTitle(row, col);
            foreach (var item in menuItems)
            {
                this.SetCursor(cursorRow++, col);
                this.RenderLine(RenderersConstants.SelectionPrefix + item.Value);
            }

            var cursorPosition = this.GetCursor();

            // Set default menu item selection
            this.SetCursor(row + linesCountBeforeFirstMenuItem, col);
            this.Render(RenderersConstants.SelectionChar);

            // Reset cursor position
            this.SetCursor(cursorPosition[0], cursorPosition[1]);
        }

        /// <summary>
        /// Returns an array with the current rendering cursor coordinates
        /// </summary>
        /// <returns></returns>
        public int[] GetCursor() => new int[] { CursorTop, CursorLeft };
       
        private void SetForegroundColor(Enum color) => ForegroundColor = (ConsoleColor)color;

        private void SetBackgroundColor(Enum color) => BackgroundColor = (ConsoleColor)color;

        private void ResetForegroundColor() => this.SetForegroundColor(ConsoleColor.White);

        private void ResetBackgroundColor() => this.SetBackgroundColor(ConsoleColor.Black);

        private void RenderMenuTitle(int row, int col)
        {
            this.SetCursor(row, col);
            foreach (var line in RenderersConstants.MenuTitle)
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
                    cellCharAsString = RenderersConstants.StandardUnrevealedBoardCellCharacter.ToString();
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
                string sidebarRow = boardRow.ToString().PadRight(2) + " *";
                this.RenderLine(sidebarRow);
            }
        }

        private void RenderTopBar(IBoard board, int row, int col)
        {
            string topBarCols = " ";
            string topBarSeparators = RenderersConstants.GameCellsDivider;
            for (int boardCol = 0; boardCol < board.Cols; boardCol++)
            {
                topBarCols += RenderersConstants.IndexLetters[boardCol].ToString().PadLeft(2) + " ";
                topBarSeparators += RenderersConstants.ColsRenderingDivider;
            }

            this.SetCursor(row - RenderersConstants.TopBarColsOffset, col + RenderersConstants.LeftSidebarWidth);
            this.Render(topBarCols);
            this.SetCursor(row - RenderersConstants.TopBarSeparatorsOffset, col + RenderersConstants.LeftSidebarWidth);
            this.Render(topBarSeparators);
        }

        private void RenderBoardCells(IBoard board, int row, int col)
        {
            for (int boardRow = 0; boardRow < board.Rows; boardRow++)
            {
                this.SetCursor(row + boardRow, col + RenderersConstants.LeftSidebarWidth);
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
            if (charToRenderAsString == RenderersConstants.StandardUnrevealedBoardCellCharacter.ToString())
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
