namespace Minesweeper.UI.Wpf.Renderers.Contracts
{
    using System.Windows.Controls;

    using Logic.Renderers.Contracts;

    /// <summary>
    /// Defines all public members of a WpfRenderer
    /// </summary>
    public interface IWpfRenderer : IRenderer
    {
        Grid Grid { get; }
    }
}
