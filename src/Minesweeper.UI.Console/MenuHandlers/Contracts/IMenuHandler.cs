namespace Minesweeper.UI.Console.MenuHandlers.Contracts
{
    using Logic.Boards.Settings.Contracts;

    public interface IMenuHandler
    {
        void ShowSelections();

        BoardSettings RequestUserSelection();
    }
}
