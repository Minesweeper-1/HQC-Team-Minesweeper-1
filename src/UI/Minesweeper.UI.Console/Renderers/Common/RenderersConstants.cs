namespace Minesweeper.UI.Console.Renderers.Common
{
    /// <summary>
    /// Console renderer constants
    /// </summary>
    public class RenderersConstants
    {
        public const int ConsoleHeight = 41;
        public const int ConsoleWidth = 81;

        public const string IndexLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public const string ColsRenderingDivider = "*  ";
        public const string GameCellsDivider = "  ";

        public const char StandardUnrevealedBoardCellCharacter = '■';

        public const int BoardStartRenderRow = 3;
        public const int BoardStartRenderCol = 1;

        public const int LeftSidebarWidth = 3;
        public const int TopBarColsOffset = 2;
        public const int TopBarSeparatorsOffset = 1;
        public const string SelectionChar = ">";
        public const string SelectionPrefix = "   ";

        public const string MenuTitleAsString = "SELECT DIFFICULTY";
        public const string GameTitleAsString = "Minesweeper";

        public static readonly int SymbolsCount = (((ConsoleWidth - 1) / 2) +
                                                   (1 - MenuTitleAsString.Length)) / 2;

        public static readonly string[] MenuTitle = new string[]
        {
            new string(c: '=', count: ((ConsoleWidth - 1) / 2) + 1),
            string.Concat(
                new string(c: ' ', count: SymbolsCount) +
                MenuTitleAsString,
                new string(c: ' ', count: SymbolsCount)),
            new string(c: '=', count: ((ConsoleWidth - 1) / 2) + 1)
        };

        public static readonly int MenuTitleRowsCount = MenuTitle.Length;

        public static readonly string[] GameTitle = new string[]
        {
            new string(c: '=', count: ConsoleWidth),
            new string(c: ' ', count: (ConsoleWidth - GameTitleAsString.Length) / 2) + GameTitleAsString + new string(c: ' ', count: (ConsoleWidth - GameTitleAsString.Length) / 2),
            new string(c: '=', count: ConsoleWidth)
        };
    }
}
