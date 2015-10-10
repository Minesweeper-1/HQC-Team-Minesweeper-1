namespace Minesweeper.Logic.Contents
{
    using Common;
    using Contracts;

    /// <summary>
    /// A class implementing the IContent interface when the content is empty
    /// </summary>
    public class EmptyContent : IContent
    {
        /// <summary>
        /// Empty content constructor
        /// </summary>
        public EmptyContent()
        {
            this.ContentType = ContentType.Empty;
            this.Value = 0;
        }

        public ContentType ContentType
        {
            get;
            private set;
        }

        public int Value
        {
            get;
            set;
        }
    }
}
