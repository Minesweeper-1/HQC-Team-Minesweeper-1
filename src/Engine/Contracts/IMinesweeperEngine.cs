namespace Minesweeper.Engine.Contracts
{
    using Boards.Contracts;
    using Renderers.Contracts;
    using InputProviders.Contracts;

    public interface IMinesweeperEngine
    {
        IBoard Board { get; set; }

        IRenderer Renderer { get; set; }

        IInputProvider InputProvider { get; set; }

        void Initialize(IGameInitializationStrategy initializationStrategy);

        void Run();
    }
}
