namespace Minesweeper.Logic.Common
{
    /// <summary>
    /// A class containing the global constants for the application
    /// </summary>
    public static class GlobalConstants
    {
        /// <summary>
        /// 2D rows dimension index
        /// </summary>
        public const int MatrixRowsDimensionIndex = 0;

        /// <summary>
        /// 2D columns dimension index
        /// </summary>
        public const int MatrixColsDimensionIndex = 1;

        /// <summary>
        /// Beginner level number of board rows
        /// </summary>
        public const int BeginnerLevelNumberOfBoardRows = 9;

        /// <summary>
        /// Beginner level number of board columns
        /// </summary>
        public const int BeginnerLevelNumberOfBoardCols = 9;

        /// <summary>
        /// Beginner level number of board bombs
        /// </summary>
        public const int BeginnerLevelNumberOfBoardBombs = 10;

        /// <summary>
        /// Intermediate level number of board rows
        /// </summary>
        public const int IntermediateLevelNumberOfBoardRows = 16;

        /// <summary>
        /// Intermediate level number of board columns
        /// </summary>
        public const int IntermediateLevelNumberOfBoardCols = 16;

        /// <summary>
        /// Intermediate level number of board bombs
        /// </summary>
        public const int IntermediateLevelNumberOfBoardBombs = 40;

        /// <summary>
        /// Expert level number of board rows
        /// </summary>
        public const int ExpertLevelNumberOfBoardRows = 20;

        /// <summary>
        /// Expert level number of board columns
        /// </summary>
        public const int ExpertLevelNumberOfBoardCols = 24;

        /// <summary>
        /// Expert level number of board bombs
        /// </summary>
        public const int ExpertLevelNumberOfBoardBombs = 99;

        /// <summary>
        /// Command parameters divider
        /// </summary>
        public const char CommandParametersDivider = ' ';

        /// <summary>
        /// Scoreboard base path
        /// </summary>
        public static readonly string ScoreboardBasePath = System.Reflection.Assembly
            .GetExecutingAssembly().Location;

        /// <summary>
        /// Scoreboard file path
        /// </summary>
        public static readonly string ScoreboardFilePath = ScoreboardBasePath.Substring(startIndex: 0, length: ScoreboardBasePath.IndexOf(value: "UI\\Minesweeper.UI.Console")) + "Minesweeper.Logic\\Data\\leaders.msr";
    }
}
