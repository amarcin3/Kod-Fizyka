using Fizyka.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Fizyka.Views;

public sealed partial class RuchJednostajeniePrzyspieszonyPage : Page
{
    public RuchJednostajeniePrzyspieszonyViewModel ViewModel
    {
        get;
    }

    public RuchJednostajeniePrzyspieszonyPage()
    {
        ViewModel = App.GetService<RuchJednostajeniePrzyspieszonyViewModel>();
        InitializeComponent();
    }
}
