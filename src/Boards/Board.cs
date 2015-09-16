namespace Minesweeper.Boards
{
    using System;

    using Contracts;
    using Common;

    public class Board : IBoard
    {
        private int rows;
        private int cols;
        private int numberOfMines;
        private char unrevealedCellChar;
        private bool[,] bombs;

        public Board()
        {
            this.InitializeBoard();
            this.FillBoard();
            this.PlantBombs();
        }

        public char[,] Matrix
        {
            get;
            set;
        }

        public bool[,] Bombs
        {
            get
            {
                return this.bombs;
            }
        }

        private void InitializeBoard()
        {
            this.rows = GlobalConstants.StandardNumberOfBoardRows;
            this.cols = GlobalConstants.StandardNumberOfBoardCols;
            this.numberOfMines = GlobalConstants.StandardNumberOfBoardCols;
            this.unrevealedCellChar = GlobalConstants.StandardUnrevealedBoardCellCharacter;
            this.Matrix = new char[this.rows, this.cols];
            this.bombs = new bool[this.rows, this.cols];
        }

        private void FillBoard()
        {
            for (var row = 0; row < this.rows; row++)
            {
                for (int col = 0; col < this.cols; col++)
                {
                    this.Matrix[row, col] = this.unrevealedCellChar;
                }
            }
        }

        private void PlantBombs()
        {
            var randomGenerator = new Random();
            for (var i = 0; i < this.numberOfMines; i++)
            {
                int x = randomGenerator.Next(this.rows + 1);
                int y = randomGenerator.Next(this.cols + 1);
                bool isInsideBoard = this.IsInsideBoard(x, y);
                while (!isInsideBoard)
                {
                    x = randomGenerator.Next(this.rows + 1);
                    y = randomGenerator.Next(this.cols + 1);
                    isInsideBoard = this.IsInsideBoard(x, y);
                }

                this.bombs[x, y] = true;
            }
        }

        private int CalculateNumberOfSurroundingBombs(int x, int y)
        {
            int result = 0;

            int rowStart = x - 1;
            int rowEnd = x + 1;
            int colStart = y - 1;
            int colEnd = y + 1;

            for (int row = rowStart; row <= rowEnd; row++)
            {
                for (int col = colStart; col <= colEnd; col++)
                {
                    if (this.IsInsideBoard(row, col) &&
                        this.bombs[row, col])
                    {
                        result++;
                    }
                }
            }

            if(bombs[x, y])
            {
                result -= 1;
            }

            return result;
        }

        public void RevealCell(int x, int y)
        {
            this.Matrix[x, y] = this.CalculateNumberOfSurroundingBombs(x, y).ToString()[0];
        }

        public bool IsInsideBoard(int x, int y)
        {
            return (0 <= x && x < this.rows) && (0 <= y && y < this.cols);
        }

        public bool IsMine(int x, int y)
        {
            return this.bombs[x, y];
        }

        public bool IsAlreadyShown(int x, int y)
        {
            return this.Matrix[x, y] != this.unrevealedCellChar;
        }
    }
}
