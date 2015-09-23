namespace Minesweeper.Contents
{
    using Contracts;

    public class BombFactory : ContentFactory
    {
        public BombFactory()
        {

        }

        public override IContent GetContent()
        {
            return new Bomb();
        }
    }
}
