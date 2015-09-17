namespace Minesweeper.Boards
{
    using System;

    using Contracts;
    using Common;

    public class Board : IBoard
    {
        private char unrevealedCellChar;

        public Board()
        {
            this.InitializeBoard();
            this.PlantBombs();
        }

        public char[,] Matrix
        {
            get;
            set;
        }

        public bool[,] Bombs
        {
            get;
            set;
        }
        public int NumberOfMines
        {
            get;
            set;
        }

        public int Cols
        {
            get;
            set;
        }

        public int Rows
        {
            get;
            set;
        }

        private void InitializeBoard()
        {
            this.Rows = GlobalConstants.StandardNumberOfBoardRows;
            this.Cols = GlobalConstants.StandardNumberOfBoardCols;
            this.NumberOfMines = GlobalConstants.StandardNumberOfBoardCols;
            this.unrevealedCellChar = GlobalConstants.StandardUnrevealedBoardCellCharacter;
            this.Matrix = new char[this.Rows, this.Cols];
            this.Bombs = new bool[this.Rows, this.Cols];
        }
        

        private void PlantBombs()
        {
            var randomGenerator = new Random();
            for (var i = 0; i < this.NumberOfMines; i++)
            {
                int x = randomGenerator.Next(this.Rows + 1);
                int y = randomGenerator.Next(this.Cols + 1);
                bool isInsideBoard = this.IsInsideBoard(x, y);
                while (!isInsideBoard)
                {
                    x = randomGenerator.Next(this.Rows + 1);
                    y = randomGenerator.Next(this.Cols + 1);
                    isInsideBoard = this.IsInsideBoard(x, y);
                }

                this.Bombs[x, y] = true;
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
                        this.Bombs[row, col])
                    {
                        result++;
                    }
                }
            }

            if(this.Bombs[x, y])
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
            return (0 <= x && x < this.Rows) && (0 <= y && y < this.Cols);
        }

        public bool IsMine(int x, int y)
        {
            return this.Bombs[x, y];
        }

        public bool IsAlreadyShown(int x, int y)
        {
            return this.Matrix[x, y] != this.unrevealedCellChar;
        }
    }
}
