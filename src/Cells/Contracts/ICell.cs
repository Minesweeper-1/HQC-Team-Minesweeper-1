namespace Minesweeper.Cells.Common.Contracts
{
    using Contents.Contracts;

    public interface ICell
    {
        int Row
        {
            get;
            set;
        }

        int Col
        {
            get;
            set;
        }

        IContent Content
        {
            get;
            set;
        }
    }
}
