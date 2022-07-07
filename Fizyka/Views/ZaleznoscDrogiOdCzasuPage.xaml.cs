using Fizyka.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Fizyka.Views;

public sealed partial class ZaleznoscDrogiOdCzasuPage : Page
{
    public ZaleznoscDrogiOdCzasuViewModel ViewModel
    {
        get;
    }

    public ZaleznoscDrogiOdCzasuPage()
    {
        ViewModel = App.GetService<ZaleznoscDrogiOdCzasuViewModel>();
        InitializeComponent();
    }
}
