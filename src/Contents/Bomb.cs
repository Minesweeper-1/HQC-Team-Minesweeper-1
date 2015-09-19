namespace Minesweeper.Contents
{
    using Contracts;
    using Common;

    public class Bomb : IContent
    {
        public Bomb()
        {
            this.ContentType = ContentType.Bomb;
        }

        public ContentType ContentType
        {
            get;
            private set;
        }
    }
}
