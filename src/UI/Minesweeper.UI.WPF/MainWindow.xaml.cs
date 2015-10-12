// <copyright file="MainWindow.xaml.cs" company="Team Minesweeper-1">
// Copyright (c) The team. All rights reserved.
// </copyright>
namespace Minesweeper.UI.Wpf
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Entry point for the WPF application
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            Game.Instance.Start(this.Main);
        }
    }
}
