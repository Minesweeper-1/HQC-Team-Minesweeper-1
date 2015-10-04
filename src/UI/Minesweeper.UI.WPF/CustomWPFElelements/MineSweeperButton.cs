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
        
        private int clickCount = 0;
        private Uri currentUri;
        private BitmapImage image;
        private ImageBrush background;

        public MineSweeperButton(int col, int row)
        {
            this.SetCol(col);
            this.SetRow(row);

            this.Click += this.Left;
            this.MouseRightButtonDown += this.Right;
            this.GotMouseCapture += SetAlpha;


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
            target.Content = 2;


        }

        private void SetAlpha(object sender, RoutedEventArgs e)
        {
            this.Style = (Style)Application.Current.Resources["WindowButtons"];
        }

        private void Right(object sender, RoutedEventArgs e)
        {
            var target = (MineSweeperButton)sender;
            switch (clickCount)
            {
                case 0:
                    this.currentUri = new Uri("../../../Resources/flag.png", UriKind.Relative);
                    this.image = new BitmapImage(currentUri);
                    this.background = new ImageBrush(image);
                    target.Background = background;
                    this.clickCount++;
                    break;
                case 1:
                    this.currentUri = new Uri("../../../Resources/bomb.png", UriKind.Relative);
                    this.image = new BitmapImage(currentUri);
                    this.background = new ImageBrush(image);
                    //target.Background=null;
                    target.Background = background;
                    this.clickCount++;
                    break;
                default:
                    target.Background = null;
                    this.clickCount = 0;
                    break;
            }
           
        }
    }
}
