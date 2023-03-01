using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Avalonia.Threading;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using SortAlgorithmComparison.Algorithms.Interfaces;
using SortAlgorithmComparison.Model;
using SortAlgorithmComparison.Services;
using SortAlgorithmComparison.Utils;
using SortAlgorithmComparison.ViewModel.Controls;
using Waves.Core.Extensions;
using Waves.UI.Avalonia.Charts.Controls;
using Waves.UI.Base.Attributes;
using Waves.UI.Charts.Drawing.Primitives;
using Waves.UI.Charts.Drawing.Primitives.Data;
using Waves.UI.Charts.Series;
using Waves.UI.Charts.Series.Interfaces;
using Waves.UI.Presentation;
using Waves.UI.Services.Interfaces;

namespace SortAlgorithmComparison.ViewModel;

/// <summary>
/// Main page view model.
/// </summary>
[WavesViewModel(typeof(MainPageViewModel))]
public class MainPageViewModel : WavesViewModelBase
{
    private readonly DataGeneratorService _dataGeneratorService;
    private readonly IEnumerable<ISortingAlgorithm> _algorithms;
    private readonly IWavesNavigationService _navigationService;
    private readonly IWavesDialogService _dialogService;
    private readonly ILogger<MainPageViewModel> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainPageViewModel"/> class.
    /// </summary>
    /// <param name="dataGeneratorService">Data generator service.</param>
    /// <param name="algorithms">Available algorithms.</param>
    /// <param name="navigationService">Navigation service.</param>
    /// <param name="dialogService">Dialog service.</param>
    /// <param name="logger">Logger.</param>
    public MainPageViewModel(
        DataGeneratorService dataGeneratorService,
        IEnumerable<ISortingAlgorithm> algorithms,
        IWavesNavigationService navigationService,
        IWavesDialogService dialogService,
        ILogger<MainPageViewModel> logger)
    {
        _dataGeneratorService = dataGeneratorService;
        _algorithms = algorithms;
        _navigationService = navigationService;
        _dialogService = dialogService;
        _logger = logger;

        // default values
        Minimum = 500;
        Maximum = 3000;
        XMin = Minimum;
        YMin = Maximum;
        XMax = 10;
        YMax = 10;
        NumberOrRuns = 1;
    }

    /// <summary>
    /// Progress text.
    /// </summary>
    [Reactive]
    public string ProgressText { get; set; }

    /// <summary>
    /// Gets or sets minimum values.
    /// </summary>
    [Reactive]
    public int Minimum { get; set; }

    /// <summary>
    /// Gets or sets maximum values.
    /// </summary>
    [Reactive]
    public int Maximum { get; set; }

    /// <summary>
    /// Gets or sets number of runs per algorithm.
    /// </summary>
    [Reactive]
    public int NumberOrRuns { get; set; }

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
    /// Selected algorithm.
    /// </summary>
    [Reactive]
    public ISortingAlgorithm SelectedAlgorithm { get; set; }

    /// <summary>
    /// Gets or sets available algorithms.
    /// </summary>
    [Reactive]
    public ObservableCollection<ISortingAlgorithm> AvailableAlgorithms { get; set; }

    /// <summary>
    /// Gets or sets calculated algorithms items.
    /// </summary>
    [Reactive]
    public ObservableCollection<CalculatedAlgorithm> CalculatedAlgorithms { get; set; }

    /// <summary>
    /// Gets test algorithm command.
    /// </summary>
    public ICommand TestAlgorithm { get; private set; }

    /// <summary>
    /// Gets visualize algorithm command.
    /// </summary>
    public ICommand VisualizeAlgorithm { get; private set; }

    /// <summary>
    /// Run single benchmark command.
    /// </summary>
    public ICommand RunSingleBenchmark { get; private set; }

    /// <summary>
    /// Run full benchmark command.
    /// </summary>
    public ICommand RunFullBenchmark { get; private set; }

    /// <inheritdoc />
    public override async Task InitializeAsync()
    {
        await base.InitializeAsync();

        // data
        AvailableAlgorithms = new ObservableCollection<ISortingAlgorithm>(_algorithms);
        if (AvailableAlgorithms.Count > 0)
        {
            SelectedAlgorithm = AvailableAlgorithms.First();
        }

        Series = new ObservableCollection<IWaves2DSeries>();
        CalculatedAlgorithms = new ObservableCollection<CalculatedAlgorithm>();

        // commands
        RunSingleBenchmark = ReactiveCommand.CreateFromTask(OnRunSingleBenchmark);
        RunFullBenchmark = ReactiveCommand.CreateFromTask(OnRunFullBenchmark);
        TestAlgorithm = ReactiveCommand.CreateFromTask(OnTestAlgorithm);
        VisualizeAlgorithm = ReactiveCommand.CreateFromTask(OnVisualizeAlgorithm);
    }

    private async Task OnVisualizeAlgorithm()
    {
        await _navigationService.NavigateAsync<VisualisationViewModel, ISortingAlgorithm>(SelectedAlgorithm);
    }

