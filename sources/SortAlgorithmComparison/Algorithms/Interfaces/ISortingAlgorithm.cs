namespace SortAlgorithmComparison.Algorithms.Interfaces;

/// <summary>
/// Sorting algorithm interface.
/// </summary>
public interface ISortingAlgorithm
{
    /// <summary>
    /// Gets name.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Sorts array.
    /// </summary>
    /// <param name="array">Array.</param>
    void Sort(ref int[] array);
}
