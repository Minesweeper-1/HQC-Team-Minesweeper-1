namespace Minesweeper.Contents
{
    using Contracts;
    using Common;

    public class EmptyContent : IContent
    {
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
