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
public class QuickSort : SortingAlgorithmBase
{
    /// <inheritdoc />
    public override string Name => "Quick sort";

    /// <inheritdoc />
    public override async Task<int[]> Sort(int[] array, CancellationToken token)
    {
        Sort(array, 0, array.Length - 1, token);
        return array;
    }

    private async Task<int[]> Sort(int[] array, int minIndex, int maxIndex, CancellationToken token)
    {
        if (token.IsCancellationRequested)
        {
            return array;
        }

        if (minIndex >= maxIndex)
        {
            return array;
        }

        var pivotIndex = SortUtils.Partition(array, minIndex, maxIndex);
        await Sort(array, minIndex, pivotIndex - 1, token);
        await Sort(array, pivotIndex + 1, maxIndex, token);

        await OnUpdated(array);
        return array;
    }
}
