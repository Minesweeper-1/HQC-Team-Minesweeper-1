namespace Minesweeper.Boards
{
    using Minesweeper.Common;

    public class HardBoardSettings : BoardSettings
    {
        public HardBoardSettings()
            : base(
                  GlobalConstants.ExpertLevelNumberOfBoardRows,
                  GlobalConstants.ExpertLevelNumberOfBoardCols,
                  GlobalConstants.ExpertLevelNumberOfBoardBombs)
        {
        }
    }
}
