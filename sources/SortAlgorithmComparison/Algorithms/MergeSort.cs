// Source: https://github.com/Mika-dot/Array-sorting
// Article: https://habr.com/ru/post/689738/

using SortAlgorithmComparison.Algorithms.Interfaces;
using SortAlgorithmComparison.Utils;
using Waves.Core.Base.Attributes;

namespace SortAlgorithmComparison.Algorithms;

/// <summary>
/// Merge sort.
/// </summary>
[WavesPlugin(typeof(ISortingAlgorithm))]
public class MergeSort : SortingAlgorithmBase
{
    /// <inheritdoc />
    public override string Name => "Merge sort";

    /// <inheritdoc />
    public override async Task<int[]> Sort(int[] array, CancellationToken token)
    {
        array = await Sort(array, 0, array.Length - 1, token);
        return array;
    }

    private async Task<int[]> Sort(int[] array, int start, int end, CancellationToken token)
    {
        if (token.IsCancellationRequested)
        {
            return array;
        }

        if (start >= end)
        {
            return new[] { array[start] };
        }

        var middle = (end + start) / 2;
        var leftArr = await Sort(array, start, middle, token);
        var rightArr = await Sort(array, middle + 1, end, token);
        var mergedArr = SortUtils.MergeArray(leftArr, rightArr);
        await OnUpdated(array);
        return mergedArr;
    }
}
