using SortAlgorithmComparison.Algorithms.Interfaces;

namespace SortAlgorithmComparison.Algorithms;

/// <summary>
/// Sorting algorithm base.
/// </summary>
public abstract class SortingAlgorithmBase : ISortingAlgorithm
{
    /// <inheritdoc />
    public event EventHandler<int[]>? Updated;

    /// <inheritdoc />
    public abstract string Name { get; }

    /// <inheritdoc />
    public abstract Task<int[]> Sort(int[] array, CancellationToken token);

    /// <summary>
    /// Updated callback.
    /// </summary>
    /// <param name="e">Updated array.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    protected async Task OnUpdated(int[] e)
    {
        if (Updated != null)
        {
            Updated?.Invoke(this, e);
            await Task.Delay(25);  // for visualisation
        }
    }
}
