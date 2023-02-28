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
    public abstract void Sort(ref int[] array);

    /// <summary>
    /// Updated callback.
    /// </summary>
    /// <param name="e">Updated array.</param>
    protected virtual void OnUpdated(int[] e)
    {
        Updated?.Invoke(this, e);
    }
}
