using Fizyka.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Fizyka.Views;

public sealed partial class UkladWspolrzednychPage : Page
{
    public UkladWspolrzednychViewModel ViewModel
    {
        get;
    }

    public UkladWspolrzednychPage()
    {
        ViewModel = App.GetService<UkladWspolrzednychViewModel>();
        InitializeComponent();
    }
}
