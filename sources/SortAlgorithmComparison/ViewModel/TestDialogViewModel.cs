using System.Collections.ObjectModel;
using Microsoft.Extensions.Logging;
using ReactiveUI.Fody.Helpers;
using SortAlgorithmComparison.Algorithms.Interfaces;
using SortAlgorithmComparison.Model;
using SortAlgorithmComparison.Services;
using SortAlgorithmComparison.Utils;
using Waves.UI.Base.Attributes;
using Waves.UI.Charts.Drawing.Primitives;
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
    public ObservableCollection<SortResult> UnsortedItems { get; set; }

    /// <summary>
    /// Gets or sets unsorted items.
    /// </summary>
    public ObservableCollection<SortResult> SortedItems { get; set; }

    /// <inheritdoc />
    public override async Task Prepare(ISortingAlgorithm t)
    {
        _algorithm = t;

        AlgorithmName = _algorithm.Name;

        UnsortedItems = new ObservableCollection<SortResult>();
        SortedItems = new ObservableCollection<SortResult>();

        var n = 200;
        var unsortedArray = await _dataGeneratorService.Generate(n);
        var sortedArray = new int[n];
        var delta = Constants.GeneratorMaxValue - Constants.GeneratorMinValue;
        unsortedArray.CopyTo(sortedArray, 0);
        sortedArray = await _algorithm.Sort(sortedArray, new CancellationToken());
        IsOrdered = sortedArray.IsOrdered();

        var step = 255.0d / delta;
        for (var i = 0; i < n; i++)
        {
            var value1 = unsortedArray[i];
            var value2 = sortedArray[i];
            UnsortedItems.Add(new SortResult()
            {
                Color = GetColor(value1, delta),
                Value = value1,
            });

            SortedItems.Add(new SortResult()
            {
                Color = GetColor(value2, delta),
                Value = value2,
            });
        }
    }

    private WavesColor GetColor(int value, int delta)
    {
        var v = value / (float)delta;
        if (v <= 0)
        {
            var r = Convert.ToByte(255 * Math.Abs(v));
            return new WavesColor(r, 0, 128);
        }

        var g = Convert.ToByte(255 * Math.Abs(v));
        return new WavesColor(0, g, 128);
    }
}
