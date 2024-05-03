using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TwitchBot.WPF.Models;

public class RowItemModel : INotifyPropertyChanged
{
    private string _left;
    private string _right;

    public string Left
    {
        get => _left;
        set
        {
            if (value == _left) return;
            _left = value;
            OnPropertyChanged();
        }
    }

    public string Right
    {
        get => _right;
        set
        {
            if (value == _right) return;
            _right = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}