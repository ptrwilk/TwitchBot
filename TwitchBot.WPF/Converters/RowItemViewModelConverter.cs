using TwitchBot.WPF.Models;

namespace TwitchBot.WPF.Converters;

public static class RowItemViewModelConverter
{
    public static RowItemViewModel Convert(ResultModel model)
    {
        return new RowItemViewModel
        {
            Left = model.Boss,
            Right = model.Rips.ToString()
        };
    }
    
    public static ResultModel Convert(RowItemViewModel viewModel)
    {
        return new ResultModel
        {
            Boss = viewModel.Left,
            Rips = int.Parse(viewModel.Right)
        };
    }
}