using MineSweeper_WPF.CustomWPFElelements;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MinesweeperWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.CreateButtons(10, 10);
        }

       

        private void CreateButtons(int x, int y)
        {
            Grid grid = Main;

            List<ColumnDefinition> cols = new List<ColumnDefinition>();

            for (int i = 0; i < x; i++)
            {
                var rowDef = new RowDefinition();
                rowDef.Height = GridLength.Auto;
                grid.RowDefinitions.Add(rowDef);


            }

            for (int i = 0; i < y; i++)
            {
                var colDef = new ColumnDefinition();
                colDef.Width = GridLength.Auto;
                grid.ColumnDefinitions.Add(colDef);
            }

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    var button = new MineSweeperButton(j, i);

                    button.Width = 30;
                    button.Height = 30;

                    grid.Children.Add(button);

                }
            }
         
        }
    }
}
