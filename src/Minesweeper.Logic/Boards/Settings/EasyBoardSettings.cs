namespace Minesweeper.Logic.Boards.Settings.Contracts
{
    using Minesweeper.Logic.Common;

    /// <summary>
    /// The class containing the board settings for an easy game
    /// </summary>
    public class EasyBoardSettings : BoardSettings
    {
        /// <summary>
        /// Creates board settings for the easy difficulty level
        /// </summary>
        public EasyBoardSettings()
            : base(
                  GlobalConstants.BeginnerLevelNumberOfBoardRows, 
                  GlobalConstants.BeginnerLevelNumberOfBoardCols, 
                  GlobalConstants.BeginnerLevelNumberOfBoardBombs)
        {
        }
    }
}