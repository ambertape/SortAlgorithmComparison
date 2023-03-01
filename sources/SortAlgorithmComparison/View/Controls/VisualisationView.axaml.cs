using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Logging;
using SortAlgorithmComparison.ViewModel;
using SortAlgorithmComparison.ViewModel.Controls;
using Waves.UI.Avalonia.Controls;
using Waves.UI.Base.Attributes;
using Waves.UI.Services.Interfaces;

namespace SortAlgorithmComparison.View.Controls;

/// <summary>
/// Test dialog.
/// </summary>
public partial class VisualisationView : WavesDialog
{
    /// <summary>
    /// Creates new instance os <see cref="VisualisationView"/>.
    /// </summary>
    public VisualisationView()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Creates new instance of <see cref="VisualisationView"/>.
    /// </summary>
    /// <param name="logger">Logger.</param>
    /// <param name="navigationService">Navigation service.</param>
    public VisualisationView(
        ILogger<VisualisationView> logger,
        IWavesNavigationService navigationService)
        : base(logger, navigationService)
    {
        InitializeComponent();
    }

    /// <summary>
    /// Initializes components.
    /// </summary>
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
