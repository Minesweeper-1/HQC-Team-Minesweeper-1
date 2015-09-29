namespace Minesweeper.Logic.Boards
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
