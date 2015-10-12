// <copyright file="MineSweeperButton.cs" company="Team Minesweeper-1">
// Copyright (c) The team. All rights reserved.
// </copyright>
namespace Minesweeper.UI.Wpf.CustomWpfElelements
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// A minesweeper button class inheriting the Button class
    /// </summary>
    public class MinesweeperButton : Button
    {
        private ImageBrush background;
        private int clickCount;
        private Uri currentUri;
        private BitmapImage image;

        /// <summary>
        /// The button constructor
        /// </summary>
        /// <param name="col">The column of the button</param>
        /// <param name="row">The row of the button</param>
        public MinesweeperButton(int col, int row)
        {
            this.SetCol(col);
            this.SetRow(row);

            this.Click += this.Left;
            this.MouseRightButtonDown += this.Right;
            this.GotMouseCapture += this.SetAlpha;

            TriggerCollection s = this.Triggers;
        }

        public int Col { get; private set; }

        public int Row { get; private set; }

        private void Left(object sender, RoutedEventArgs e)
        {
            var target = (MinesweeperButton)sender;
            target.Content = 2;
        }

        private void Right(object sender, RoutedEventArgs e)
        {
            var target = (MinesweeperButton)sender;
            switch (this.clickCount)
            {
                case 0:
                    this.currentUri = new Uri("../../../Resources/flag.png", UriKind.Relative);
                    this.image = new BitmapImage(this.currentUri);
                    this.background = new ImageBrush(this.image);
                    target.Background = this.background;
                    this.clickCount++;
                    break;

                case 1:
                    this.currentUri = new Uri("../../../Resources/bomb.png", UriKind.Relative);
                    this.image = new BitmapImage(this.currentUri);
                    this.background = new ImageBrush(this.image);
                    target.Background = this.background;
                    this.clickCount++;
                    break;

                default:
                    target.Background = null;
                    this.clickCount = 0;
                    break;
            }
        }

        private void SetAlpha(object sender, RoutedEventArgs e)
        {
            this.Style = (Style)Application.Current.Resources["WindowButtons"];
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
    }
}