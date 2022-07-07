using Fizyka.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Fizyka.Views;

public sealed partial class PredkoscChwilowaISredniaPage : Page
{
    public PredkoscChwilowaISredniaViewModel ViewModel
    {
        get;
    }

    public PredkoscChwilowaISredniaPage()
    {
        ViewModel = App.GetService<PredkoscChwilowaISredniaViewModel>();
        InitializeComponent();
    }
}
