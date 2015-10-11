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

        /// <summary>
        /// Bomb content type
        /// </summary>
        public ContentType ContentType
        {
            get;
            private set;
        }

        /// <summary>
        /// Bomb content value
        /// </summary>
        public int Value
        {
            get;
            set;
        }
    }
}
