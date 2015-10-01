namespace Minesweeper.Logic.Boards.Settings.Contracts
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
