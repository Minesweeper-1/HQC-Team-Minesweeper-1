namespace Minesweeper.Common
{
    public static class GlobalConstants
    {
        public const char CommandParametersDivider = ' ';

        public const int MatrixRowsDimensionIndex = 0;
        public const int MatrixColsDimensionIndex = 1;

        public const string ColsRenderingDivider = "* ";
        public const string GameCellsDivider = " ";

        public static readonly int BeginnerLevelNumberOfBoardRows = 9;
        public static readonly int BeginnerLevelNumberOfBoardCols = 9;
        public static readonly int BeginnerLevelNumberOfBoardBombs = 10;

        public static readonly int IntermediateLevelNumberOfBoardRows = 16;
        public static readonly int IntermediateLevelNumberOfBoardCols = 16;
        public static readonly int IntermediateLevelNumberOfBoardBombs = 40;

        public static readonly int ExpertLevelNumberOfBoardRows = 20;
        public static readonly int ExpertLevelNumberOfBoardCols = 24;
        public static readonly int ExpertLevelNumberOfBoardBombs = 99;

        public static readonly char StandardUnrevealedBoardCellCharacter = '■';

        public const int LeftSidebarWidth = 3;
        public const int TopBarColsOffset = 2;
        public const int TopBarSeparatorsOffset = 1;

        public static readonly string ScoreboardFilePath = "leaders.msr";

        public static readonly string DefaultWelcomeScreen = "Welcome to the all-time classic game of Minesweeper";
    }
}
