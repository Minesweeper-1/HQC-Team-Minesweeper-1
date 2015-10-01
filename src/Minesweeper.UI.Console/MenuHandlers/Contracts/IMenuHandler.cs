namespace Minesweeper.UI.MenuHandlers.Contracts
{
    using Logic.Boards;

    public interface IMenuHandler
    {
        void ShowSelections();

        BoardSettings RequestUserSelection();
    }
}
