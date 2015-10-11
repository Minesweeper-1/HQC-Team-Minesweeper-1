namespace Minesweeper.Logic.Boards.Settings.Contracts
{
    using Common;

    /// <summary>
    /// The class containing the board settings for a normal game
    /// </summary>
    public class NormalBoardSettings : BoardSettings
    {
        /// <summary>
        /// Calls the base constructor with board settings for normal game mode
        /// </summary>
        public NormalBoardSettings()
            : base(GlobalConstants.IntermediateLevelNumberOfBoardRows,
                   GlobalConstants.IntermediateLevelNumberOfBoardCols,
                   GlobalConstants.IntermediateLevelNumberOfBoardBombs)
        {
        }
    }
}
