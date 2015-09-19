namespace Minesweeper.Common
{
    using System;

    public class Cell
    {
        public Cell(int row, int col, char value)
        {
            this.Row = row;
            this.Col = col;
            this.Value = value;
        }

        public int Row
        {
            get;
            set;
        }

        public int Col
        {
            get;
            set;
        }

        public char Value
        {
            get;
            set;
        }

        public override bool Equals(object otherCellAsObject)
        {
            var otherCell = otherCellAsObject as Cell;
            if(otherCell == null)
            {
                throw new ArgumentException(GlobalMessages.InvalidCellObject);
            }

            bool areEqual = this.Row == otherCell.Row && this.Col == otherCell.Col;

            return areEqual;
        }
    }
}
