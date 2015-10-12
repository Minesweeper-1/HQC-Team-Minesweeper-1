namespace Minesweeper.UI.Wpf.Renderers
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;

    using Contracts;
    using CustomWpfElelements;
    using Logic.Boards.Contracts;
    using Logic.Renderers.Contracts;

    /// <summary>
    /// Concrete implementation of the IWpfRenderer and IRenderer interfaces
    /// </summary>
    public class WpfRenderer : IWpfRenderer, IRenderer
    {
        /// <summary>
        /// Creates a new WpfRenderer
        /// </summary>
        /// <param name="root"></param>
        public WpfRenderer(Grid root)
        {
            this.Grid = root;
        }

        /// <summary>
        /// The main drawing grid
        /// </summary>
        public Grid Grid { get; set; }

        /// <summary>
        /// Renders the board on the grid
        /// </summary>
        /// <param name="values">Input parameters</param>
        public void RenderBoard(params object[] values)
        {
            var board = (IBoard)values[0];
            this.DrawGrid(this.Grid, board.Rows, board.Cols);
        }

        private void DrawGrid(Grid grid, int rows, int cols)
        {
            var gridCols = new List<ColumnDefinition>();

            for (int r = 0; r < rows; r++)
            {
                var rowDef = new RowDefinition();
                rowDef.Height = GridLength.Auto;
                grid.RowDefinitions.Add(rowDef);
            }

            for (int c = 0; c < cols; c++)
            {
                var colDef = new ColumnDefinition();
                colDef.Width = GridLength.Auto;
                grid.ColumnDefinitions.Add(colDef);
            }

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    var button = new MinesweeperButton(c, r);
                    button.Width = 30;
                    button.Height = 30;
                    grid.Children.Add(button);
                }
            }
        }
    }
}
