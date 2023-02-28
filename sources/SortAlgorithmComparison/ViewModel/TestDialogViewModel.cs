using Microsoft.Extensions.Logging;
using SortAlgorithmComparison.Algorithms.Interfaces;
using Waves.UI.Base.Attributes;
using Waves.UI.Presentation;

namespace SortAlgorithmComparison.ViewModel;

/// <summary>
/// Test dialog view model.
/// </summary>
[WavesViewModel(typeof(TestDialogViewModel))]
public class TestDialogViewModel : WavesParameterizedViewModelBase<ISortingAlgorithm>
{
    private ISortingAlgorithm _algorithm;

    /// <summary>
    /// Initializes a new instance of the <see cref="TestDialogViewModel"/> class.
    /// </summary>
    /// <param name="logger">Logger.</param>
    public TestDialogViewModel(ILogger<TestDialogViewModel> logger)
        : base(logger)
    {
    }

    /// <inheritdoc />
    public override Task Prepare(ISortingAlgorithm t)
    {
        _algorithm = t;
        return Task.CompletedTask;
    }
}
