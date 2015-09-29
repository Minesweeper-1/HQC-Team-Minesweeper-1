namespace Minesweeper.Logic.Boards
{
    using Minesweeper.Logic.Common;

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