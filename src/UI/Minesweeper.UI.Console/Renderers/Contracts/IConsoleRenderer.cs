namespace Minesweeper.UI.Console.Renderers.Contracts
{
    using System.Collections.Generic;

    using Logic.Renderers.Contracts;
    using Logic.DifficultyCommands.Contracts;

    /// <summary>
    /// Defines an interface for a console rendering object public members
    /// </summary>
    public interface IConsoleRenderer : IRenderer
    {
        /// <summary>
        /// Write without line break
        /// </summary>
        /// <param name="line"></param>
        void Render(string line);

        /// <summary>
        /// Write with line break
        /// </summary>
        /// <param name="line"></param>
        void RenderLine(string line);

        /// <summary>
        /// Render the welcome screen
        /// </summary>
        /// <param name="welcomeScreen">Welcome screen view</param>
        void RenderWelcomeScreen(string welcomeScreen);

        /// <summary>
        /// Render request for user name
        /// </summary>
        void RenderNewPlayerCreationRequest();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuItems">Menu items</param>
        /// <param name="row">Row count</param>
        /// <param name="col">Column count</param>
        void RenderMenu(IEnumerable<IGameMode> menuItems, int row, int col);

        /// <summary>
        /// Returns the cursor coordinates
        /// </summary>
        /// <returns></returns>
        int[] GetCursor();

        /// <summary>
        /// Toggle cursor between visble and invisible
        /// </summary>
        /// <param name="visible"></param>
        void SetCursor(bool visible);

        /// <summary>
        /// Set cursor coordinates
        /// </summary>
        /// <param name="row">Row coordinate</param>
        /// <param name="col">Collum coordinate</param>
        void SetCursor(int row, int col);

        /// <summary>
        /// Clear screen
        /// </summary>
        void ClearScreen();

        /// <summary>
        /// Clear current line
        /// </summary>
        void ClearCurrentLine();
    }
}
