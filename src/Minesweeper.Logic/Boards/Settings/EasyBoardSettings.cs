namespace Minesweeper.Logic.Boards.Settings.Contracts
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