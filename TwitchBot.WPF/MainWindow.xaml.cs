using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using TwitchBot.WPF.Models;

namespace TwitchBot.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<RowItemModel> Items { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Items = new ObservableCollection<RowItemModel>
            {
                new()
                {
                    Left = "Goryl",
                    Right = "1"
                },
                new()
                {
                    Left = "Queelag",
                    Right = "123"
                }
            };

            DataContext = this;
        }

        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch (Exception exception)
            {
            }
        }
    }
}