using Fizyka.Activation;
using Fizyka.Contracts.Services;
using Fizyka.Core.Contracts.Services;
using Fizyka.Core.Services;
using Fizyka.Helpers;
using Fizyka.Models;
using Fizyka.Services;
using Fizyka.ViewModels;
using Fizyka.Views;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;

// To learn more about WinUI3, see: https://docs.microsoft.com/windows/apps/winui/winui3/.
namespace Fizyka;

public partial class App : Application
{
    // The .NET Generic Host provides dependency injection, configuration, logging, and other services.
    // https://docs.microsoft.com/dotnet/core/extensions/generic-host
    // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
    // https://docs.microsoft.com/dotnet/core/extensions/configuration
    // https://docs.microsoft.com/dotnet/core/extensions/logging
    private static readonly IHost _host = Host
        .CreateDefaultBuilder()
        .ConfigureServices((context, services) =>
        {
            // Default Activation Handler
            services.AddTransient<ActivationHandler<LaunchActivatedEventArgs>, DefaultActivationHandler>();

            // Other Activation Handlers

            // Services
            services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
            services.AddSingleton<ILocalSettingsService, LocalSettingsServiceUnpackaged>();
            services.AddTransient<INavigationViewService, NavigationViewService>();

            services.AddSingleton<IActivationService, ActivationService>();
            services.AddSingleton<IPageService, PageService>();
            services.AddSingleton<INavigationService, NavigationService>();

            // Core Services
            services.AddSingleton<IFileService, FileService>();

            // Views and ViewModels
            services.AddTransient<RuchJednostajeniePrzyspieszonyViewModel>();
            services.AddTransient<RuchJednostajeniePrzyspieszonyPage>();
            services.AddTransient<RuchPrzyspieszonyViewModel>();
            services.AddTransient<RuchPrzyspieszonyPage>();
            services.AddTransient<PredkoscChwilowaISredniaViewModel>();
            services.AddTransient<PredkoscChwilowaISredniaPage>();
            services.AddTransient<PrzyspieszenieViewModel>();
            services.AddTransient<PrzyspieszeniePage>();
            services.AddTransient<RuchZmiennyProstoliniowyViewModel>();
            services.AddTransient<RuchZmiennyProstoliniowyPage>();
            services.AddTransient<ZaleznoscDrogiOdCzasuViewModel>();
            services.AddTransient<ZaleznoscDrogiOdCzasuPage>();
            services.AddTransient<StalaPredkoscViewModel>();
            services.AddTransient<StalaPredkoscPage>();
            services.AddTransient<WielkosciViewModel>();
            services.AddTransient<WielkosciPage>();
            services.AddTransient<UkladWspolrzednychViewModel>();
            services.AddTransient<UkladWspolrzednychPage>();
            services.AddTransient<RuchISpoczynekViewModel>();
            services.AddTransient<RuchISpoczynekPage>();
            services.AddTransient<OpisViewModel>();
            services.AddTransient<OpisPage>();
            services.AddTransient<ShellPage>();
            services.AddTransient<ShellViewModel>();

            // Configuration
            services.Configure<LocalSettingsOptions>(context.Configuration.GetSection(nameof(LocalSettingsOptions)));
        })
        .Build();

    public static T GetService<T>()
        where T : class
    {
        return _host.Services.GetService(typeof(T)) as T;
    }

    public static Window MainWindow { get; set; } = new Window() { Title = "AppDisplayName".GetLocalized() };

    public App()
    {
        InitializeComponent();
        UnhandledException += App_UnhandledException;
    }

    private void App_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        // TODO: Log and handle exceptions as appropriate.
        // For more details, see https://docs.microsoft.com/windows/winui/api/microsoft.ui.xaml.unhandledexceptioneventargs.
    }

    protected async override void OnLaunched(LaunchActivatedEventArgs args)
    {
        base.OnLaunched(args);
        var activationService = App.GetService<IActivationService>();
        await activationService.ActivateAsync(args);
    }
}
