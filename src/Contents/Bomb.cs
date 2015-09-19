﻿namespace Minesweeper.Contents
{
    using Contracts;
    using Common;

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
