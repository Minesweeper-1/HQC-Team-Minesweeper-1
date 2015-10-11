namespace Minesweeper.Logic.Contents.Contracts
{
    using Common;

    /// <summary>
    /// Defines the interface for all Cell Content public members
    /// </summary>
    public interface IContent
    {
        /// <summary>
        /// Content type
        /// </summary>
        ContentType ContentType
        {
            get;
        }


        /// <summary>
        /// Content value
        /// </summary>
        int Value
        {
            get;
            set;
        }
    }
}
