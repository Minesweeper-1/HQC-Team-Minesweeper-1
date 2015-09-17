namespace Minesweeper.Engine.Initializations
{
    using Common;
    using Contracts;
    using Boards.Contracts;

    public class StandardGameInitializationStrategy : IGameInitializationStrategy
    {
        public void Initialize(IBoard board)
        {
            this.FillBoard(board);
        }

        private void FillBoard(IBoard board)
        {
            for (var row = 0; row < board.Rows; row++)
            {
                for (int col = 0; col < board.Cols; col++)
                {
                    board.Matrix[row, col] = GlobalConstants.StandardUnrevealedBoardCellCharacter;
                }
            }
        }
    }
}
