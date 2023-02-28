using Avalonia;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Logging;
using SortAlgorithmComparison.ViewModel;
using Waves.UI.Avalonia.Controls;
using Waves.UI.Base.Attributes;
using Waves.UI.Services.Interfaces;

namespace SortAlgorithmComparison.View
{
    /// <summary>
    /// Main window.
    /// </summary>
    [WavesView(typeof(MainWindowViewModel))]
    public partial class MainWindow : WavesWindow
    {
        /// <summary>
        /// Creates new instance os <see cref="MainWindow"/>.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        /// <summary>
        /// Creates new instance of <see cref="MainWindow"/>.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="navigationService">Navigation service.</param>
        public MainWindow(
            ILogger<MainWindow> logger,
            IWavesNavigationService navigationService)
            : base(logger, navigationService)
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        /// <summary>
        /// Initializes components.
        /// </summary>
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
