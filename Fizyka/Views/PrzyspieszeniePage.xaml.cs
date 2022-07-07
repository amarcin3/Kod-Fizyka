using Fizyka.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Fizyka.Views;

public sealed partial class PrzyspieszeniePage : Page
{
    public PrzyspieszenieViewModel ViewModel
    {
        get;
    }

    public PrzyspieszeniePage()
    {
        ViewModel = App.GetService<PrzyspieszenieViewModel>();
        InitializeComponent();
    }
}
