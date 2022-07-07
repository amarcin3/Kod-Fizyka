using Fizyka.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Fizyka.Views;

public sealed partial class RuchZmiennyProstoliniowyPage : Page
{
    public RuchZmiennyProstoliniowyViewModel ViewModel
    {
        get;
    }

    public RuchZmiennyProstoliniowyPage()
    {
        ViewModel = App.GetService<RuchZmiennyProstoliniowyViewModel>();
        InitializeComponent();
    }
}
