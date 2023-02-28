// Source: https://github.com/Mika-dot/Array-sorting
// Article: https://habr.com/ru/post/689738/

using SortAlgorithmComparison.Algorithms.Interfaces;
using SortAlgorithmComparison.Utils;
using Waves.Core.Base.Attributes;

namespace SortAlgorithmComparison.Algorithms;

/// <summary>
/// Quick sorting.
/// </summary>
[WavesPlugin(typeof(ISortingAlgorithm))]
public class QuickSort : ISortingAlgorithm
{
    /// <inheritdoc />
    public string Name => "Quick sort";

    /// <inheritdoc />
    public void Sort(ref int[] array)
    {
        Sort(array, 0, array.Length - 1);
    }

    private static int[] Sort(int[] array, int minIndex, int maxIndex)
    {
        if (minIndex >= maxIndex)
        {
            return array;
        }

        var pivotIndex = SortUtils.Partition(array, minIndex, maxIndex);
        Sort(array, minIndex, pivotIndex - 1);
        Sort(array, pivotIndex + 1, maxIndex);

        return array;
    }
}
