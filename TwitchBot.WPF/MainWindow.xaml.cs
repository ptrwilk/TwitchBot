using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using TwitchBot.Core;
using TwitchBot.WPF.Converters;
using TwitchBot.WPF.Helpers;
using TwitchBot.WPF.Models;
using TwitchBot.WPF.Services;

namespace TwitchBot.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<RowItemViewModel> Items { get; set; }

        private KeyReader _reader = new KeyReader();

        public MainWindow()
        {
            Items = new ObservableCollection<RowItemViewModel>();

            foreach (var result in ResultsService.GetAll())
            {
                Items.Add(RowItemViewModelConverter.Convert(result));
            }

            Items[1].IsSelected = true;

            InitializeComponent();
            
            _reader.Start();

            _reader.KeyPressed += (ctrlPressed, key) =>
            {
                if (key == Keys.Num_0)
                {
                    var item = Items.First(x => x.Left == "Hexaners");

                    if (ctrlPressed)
                    {
                        item.Decrease();
                    }
                    else
                    {
                        item.Increase();
                    }
                }
                else if (key == Keys.Num_8)
                {
                    var selectedItemIndex = Items.IndexOf(Items.First(x => x.IsSelected == true));

                    if (selectedItemIndex > 1)
                    {
                        Items[selectedItemIndex].IsSelected = false;
                        Items[selectedItemIndex - 1].IsSelected = true;
                    }
                }
                else if (key == Keys.Num_2)
                {
                    var selectedItemIndex = Items.IndexOf(Items.First(x => x.IsSelected == true));

                    if (selectedItemIndex < Items.Count - 1)
                    {
                        Items[selectedItemIndex].IsSelected = false;
                        Items[selectedItemIndex + 1].IsSelected = true;
                    }
                }
                else if (key == Keys.Num_5)
                {
                    var item = Items.First(x => x.IsSelected);
                    var hexaners = Items.First(x => x.Left == "Hexaners");
                    
                    if (ctrlPressed)
                    {
                        item.Decrease();
                        hexaners.Decrease();
                    }
                    else
                    {
                        item.Increase();
                        hexaners.Increase();
                    }
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