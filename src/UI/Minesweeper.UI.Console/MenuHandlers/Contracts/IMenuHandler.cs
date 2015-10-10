namespace Minesweeper.UI.Console.MenuHandlers.Contracts
{
    using Logic.Boards.Settings.Contracts;

    /// <summary>
    /// Handles Menu operations
    /// </summary>
    public interface IMenuHandler
    {
        void ShowSelections();

        /// <summary>
        /// Wait for user selection of menu
        /// </summary>
        /// <returns>YUpdated Board Settings</returns>
        BoardSettings RequestUserSelection();
    }
}
