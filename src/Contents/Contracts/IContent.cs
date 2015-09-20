﻿namespace Minesweeper.Contents.Contracts
{
    using Common;

    public interface IContent
    {
        ContentType ContentType
        {
            get;
        }

        int Value
        {
            get;
            set;
        }
    }
}