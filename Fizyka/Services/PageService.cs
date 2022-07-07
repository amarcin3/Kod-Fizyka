using System;
using System.Collections.Generic;
using System.Linq;

using CommunityToolkit.Mvvm.ComponentModel;

using Fizyka.Contracts.Services;
using Fizyka.ViewModels;
using Fizyka.Views;

using Microsoft.UI.Xaml.Controls;

namespace Fizyka.Services;

public class PageService : IPageService
{
    private readonly Dictionary<string, Type> _pages = new();

    public PageService()
    {
        Configure<OpisViewModel, OpisPage>();
        Configure<RuchISpoczynekViewModel, RuchISpoczynekPage>();
        Configure<UkladWspolrzednychViewModel, UkladWspolrzednychPage>();
        Configure<WielkosciViewModel, WielkosciPage>();
        Configure<StalaPredkoscViewModel, StalaPredkoscPage>();
        Configure<ZaleznoscDrogiOdCzasuViewModel, ZaleznoscDrogiOdCzasuPage>();
        Configure<RuchZmiennyProstoliniowyViewModel, RuchZmiennyProstoliniowyPage>();
        Configure<PrzyspieszenieViewModel, PrzyspieszeniePage>();
        Configure<PredkoscChwilowaISredniaViewModel, PredkoscChwilowaISredniaPage>();
        Configure<RuchPrzyspieszonyViewModel, RuchPrzyspieszonyPage>();
        Configure<RuchJednostajeniePrzyspieszonyViewModel, RuchJednostajeniePrzyspieszonyPage>();
    }

    public Type GetPageType(string key)
    {
        Type pageType;
        lock (_pages)
        {
            if (!_pages.TryGetValue(key, out pageType))
            {
                throw new ArgumentException($"Page not found: {key}. Did you forget to call PageService.Configure?");
            }
        }

        return pageType;
    }

    private void Configure<VM, V>()
        where VM : ObservableObject
        where V : Page
    {
        lock (_pages)
        {
            var key = typeof(VM).FullName;
            if (_pages.ContainsKey(key))
            {
                throw new ArgumentException($"The key {key} is already configured in PageService");
            }

            var type = typeof(V);
            if (_pages.Any(p => p.Value == type))
            {
                throw new ArgumentException($"This type is already configured with key {_pages.First(p => p.Value == type).Key}");
            }

            _pages.Add(key, type);
        }
    }
}
