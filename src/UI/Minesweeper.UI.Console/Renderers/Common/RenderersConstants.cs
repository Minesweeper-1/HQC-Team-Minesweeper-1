namespace Minesweeper.UI.Console.Renderers.Common
{
    public class RenderersConstants
    {
        public const int ConsoleHeight = 36;
        public const int ConsoleWidth = 121;

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
        public static readonly string[] MenuTitle = new string[]
        {
            new string('=', (ConsoleWidth - 1) / 2 + 1),
            new string(' ', ((ConsoleWidth - 1) / 2 + 1 - MenuTitleAsString.Length) / 2) + MenuTitleAsString + new string(' ', ((ConsoleWidth - 1) / 2 + 1 - MenuTitleAsString.Length) / 2),
            new string('=', (ConsoleWidth - 1) / 2 + 1)
        };

        public static readonly int MenuTitleRowsCount = MenuTitle.Length;

        public const string GameTitleAsString = "Minesweeper";
        public static readonly string[] GameTitle = new string[]
        {
            new string('=', ConsoleWidth),
            new string(' ', (ConsoleWidth - GameTitleAsString.Length) / 2) + GameTitleAsString + new string(' ', (ConsoleWidth - GameTitleAsString.Length) / 2),
            new string('=', ConsoleWidth)
        };
    }
}
