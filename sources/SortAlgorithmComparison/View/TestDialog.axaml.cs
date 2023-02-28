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
[WavesView(typeof(TestDialogViewModel))]
public partial class TestDialog : WavesDialog
{
    /// <summary>
    /// Creates new instance os <see cref="TestDialog"/>.
    /// </summary>
    public TestDialog()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Creates new instance of <see cref="TestDialog"/>.
    /// </summary>
    /// <param name="logger">Logger.</param>
    /// <param name="navigationService">Navigation service.</param>
    public TestDialog(
        ILogger<TestDialog> logger,
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
