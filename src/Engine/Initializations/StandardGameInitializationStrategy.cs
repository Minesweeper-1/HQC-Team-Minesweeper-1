namespace Minesweeper.Engine.Initializations
{
    using System;

    using Common;
    using Contracts;
    using Boards.Contracts;

    public class StandardGameInitializationStrategy : IGameInitializationStrategy
    {
        public void Initialize(IBoard board)
        {
            this.FillBoard(board);
            this.PlantBombs(board);
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

        private void PlantBombs(IBoard board)
        {
            var randomGenerator = new Random();
            for (var i = 0; i < board.NumberOfMines; i++)
            {
                int x = randomGenerator.Next(board.Rows + 1);
                int y = randomGenerator.Next(board.Cols + 1);
                bool isInsideBoard = board.IsInsideBoard(x, y);
                while (!isInsideBoard)
                {
                    x = randomGenerator.Next(board.Rows + 1);
                    y = randomGenerator.Next(board.Cols + 1);
                    isInsideBoard = board.IsInsideBoard(x, y);
                }

                board.Bombs[x, y] = true;
            }
        }
    }
}
