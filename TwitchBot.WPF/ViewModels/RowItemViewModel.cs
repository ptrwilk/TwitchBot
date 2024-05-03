using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TwitchBot.WPF.Converters;
using TwitchBot.WPF.Services;

namespace TwitchBot.WPF.Models;

public class RowItemViewModel : INotifyPropertyChanged
{
    private string _left;
    private string _right;
    private bool _isSelected;

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
            
            ResultsService.Update(RowItemViewModelConverter.Convert(this));
        }
    }

    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            if (value == _isSelected) return;
            _isSelected = value;
            OnPropertyChanged();
        }
    }

    public void Increase()
    {
        Right = (RowItemViewModelConverter.Convert(this).Rips + 1).ToString();
    }
    
    public void Decrease()
    {
        Right = (RowItemViewModelConverter.Convert(this).Rips - 1).ToString();
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