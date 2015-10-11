namespace Minesweeper.Logic.Common
{
    /// <summary>
    /// Class dealing with the cell coordinates
    /// </summary>
    public class Coordinate
    {
        /// <summary>
        /// Constructor of the coordinate
        /// </summary>
        /// <param name="row">The row as an integer</param>
        /// <param name="col">The column as an integer</param>
        public Coordinate(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        /// <summary>
        /// Coordinate row
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Coordinate column
        /// </summary>
        public int Col { get; set; }

        /// <summary>
        /// An override Equals method that provides a way to check two coordinates for equality
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var otherCoordinate = obj as Coordinate;
            return otherCoordinate.Col == this.Col && otherCoordinate.Row == this.Row;
        }

        /// <summary>
        /// Returns hash code for the concrete coordinate
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
