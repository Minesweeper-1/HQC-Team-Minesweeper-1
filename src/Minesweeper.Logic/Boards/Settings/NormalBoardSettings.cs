namespace Minesweeper.Logic.Boards.Settings.Contracts
{
    using Minesweeper.Logic.Common;

    public class NormalBoardSettings : BoardSettings
    {
        /// <summary>
        /// The class containing the board settings for a normal game
        /// </summary>
        public NormalBoardSettings()
            : base(
                  GlobalConstants.IntermediateLevelNumberOfBoardRows,
                  GlobalConstants.IntermediateLevelNumberOfBoardCols,
                  GlobalConstants.IntermediateLevelNumberOfBoardBombs)
        {
        }
    }
}
