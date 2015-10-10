namespace Minesweeper.UI.Console.Renderers.Contracts
{
    using System.Collections.Generic;

    using Logic.Renderers.Contracts;
    using Logic.DifficultyCommands.Contracts;

    /// <summary>
    /// Handles Drawing to console
    /// </summary>
    public interface IConsoleRenderer : IRenderer
    {
        /// <summary>
        /// Write Line, without skipping line
        /// </summary>
        /// <param name="line"></param>
        void Render(string line);

        /// <summary>
        /// Write new line
        /// </summary>
        /// <param name="line"></param>
        void RenderLine(string line);

        /// <summary>
        /// Write WelcomScreen
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
        /// <param name="col">Collum count</param>
        void RenderMenu(IEnumerable<IGameMode> menuItems, int row, int col);

        /// <summary>
        /// Cursor coordinates
        /// </summary>
        /// <returns></returns>
        int[] GetCursor();

        /// <summary>
        /// Toggle curosor between visble and invisible
        /// </summary>
        /// <param name="visible"></param>
        void SetCursor(bool visible);

        /// <summary>
        /// Set Cursor coordinates
        /// </summary>
        /// <param name="row">Row coordinate</param>
        /// <param name="col">Collum coordinate</param>
        void SetCursor(int row, int col);

        /// <summary>
        /// Clear Console
        /// </summary>
        void ClearScreen();

        /// <summary>
        /// Clear current line
        /// </summary>
        void ClearCurrentLine();
    }
}
