namespace Minesweeper.Logic.Contents
{
    using Common;
    using Contracts;

    /// <summary>
    /// A simple factory creating content
    /// </summary>
    public class ContentFactory
    {
        /// <summary>
        /// Content creating simple factory
        /// </summary>
        /// <param name="type">The type of the content to be created</param>
        /// <returns>The created content</returns>
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
