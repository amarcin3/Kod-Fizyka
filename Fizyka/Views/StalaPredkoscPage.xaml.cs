using Fizyka.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Fizyka.Views;

public sealed partial class StalaPredkoscPage : Page
{
    public StalaPredkoscViewModel ViewModel
    {
        get;
    }

    public StalaPredkoscPage()
    {
        ViewModel = App.GetService<StalaPredkoscViewModel>();
        InitializeComponent();
    }
}
