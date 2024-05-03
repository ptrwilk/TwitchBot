using System.Windows;
using System.Windows.Controls;

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
    
    public RowItem()
    {
        InitializeComponent();
    }
}