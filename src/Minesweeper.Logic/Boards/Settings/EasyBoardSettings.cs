namespace Minesweeper.Logic.Boards.Settings
{
    using Common;
    using Contracts;

    /// <summary>
    /// Class containing the board settings for an easy game mode
    /// </summary>
    public class EasyBoardSettings : BoardSettings
    {
        /// <summary>
        /// Calls the base constructor with board parameters for easy game mode
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