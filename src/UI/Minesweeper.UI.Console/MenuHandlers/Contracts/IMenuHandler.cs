namespace Minesweeper.UI.Console.MenuHandlers.Contracts
{
    using Logic.Boards.Settings.Contracts;

    /// <summary>
    /// Defines an interface for a menu handler public members
    /// </summary>
    public interface IMenuHandler
    {
        /// <summary>
        /// Shows menu items
        /// </summary>
        void ShowSelections();

        /// <summary>
        /// Gets for user selection of menu
        /// </summary>
        /// <returns>YUpdated Board Settings</returns>
        BoardSettings RequestUserSelection();
    }
}
