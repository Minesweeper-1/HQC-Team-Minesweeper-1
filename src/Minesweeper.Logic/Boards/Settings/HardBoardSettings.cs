namespace Minesweeper.Logic.Boards.Settings
{
    using Common;
    using Contracts;

    /// <summary>
    /// The class containing the board settings for a hard game mode
    /// </summary>
    public class HardBoardSettings : BoardSettings
    {
        /// <summary>
        /// Calls the base constructor with board settings for hard game mode
        /// </summary>
        public HardBoardSettings()
            : base(GlobalConstants.ExpertLevelNumberOfBoardRows,
                   GlobalConstants.ExpertLevelNumberOfBoardCols,
                   GlobalConstants.ExpertLevelNumberOfBoardBombs)
        {
        }
    }
}
