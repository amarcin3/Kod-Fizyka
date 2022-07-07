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

namespace Fizyka;

public partial class App : Application
{
    private static readonly IHost _host = Host
        .CreateDefaultBuilder()
        .ConfigureServices((context, services) =>
        {
            services.AddTransient<ActivationHandler<LaunchActivatedEventArgs>, DefaultActivationHandler>();
            services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
            services.AddSingleton<ILocalSettingsService, LocalSettingsServiceUnpackaged>();
            services.AddTransient<INavigationViewService, NavigationViewService>();
            services.AddSingleton<IActivationService, ActivationService>();
            services.AddSingleton<IPageService, PageService>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IFileService, FileService>();
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
    {}

    protected async override void OnLaunched(LaunchActivatedEventArgs args)
    {
        base.OnLaunched(args);
        var activationService = App.GetService<IActivationService>();
        await activationService.ActivateAsync(args);
    }
}