    private async Task OnTestAlgorithm()
    {
        await _navigationService.NavigateAsync<TestDialogViewModel, ISortingAlgorithm>(SelectedAlgorithm);
    }

    private async Task OnRunSingleBenchmark()
    {
        Task.Run(async () =>
        {
            try
            {
                LoadingState.IsLoading = true;
                PrepareCalculation();
                var algorithms = new List<ISortingAlgorithm>()
                {
                    SelectedAlgorithm,
                };
                await Calculate(algorithms, Minimum, Maximum);
            }
            catch (Exception e)
            {
                _logger.LogError("An error occured while calculating: {Message}", e.Message);
                await _dialogService.ShowDialogAsync($"An error occured while calculating: {e.Message}", e);
            }
            finally
            {
                LoadingState.IsLoading = false;
            }
        }).FireAndForget();
    }

    private async Task OnRunFullBenchmark()
    {
        Task.Run(async () =>
        {
            try
            {
                LoadingState.IsLoading = true;
                PrepareCalculation();
                await Calculate(AvailableAlgorithms.ToList(), Minimum, Maximum);
                CalculatedAlgorithms = new ObservableCollection<CalculatedAlgorithm>(CalculatedAlgorithms.OrderBy(x => x.TotalTime));
            }
            catch (Exception e)
            {
                _logger.LogError("An error occured while calculating: {Message}", e.Message);
                await _dialogService.ShowDialogAsync($"An error occured while calculating: {e.Message}", e);
            }
            finally
            {
                LoadingState.IsLoading = false;
            }
        }).FireAndForget();
    }

    private void PrepareCalculation()
    {
        Series.Clear();
        CalculatedAlgorithms.Clear();
    }

    private async Task PrepareChartResults(IEnumerable<CalculationResult> results)
    {
        var calculationResults = results as CalculationResult[] ?? results.ToArray();
        var min = calculationResults.Min(x => x.ElapsedMilliseconds);
        var max = calculationResults.Max(x => x.ElapsedMilliseconds);

        await Dispatcher.UIThread.InvokeAsync(() =>
        {
            var algorithmGroups = calculationResults.GroupBy(x => x.Algorithm);
            foreach (var algorithmGroup in algorithmGroups)
            {
                var count = Maximum - Minimum;
                var points = new WavesPoint[count];
                var color = WavesColor.Random();
                var algorithmResults = algorithmGroup.ToList();
                var totalTime = algorithmResults.Sum(x => x.ElapsedMilliseconds) / 1000d; // sec
                var item = new CalculatedAlgorithm(algorithmGroup.Key.Name, color, Math.Round(totalTime, 1));

                for (var i = 0; i < count; i++)
                {
                    var x = algorithmResults[i].Count;
                    var y = algorithmResults[i].ElapsedMilliseconds;
                    points[i] = new WavesPoint(x, y);
                }

                var series1 = new WavesPointSeries(points)
                {
                    Color = color,
                    Opacity = 1,
                };

                Series.Add(series1);
                CalculatedAlgorithms.Add(item);
            }

            XMin = Convert.ToDouble(Minimum);
            XMax = Convert.ToDouble(Maximum);

            var delta = (max - min) / 10.0d; // view optimization

            var yMin = min - delta;
            var yMax = max + delta;

            if (YMin > yMin)
            {
                YMin = yMin;
            }

            if (YMax < yMax)
            {
                YMax = yMax;
            }
        });
    }

    private async Task Calculate(IList<ISortingAlgorithm> algorithms, int min, int max)
    {
        LoadingState.IsLoading = true;
        LoadingState.IsIndeterminate = false;
        LoadingState.ProgressValue = 0;

        var count = max - min;
        var stopWatch = new Stopwatch();
        var algorithmCount = algorithms.Count;
        var progressCount = 0;
        var progressMaximum = count * algorithmCount * NumberOrRuns;

        for (var i = 0; i < algorithmCount; i++)
        {
            var results = new List<CalculationResult>();
            var algorithm = algorithms[i];
            for (var j = min; j < max; j++)
            {
                var array = await _dataGeneratorService.Generate(j);
                var meanElapsed = 0l;
                for (var n = 0; n < NumberOrRuns; n++)
                {
                    stopWatch.Reset();
                    stopWatch.Start();
                    await algorithm.Sort(array, new CancellationToken());
                    stopWatch.Stop();
                    meanElapsed += stopWatch.ElapsedMilliseconds;
                    progressCount++;
                }

                meanElapsed /= NumberOrRuns;
                results.Add(new CalculationResult(j, algorithm, meanElapsed));

                var progressValue = Convert.ToInt32(100.0f * progressCount / progressMaximum);
                if (LoadingState.ProgressValue == progressValue)
                {
                    continue;
                }

                LoadingState.ProgressValue = progressValue;
                ProgressText = $"Calculating for {algorithm.Name}... ({progressValue}%)";
            }

            await PrepareChartResults(results);
        }

        LoadingState.IsLoading = false;
    }
}
