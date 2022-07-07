using Fizyka.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Fizyka.Views;

public sealed partial class OpisPage : Page
{
    public OpisViewModel ViewModel
    {
        get;
    }

    public OpisPage()
    {
        ViewModel = App.GetService<OpisViewModel>();
        InitializeComponent();
    }
}
