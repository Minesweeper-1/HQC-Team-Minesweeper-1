namespace Minesweeper.UI.Console.Engine.Initializations
{
    using System;

    using Logic.Boards.Contracts;
    using Logic.Cells;
    using Logic.Cells.Contracts;
    using Logic.Common;
    using Logic.Contents;
    using Logic.Engines.Contracts;

    /// <summary>
    /// InitializationStrategy
    /// </summary>
    public class StandardGameInitializationStrategy : IGameInitializationStrategy
    {
        private readonly ContentFactory contentFactory;

        /// <summary>
        /// Creat content factory
        /// </summary>
        /// <param name="contentFactory"></param>
        public StandardGameInitializationStrategy(ContentFactory contentFactory)
        {
            this.contentFactory = contentFactory;
        }

        /// <summary>
        /// Generate Board
        /// </summary>
        /// <param name="board">IBoard object</param>
        public void Initialize(IBoard board)
        {
            this.CreateEmptyBoard(board);
            this.PlantBombs(board);
            this.SetEmptyCellsValues(board);
        }

        /// <summary>
        /// Creat empty board
        /// </summary>
        /// <param name="board">IBoard object</param>
        private void CreateEmptyBoard(IBoard board)
        {
            for (var row = 0; row < board.Rows; row++)
            {
                for (int col = 0; col < board.Cols; col++)
                {
                    board.Cells[row, col] = new Cell()
                        .SetContent(this.contentFactory.GetContent(ContentType.Empty))
                        .SetState(CellState.Sealed)
                        .GetContext();

                    // For debugging purposes - reveals all cells' content at initialization
                    // board.Cells[row, col].State = CellState.Revealed;
                }
            }
        }

        /// <summary>
        /// Calculate Numbers
        /// </summary>
        /// <param name="board">IBoard object</param>
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

        /// <summary>
        /// Position Bombs
        /// </summary>
        /// <param name="board">IBoard object</param>
        private void PlantBombs(IBoard board)
        {
            var randomGenerator = new Random();
            int numberOfMines = 0;

            while (numberOfMines < board.NumberOfMines)
            {
                int row = randomGenerator.Next(board.Rows);
                int col = randomGenerator.Next(board.Cols);
                if (board.Cells[row, col].Content.ContentType == ContentType.Empty)
                {
                    board.Cells[row, col].Content = this.contentFactory.GetContent(ContentType.Bomb);
                    numberOfMines += 1;
                }
            }
        }
    }
}
