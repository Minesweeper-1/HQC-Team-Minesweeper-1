namespace Minesweeper.Common
{
    public static class GlobalConstants
    {
        public const char CommandParametersDivider = ' ';

        public const int MatrixRowsDimensionIndex = 0;
        public const int MatrixColsDimensionIndex = 1;

        public const string ColsRenderingDivider = "*  ";
        public const string GameCellsDivider = "  ";

        public const int BeginnerLevelNumberOfBoardRows = 9;
        public const int BeginnerLevelNumberOfBoardCols = 9;
        public const int BeginnerLevelNumberOfBoardBombs = 10;

        public const int IntermediateLevelNumberOfBoardRows = 16;
        public const int IntermediateLevelNumberOfBoardCols = 16;
        public const int IntermediateLevelNumberOfBoardBombs = 40;

        public const int ExpertLevelNumberOfBoardRows = 20;
        public const int ExpertLevelNumberOfBoardCols = 24;
        public const int ExpertLevelNumberOfBoardBombs = 99;

        public const char StandardUnrevealedBoardCellCharacter = '■';

        public const int BoardStartRenderRow = 5;
        public const int BoardStartRenderCol = 5;

        public const int LeftSidebarWidth = 3;
        public const int TopBarColsOffset = 2;
        public const int TopBarSeparatorsOffset = 1;

        public const string ScoreboardFilePath = "../../Data/leaders.msr";

        public const string DefaultWelcomeScreen = "Welcome to the all-time classic game of Minesweeper";

        public const string SelectionChar = ">";
        public const string SelectionPrefix = "   ";
        public static readonly string[] MenuTitle = new string[]
        {
            "===============================",
            "       SELECT DIFFICULTY       ",
            "==============================="
        };

        public static readonly int MenuTitleRowsCount = MenuTitle.Length;
    }
}
