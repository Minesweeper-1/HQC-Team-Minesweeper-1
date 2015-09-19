namespace Minesweeper.Engine.Initializations
{
    using System;

    using Contents;
    using Contracts;
    using Boards.Contracts;
    using Cells;
    using Cells.Contracts;
    using Common;

    public class StandardGameInitializationStrategy : IGameInitializationStrategy
    {
        public void Initialize(IBoard board)
        {
            this.FillBoard(board);
            this.PlantBombs(board);
            this.SetEmptyCellsValues(board);
        }

        private void FillBoard(IBoard board)
        {
            for (var row = 0; row < board.Rows; row++)
            {
                for (int col = 0; col < board.Cols; col++)
                {
                    board.Cells[row, col] = new Cell(row, col);
                }
            }
        }

        private void SetEmptyCellsValues(IBoard board)
        {
            ICell[,] boardCells = board.Cells;
            for (var row = 0; row < board.Rows; row++)
            {
                for (int col = 0; col < board.Cols; col++)
                {
                    ICell currentCell = boardCells[row, col];
                    ContentType cellContentType = currentCell.Content.ContentType;
                    if(!(cellContentType == ContentType.Bomb))
                    {
                        currentCell.Content.Value = board.CalculateNumberOfSurroundingBombs(row, col);
                    }
                }
            }
        }

        private void PlantBombs(IBoard board)
        {
            var randomGenerator = new Random();
            for (var i = 0; i < board.NumberOfMines; i++)
            {
                int cellRow = randomGenerator.Next(board.Rows + 1);
                int cellCol = randomGenerator.Next(board.Cols + 1);
                bool isInsideBoard = board.IsInsideBoard(cellRow, cellCol);
                while (!isInsideBoard)
                {
                    cellRow = randomGenerator.Next(board.Rows + 1);
                    cellCol = randomGenerator.Next(board.Cols + 1);
                    isInsideBoard = board.IsInsideBoard(cellRow, cellCol);
                }

                board.Cells[cellRow, cellCol].Content = new Bomb();
            }
        }
    }
}
