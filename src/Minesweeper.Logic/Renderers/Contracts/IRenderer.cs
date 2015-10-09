namespace Minesweeper.Logic.Renderers.Contracts
{
    /// <summary>
    /// An interface providing a common RenderBoard method for rendering the board by given params array
    /// </summary>
    public interface IRenderer
    {
        /// <summary>
        /// A method for rendering the playing board
        /// </summary>
        /// <param name="values">The params used for rendering of the board passed as an array</param>
        void RenderBoard(params object[] values);
    }
}
