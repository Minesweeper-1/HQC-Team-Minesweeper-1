namespace Minesweeper.Boards
{
    using Contracts;
    using Common;

    public class Board : IBoard
    {
        public Board()
        {
            this.InitializeBoard();
        }

        public int NumberOfMines
        {
            get;
            private set;
        }

        public int Cols
        {
            get;
            private set;
        }

        public int Rows
        {
            get;
            private set;
        }

        public char UnrevealedCellChar
        {
            get;
            private set;
        }

        public char[,] Matrix
        {
            get;
            private set;
        }

        public bool[,] Bombs
        {
            get;
            private set;
        }

        private void InitializeBoard()
        {
            this.Rows = GlobalConstants.StandardNumberOfBoardRows;
            this.Cols = GlobalConstants.StandardNumberOfBoardCols;
            this.NumberOfMines = GlobalConstants.StandardNumberOfBoardCols;
            this.UnrevealedCellChar = GlobalConstants.StandardUnrevealedBoardCellCharacter;
            this.Matrix = new char[this.Rows, this.Cols];
            this.Bombs = new bool[this.Rows, this.Cols];
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

        public bool IsBomb(int x, int y)
        {
            return this.Bombs[x, y];
        }

        public bool IsAlreadyShown(int x, int y)
        {
            return this.Matrix[x, y] != this.UnrevealedCellChar;
        }
    }
}
