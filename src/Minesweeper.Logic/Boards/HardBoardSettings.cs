namespace Minesweeper.Logic.Boards
{
    using Minesweeper.Logic.Common;

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
