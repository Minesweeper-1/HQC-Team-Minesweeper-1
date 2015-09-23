namespace Minesweeper.Contents
{
    using Contracts;

    public class EmptyContentFactory : ContentFactory
    {
        public EmptyContentFactory()
        {

        }

        public override IContent GetContent()
        {
            return new EmptyContent();
        }
    }
}
