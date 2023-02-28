using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Logging;
using SortAlgorithmComparison.ViewModel;
using Waves.UI.Avalonia;

namespace SortAlgorithmComparison
{
    /// <summary>
    /// App.
    /// </summary>
    public class Application : WavesApplication
    {
        /// <inheritdoc />
        public override void Initialize()
        {
            base.Initialize();
            AvaloniaXamlLoader.Load(this);
        }

        /// <inheritdoc />
        public override async void OnFrameworkInitializationCompleted()
        {
            try
            {
                switch (ApplicationLifetime)
                {
                    case IClassicDesktopStyleApplicationLifetime desktop:
                        await NavigationService.NavigateAsync<MainWindowViewModel>();
                        await NavigationService.NavigateAsync<MainPageViewModel>();
                        break;
                    case ISingleViewApplicationLifetime singleViewPlatform:
                        await NavigationService.NavigateAsync<MainPageViewModel>();
                        break;
                }

                base.OnFrameworkInitializationCompleted();
            }
            catch (Exception e)
            {
                Logger.LogError("Error occured while doing initial navigation: {Message}", e);
            }
        }
    }
}
