namespace Minesweeper.Logic.Contents
{
    using Common;
    using Contracts;

    public class ContentFactory
    {
        public virtual IContent GetContent(ContentType type = ContentType.Empty)
        {
            if (type == ContentType.Bomb)
            {
                return new Bomb();
            }

            return new EmptyContent();
        }
    }
}
