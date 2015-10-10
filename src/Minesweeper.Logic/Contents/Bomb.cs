namespace Minesweeper.Logic.Contents
{
    using Common;
    using Contracts;

    /// <summary>
    /// A class implementing the IContent interface when the content is a bomb
    /// </summary>
    public class Bomb : IContent
    {
        /// <summary>
        /// Bomb constructor
        /// </summary>
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
