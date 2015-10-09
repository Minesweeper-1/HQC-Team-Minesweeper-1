namespace Minesweeper.Logic.Contents.Contracts
{
    using Common;

    /// <summary>
    /// Interface defining content type and value
    /// </summary>
    public interface IContent
    {
        ContentType ContentType
        {
            get;
        }

        int Value
        {
            get;
            set;
        }
    }
}
