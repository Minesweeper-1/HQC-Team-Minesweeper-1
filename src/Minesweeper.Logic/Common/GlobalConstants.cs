namespace Minesweeper.Logic.Common
{

    public static class GlobalConstants
    {
        public const int MatrixRowsDimensionIndex = 0;
        public const int MatrixColsDimensionIndex = 1;

        public const int BeginnerLevelNumberOfBoardRows = 9;
        public const int BeginnerLevelNumberOfBoardCols = 9;
        public const int BeginnerLevelNumberOfBoardBombs = 10;

        public const int IntermediateLevelNumberOfBoardRows = 16;
        public const int IntermediateLevelNumberOfBoardCols = 16;
        public const int IntermediateLevelNumberOfBoardBombs = 40;

        public const int ExpertLevelNumberOfBoardRows = 20;
        public const int ExpertLevelNumberOfBoardCols = 24;
        public const int ExpertLevelNumberOfBoardBombs = 99;
        
        private static readonly string scoreboardBasePath = System.Reflection.Assembly
            .GetExecutingAssembly().Location;

        public static readonly string ScoreboardFilePath = scoreboardBasePath.Substring(0, scoreboardBasePath.IndexOf("Minesweeper.UI.Console")) + "Minesweeper.Logic\\Data\\leaders.msr";
        
        public const char CommandParametersDivider = ' ';
    }
}
