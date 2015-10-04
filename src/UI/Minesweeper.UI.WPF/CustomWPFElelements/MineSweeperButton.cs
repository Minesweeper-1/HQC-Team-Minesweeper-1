using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;

namespace MineSweeper_WPF.CustomWPFElelements
{
    class MineSweeperButton : Button
    {
        public int Row { get; private set; }
        public int Col { get; private set; }

        public MineSweeperButton(int col, int row)
        {
            this.SetCol(col);
            this.SetRow(row);

            this.Click += this.Left;
            this.MouseRightButtonDown += this.Right;
        }
        private void SetCol(int col)
        {
            Grid.SetColumn(this, col);
            this.Col = col;
        }

        private void SetRow(int row)
        {
            Grid.SetRow(this, row);
            this.Row = row;
        }
        //C:\Users\ArgiDux\Documents\GitHub\HQC-Team-Minesweeper-1\src\UI\Minesweeper.UI.WPF\Resources\flag.png
        private void Left(object sender, RoutedEventArgs e)
        {
            var target = (MineSweeperButton)sender;

            var uri = new Uri("../../../Resources/flag.png", UriKind.Relative);
            var flag = new BitmapImage(uri);
            var bg = new ImageBrush(flag);
            target.Background = bg;
        }

        private void Right(object sender, RoutedEventArgs e)
        {
            var target = (MineSweeperButton)sender;
            target.Content = 2;
        }
    }
}
