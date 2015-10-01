namespace Minesweeper.Logic.Boards.Settings.Contracts
{
    using Minesweeper.Logic.Common;

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
