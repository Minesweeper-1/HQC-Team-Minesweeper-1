namespace Minesweeper.UI.Console.Engine.Contracts
{
    using Minesweeper.Logic.Boards.Contracts;

    public interface IGameInitializationStrategy
    {
        void Initialize(IBoard board);
    }
}
