namespace Minesweeper.Contents
{
    using Common;
    using Contracts;

    public class ContentFactory
    {
        public ContentFactory()
        {

        }

        public IContent GetContent(ContentType contentType)
        {
            switch (contentType)
            {
                case ContentType.Empty:
                    return new EmptyContent();
                case ContentType.Bomb:
                    return new Bomb();
                default:
                    return new EmptyContent();
            }
        }
    }
}
