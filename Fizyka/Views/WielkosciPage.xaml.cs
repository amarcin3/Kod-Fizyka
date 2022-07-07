using Fizyka.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Fizyka.Views;

public sealed partial class WielkosciPage : Page
{
    public WielkosciViewModel ViewModel
    {
        get;
    }

    public WielkosciPage()
    {
        ViewModel = App.GetService<WielkosciViewModel>();
        InitializeComponent();
    }
}
