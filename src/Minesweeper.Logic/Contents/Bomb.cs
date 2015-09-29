namespace Minesweeper.Logic.Contents
{
    using Common;
    using Contracts;

    public class Bomb : IContent
    {
        public Bomb()
        {
            this.ContentType = ContentType.Bomb;
            this.Value = -1;
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
