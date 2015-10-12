namespace Minesweeper.UI.Console.Renderers.Common
{
    /// <summary>
    /// Console renderer constants
    /// </summary>
    public class RenderersConstants
    {
        /// <summary>
        /// ConsoleHeight
        /// </summary>
        public const int ConsoleHeight = 41;

        /// <summary>
        /// ConsoleWidth
        /// </summary>
        public const int ConsoleWidth = 81;

        /// <summary>
        /// IndexLetters
        /// </summary>
        public const string IndexLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// ColsRenderingDivider
        /// </summary>
        public const string ColsRenderingDivider = "*  ";

        /// <summary>
        /// GameCellsDivider
        /// </summary>
        public const string GameCellsDivider = "  ";

        /// <summary>
        /// StandardUnrevealedBoardCellCharacter
        /// </summary>
        public const char StandardUnrevealedBoardCellCharacter = '■';

        /// <summary>
        /// BoardStartRenderRow
        /// </summary>
        public const int BoardStartRenderRow = 3;

        /// <summary>
        /// BoardStartRenderCol
        /// </summary>
        public const int BoardStartRenderCol = 1;

        /// <summary>
        /// LeftSidebarWidth
        /// </summary>
        public const int LeftSidebarWidth = 3;

        /// <summary>
        /// TopBarColsOffset
        /// </summary>
        public const int TopBarColsOffset = 2;

        /// <summary>
        /// TopBarSeparatorsOffset
        /// </summary>
        public const int TopBarSeparatorsOffset = 1;

        /// <summary>
        /// SelectionChar
        /// </summary>
        public const string SelectionChar = ">";

        /// <summary>
        /// SelectionPrefix
        /// </summary>
        public const string SelectionPrefix = "   ";

        /// <summary>
        /// MenuTitleAsString
        /// </summary>
        public const string MenuTitleAsString = "SELECT DIFFICULTY";

        /// <summary>
        /// GameTitleAsString
        /// </summary>
        public const string GameTitleAsString = "Minesweeper";

        /// <summary>
        /// SymbolsCount
        /// </summary>
        public static readonly int SymbolsCount = (((ConsoleWidth - 1) / 2) +
                                                   (1 - MenuTitleAsString.Length)) / 2;

        /// <summary>
        /// MenuTitle
        /// </summary>
        public static readonly string[] MenuTitle = new string[]
        {
            new string(c: '=', count: ((ConsoleWidth - 1) / 2) + 1),
            string.Concat(
                new string(c: ' ', count: SymbolsCount) +
                MenuTitleAsString,
                new string(c: ' ', count: SymbolsCount)),
            new string(c: '=', count: ((ConsoleWidth - 1) / 2) + 1)
        };

        /// <summary>
        /// MenuTitleRowsCount
        /// </summary>
        public static readonly int MenuTitleRowsCount = MenuTitle.Length;

        /// <summary>
        /// GameTitle
        /// </summary>
        public static readonly string[] GameTitle = new string[]
        {
            new string(c: '=', count: ConsoleWidth),
            new string(c: ' ', count: (ConsoleWidth - GameTitleAsString.Length) / 2) + GameTitleAsString + new string(c: ' ', count: (ConsoleWidth - GameTitleAsString.Length) / 2),
            new string(c: '=', count: ConsoleWidth)
        };
    }
}
