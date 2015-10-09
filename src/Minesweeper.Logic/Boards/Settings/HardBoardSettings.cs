namespace Minesweeper.Logic.Boards.Settings.Contracts
{
    using Minesweeper.Logic.Common;

    /// <summary>
    /// The class containing the board settings for a hard game
    /// </summary>
    public class HardBoardSettings : BoardSettings
    {
        /// <summary>
        /// Creates board settings for the hard difficulty level
        /// </summary>
        public HardBoardSettings()
            : base(
                  GlobalConstants.ExpertLevelNumberOfBoardRows,
                  GlobalConstants.ExpertLevelNumberOfBoardCols,
                  GlobalConstants.ExpertLevelNumberOfBoardBombs)
        {
        }
    }
}
