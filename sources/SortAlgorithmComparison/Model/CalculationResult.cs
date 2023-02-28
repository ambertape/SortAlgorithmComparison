using SortAlgorithmComparison.Algorithms.Interfaces;

namespace SortAlgorithmComparison.Model;

/// <summary>
/// Calculation result.
/// </summary>
public class CalculationResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CalculationResult"/> class.
    /// </summary>
    /// <param name="count">Count.</param>
    /// <param name="algorithm">Algorithm.</param>
    /// <param name="elapsedMilliseconds">Elapsed milliseconds.</param>
    public CalculationResult(int count, ISortingAlgorithm algorithm, long elapsedMilliseconds)
    {
        Count = count;
        Algorithm = algorithm;
        ElapsedMilliseconds = elapsedMilliseconds;
    }

    /// <summary>
    /// Gets count.
    /// </summary>
    public int Count { get; }

    /// <summary>
    /// Gets elapsed milliseconds.
    /// </summary>
    public long ElapsedMilliseconds { get; }

    /// <summary>
    /// Gets sorting algorithm.
    /// </summary>
    public ISortingAlgorithm Algorithm { get; }
}
