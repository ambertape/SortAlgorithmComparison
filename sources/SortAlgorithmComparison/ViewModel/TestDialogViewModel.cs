using System.Collections.ObjectModel;
using Microsoft.Extensions.Logging;
using ReactiveUI.Fody.Helpers;
using SortAlgorithmComparison.Algorithms.Interfaces;
using SortAlgorithmComparison.Services;
using SortAlgorithmComparison.Utils;
using Waves.UI.Base.Attributes;
using Waves.UI.Dialogs;
using Waves.UI.Presentation;
using Waves.UI.Services.Interfaces;

namespace SortAlgorithmComparison.ViewModel;

/// <summary>
/// Test dialog view model.
/// </summary>
[WavesViewModel(typeof(TestDialogViewModel))]
public class TestDialogViewModel : WavesDialogViewModelBase<ISortingAlgorithm, bool>
{
    private readonly DataGeneratorService _dataGeneratorService;
    private ISortingAlgorithm _algorithm;

    /// <summary>
    /// Initializes a new instance of the <see cref="TestDialogViewModel"/> class.
    /// </summary>
    /// <param name="navigationService">Navigation service.</param>
    /// <param name="logger">Logger.</param>
    /// <param name="dataGeneratorService">Data generator service.</param>
    public TestDialogViewModel(
        IWavesNavigationService navigationService,
        ILogger<TestDialogViewModel> logger,
        DataGeneratorService dataGeneratorService)
        : base(navigationService, logger)
    {
        _dataGeneratorService = dataGeneratorService;
    }

    /// <summary>
    /// Gets or sets algorithm name.
    /// </summary>
    [Reactive]
    public string AlgorithmName { get; set; }

    /// <summary>
    /// Gets or sets whether array order test successful.
    /// </summary>
    [Reactive]
    public bool IsOrdered { get; set; }

    /// <summary>
    /// Gets or sets unsorted items.
    /// </summary>
    public ObservableCollection<int> UnsortedItems { get; set; }

    /// <summary>
    /// Gets or sets unsorted items.
    /// </summary>
    public ObservableCollection<int> SortedItems { get; set; }

    /// <inheritdoc />
    public override async Task Prepare(ISortingAlgorithm t)
    {
        _algorithm = t;

        AlgorithmName = _algorithm.Name;

        var unsortedArray = await _dataGeneratorService.Generate(200);
        UnsortedItems = new ObservableCollection<int>(unsortedArray);

        var sortedArray = UnsortedItems.ToArray();
        _algorithm.Sort(ref sortedArray);
        SortedItems = new ObservableCollection<int>(sortedArray);

        IsOrdered = sortedArray.IsOrdered();
    }
}
