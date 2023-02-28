namespace SortAlgorithmComparison.Algorithms.Interfaces;

/// <summary>
/// Sorting algorithm interface.
/// </summary>
public interface ISortingAlgorithm
{
    /// <summary>
    /// Updated event.
    /// </summary>
    event EventHandler<int[]> Updated;

    /// <summary>
    /// Gets name.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Sorts array.
    /// </summary>
    /// <param name="array">Array.</param>
    /// <param name="token">Cancellation token.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    Task<int[]> Sort(int[] array, CancellationToken token);
}
