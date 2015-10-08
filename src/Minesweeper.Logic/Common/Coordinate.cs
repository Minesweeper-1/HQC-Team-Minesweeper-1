namespace Minesweeper.Logic.Common
{
    public class Coordinate
    {
        public Coordinate(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public override bool Equals(object obj)
        {
            var otherCoordinate = obj as Coordinate;
            return (otherCoordinate.Col == this.Col && otherCoordinate.Row == this.Row);
        }
    }
}
