using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TwitchBot.WPF.Converters;
using TwitchBot.WPF.Models;
using TwitchBot.WPF.Services;

namespace TwitchBot.WPF.UserControls;

public partial class RowItem : UserControl
{
    public static readonly DependencyProperty LeftProperty =
        DependencyProperty.Register("Left", typeof(string), typeof(RowItem), new PropertyMetadata(default(string)));

    public string Left
    {
        get { return (string)GetValue(LeftProperty); }
        set { SetValue(LeftProperty, value); }
    }
    
    public static readonly DependencyProperty RightProperty =
        DependencyProperty.Register("Right", typeof(string), typeof(RowItem), new PropertyMetadata(default(string)));

    public string Right
    {
        get { return (string)GetValue(RightProperty); }
        set { SetValue(RightProperty, value); }
    }

    public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register(
        nameof(IsSelected), typeof(bool), typeof(RowItem), new PropertyMetadata(default(bool)));

    public bool IsSelected
    {
        get { return (bool)GetValue(IsSelectedProperty); }
        set { SetValue(IsSelectedProperty, value); }
    }
    
    public RowItem()
    {
        InitializeComponent();
    }

    private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        var textBlock = sender as TextBlock;

        var vm = textBlock.DataContext as RowItemViewModel;

       // vm.Right = "3";
    }
}