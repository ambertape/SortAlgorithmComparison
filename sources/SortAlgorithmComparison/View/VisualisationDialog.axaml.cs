using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Logging;
using SortAlgorithmComparison.ViewModel;
using Waves.UI.Avalonia.Controls;
using Waves.UI.Base.Attributes;
using Waves.UI.Services.Interfaces;

namespace SortAlgorithmComparison.View;

/// <summary>
/// Test dialog.
/// </summary>
[WavesView(typeof(VisualisationDialogViewModel))]
public partial class VisualisationDialog : WavesDialog
{
    /// <summary>
    /// Creates new instance os <see cref="VisualisationDialog"/>.
    /// </summary>
    public VisualisationDialog()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Creates new instance of <see cref="VisualisationDialog"/>.
    /// </summary>
    /// <param name="logger">Logger.</param>
    /// <param name="navigationService">Navigation service.</param>
    public VisualisationDialog(
        ILogger<VisualisationDialog> logger,
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
