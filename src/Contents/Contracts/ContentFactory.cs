namespace Minesweeper.Contents
{
    using Common;
    using Contracts;

    public abstract class ContentFactory
    {
        public ContentFactory()
        {

        }

        public abstract IContent GetContent();
    }
}
