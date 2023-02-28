using System.Collections.ObjectModel;
using System.Windows.Input;
using Avalonia.Threading;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using SortAlgorithmComparison.Algorithms.Interfaces;
using SortAlgorithmComparison.Model;
using SortAlgorithmComparison.Services;
using SortAlgorithmComparison.Utils;
using Waves.UI.Base.Attributes;
using Waves.UI.Charts.Drawing.Primitives;
using Waves.UI.Charts.Drawing.Primitives.Data;
using Waves.UI.Charts.Series;
using Waves.UI.Charts.Series.Interfaces;
using Waves.UI.Dialogs;
using Waves.UI.Presentation;
using Waves.UI.Services.Interfaces;

namespace SortAlgorithmComparison.ViewModel;

/// <summary>
/// Test dialog view model.
/// </summary>
[WavesViewModel(typeof(VisualisationDialogViewModel))]
public class VisualisationDialogViewModel : WavesDialogViewModelBase<ISortingAlgorithm, bool>
{
    private const int N = 200;
    private readonly DataGeneratorService _dataGeneratorService;
    private ISortingAlgorithm _algorithm;

    /// <summary>
    /// Initializes a new instance of the <see cref="TestDialogViewModel"/> class.
    /// </summary>
    /// <param name="navigationService">Navigation service.</param>
    /// <param name="logger">Logger.</param>
    /// <param name="dataGeneratorService">Data generator service.</param>
    public VisualisationDialogViewModel(
        IWavesNavigationService navigationService,
        ILogger<VisualisationDialogViewModel> logger,
        DataGeneratorService dataGeneratorService)
        : base(navigationService, logger)
    {
        _dataGeneratorService = dataGeneratorService;

        XMin = 0d;
        YMin = 10d;
        XMax = 200.1d;
        YMax = 10d;
    }

    /// <summary>
    /// Gets or sets algorithm name.
    /// </summary>
    [Reactive]
    public string AlgorithmName { get; set; }

    /// <summary>
    /// Gets or sets X Min.
    /// </summary>
    [Reactive]
    public object XMin { get; set; }

    /// <summary>
    /// Gets or sets X Max.
    /// </summary>
    [Reactive]
    public object XMax { get; set; }

    /// <summary>
    /// Gets or sets Y Min.
    /// </summary>
    [Reactive]
    public double YMin { get; set; }

    /// <summary>
    /// Gets or sets Y Max.
    /// </summary>
    [Reactive]
    public double YMax { get; set; }

    /// <summary>
    /// Gets or sets series.
    /// </summary>
    [Reactive]
    public ObservableCollection<IWaves2DSeries> Series { get; set; }

    /// <summary>
    /// Run single benchmark command.
    /// </summary>
    public ICommand RunVisualisation { get; private set; }

    /// <inheritdoc />
    public override async Task Prepare(ISortingAlgorithm t)
    {
        _algorithm = t;
        AlgorithmName = _algorithm.Name;
        RunVisualisation = ReactiveCommand.CreateFromTask(OnRunVisualisation);

        var unsortedArray = await _dataGeneratorService.Generate(N);
        var sortedArray = new int[N];
        unsortedArray.CopyTo(sortedArray, 0);

        await Dispatcher.UIThread.InvokeAsync(() =>
        {
            var min = unsortedArray.Min();
            var max = unsortedArray.Max();
            var delta = (max - min) / 10.0d; // view optimization

            var points = new WavesPoint[N];
            var color = WavesColor.Random();
            for (var i = 0; i < N; i++)
            {
                points[i] = new WavesPoint(i,  unsortedArray[i]);
            }

            Series = new ObservableCollection<IWaves2DSeries>
            {
                new WavesPointSeries(points)
                {
                    Color = color,
                },
            };

            YMin = min - delta;
            YMax = max + delta;
        });
    }

    private void UpdateChart(int[] array)
    {
        var points = new WavesPoint[N];
        var color = WavesColor.Random();
        for (var i = 0; i < N; i++)
        {
            points[i] = new WavesPoint(i, array[i]);
        }

        (Series[0] as WavesPointSeries)?.Update(points);
    }

    private Task OnRunVisualisation()
    {
        throw new NotImplementedException();
    }
}
