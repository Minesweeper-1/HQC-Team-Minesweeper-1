namespace Minesweeper.Engine.Initializations
{
    using System;

    using Contents;
    using Contracts;
    using Boards.Contracts;
    using Cells;
    using Cells.Contracts;
    using Common;
    using Contents.Contracts;

    public class StandardGameInitializationStrategy : IGameInitializationStrategy
    {
        private readonly ContentFactory contentFactory;

        public StandardGameInitializationStrategy(ContentFactory contentFactory)
        {
            this.contentFactory = contentFactory;
        }

        public void Initialize(IBoard board)
        {
            this.CreateEmptyBoard(board);
            this.PlantBombs(board);
            this.SetEmptyCellsValues(board);
        }

        private void CreateEmptyBoard(IBoard board)
        {
            for (var row = 0; row < board.Rows; row++)
            {
                for (int col = 0; col < board.Cols; col++)
                {
                    board.Cells[row, col] = new Cell()
                        .Content(this.contentFactory.GetContent(ContentType.Empty))
                        .State(CellState.Sealed)
                        .Context();

                    // For debugging purposes - reveals all cells' content at initialization
                     board.Cells[row, col].State = CellState.Revealed;
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
                    if (currentCell.Content.ContentType == ContentType.Empty)
                    {
                        currentCell.Content.Value = board.CalculateNumberOfSurroundingBombs(row, col);
                    }
                }
            }
        }

        private void PlantBombs(IBoard board)
        {
            var randomGenerator = new Random();
            int numberOfMines = 0;

            while(numberOfMines < board.NumberOfMines)
            {
                int row = randomGenerator.Next(board.Rows);
                int col = randomGenerator.Next(board.Cols);
                if(board.Cells[row, col].Content.ContentType == ContentType.Empty)
                {
                    board.Cells[row, col].Content = this.contentFactory.GetContent(ContentType.Bomb);
                    numberOfMines += 1;
                }
            }
        }
    }
}
