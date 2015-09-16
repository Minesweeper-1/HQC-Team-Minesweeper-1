namespace Minesweeper.Common
{
    public static class GlobalConstants
    {
        public const char CommandParametersDivider = ' ';

        public const int MatrixRowsDimensionIndex = 0;
        public const int MatrixColsDimensionIndex = 1;

        public const string ColsRenderingStartDivider = "    _";
        public const string ColsRenderingBaseDivider = " _";
        public const string GameCellsDivider = " ";

        public static readonly int StandardNumberOfBoardRows = 5;
        public static readonly int StandardNumberOfBoardCols = 10;
        public static readonly int StandardNumberOfBoardBombs = 15;
        public static readonly char StandardUnrevealedBoardCellCharacter = '?';
    }
}
