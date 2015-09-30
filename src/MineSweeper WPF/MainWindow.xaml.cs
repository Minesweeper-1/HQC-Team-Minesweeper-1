using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MineSweeper_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CreateButtons(10, 10);
           
        }

        private void Left(object sender, RoutedEventArgs e)
        {
            var target = (Button)sender;
            target.Content = 1;
            
        }

        private void Right(object sender, RoutedEventArgs e)
        {
            var target = (Button)sender;
            target.Content = 2;
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
                    var button = new Button();
                    //button.Content = i * y + j;
                    button.Width = 30;
                    button.Height = 30;
                    button.Click += Left;
                    button.MouseRightButtonDown += Right;
                    grid.Children.Add(button);
                    Grid.SetColumn(button, j);
                    Grid.SetRow(button, i);
                }
            }
         
        }
    }
}
