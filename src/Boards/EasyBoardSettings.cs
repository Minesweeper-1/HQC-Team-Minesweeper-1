namespace Minesweeper.Boards
{
    using Minesweeper.Common;

    public class EasyBoardSettings : BoardSettings
    {
        public EasyBoardSettings()
            : base(
                  GlobalConstants.BeginnerLevelNumberOfBoardRows, 
                  GlobalConstants.BeginnerLevelNumberOfBoardCols, 
                  GlobalConstants.BeginnerLevelNumberOfBoardBombs)
        {
        }
    }
}