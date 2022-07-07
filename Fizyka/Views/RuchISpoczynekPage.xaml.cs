using Fizyka.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Fizyka.Views;

public sealed partial class RuchISpoczynekPage : Page
{
    public RuchISpoczynekViewModel ViewModel
    {
        get;
    }

    public RuchISpoczynekPage()
    {
        ViewModel = App.GetService<RuchISpoczynekViewModel>();
        InitializeComponent();
    }
}
