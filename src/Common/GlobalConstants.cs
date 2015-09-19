namespace Minesweeper.Common
{
    public static class GlobalConstants
    {
        public const char CommandParametersDivider = ' ';

        public const int MatrixRowsDimensionIndex = 0;
        public const int MatrixColsDimensionIndex = 1;

        public const string ColsRenderingDivider = "* ";
        public const string GameCellsDivider = " ";

        public static readonly int StandardNumberOfBoardRows = 5;
        public static readonly int StandardNumberOfBoardCols = 10;
        public static readonly int StandardNumberOfBoardBombs = 15;
        public static readonly char StandardUnrevealedBoardCellCharacter = '■';

        public const int LeftSidebarWidth = 3;
        public const int TopBarColsOffset = 2;
        public const int TopBarSeparatorsOffset = 1;
    }
}
