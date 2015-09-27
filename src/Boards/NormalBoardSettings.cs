namespace Minesweeper.Boards
{
    using Minesweeper.Common;

    public class NormalBoardSettings : BoardSettings
    {
        public NormalBoardSettings()
            : base(
                  GlobalConstants.IntermediateLevelNumberOfBoardRows,
                  GlobalConstants.IntermediateLevelNumberOfBoardCols,
                  GlobalConstants.IntermediateLevelNumberOfBoardBombs)
        {
        }
    }
}
