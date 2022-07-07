using Fizyka.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Fizyka.Views;

public sealed partial class RuchPrzyspieszonyPage : Page
{
    public RuchPrzyspieszonyViewModel ViewModel
    {
        get;
    }

    public RuchPrzyspieszonyPage()
    {
        ViewModel = App.GetService<RuchPrzyspieszonyViewModel>();
        InitializeComponent();
    }
}
