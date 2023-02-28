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
public class MergeSort : ISortingAlgorithm
{
    /// <inheritdoc />
    public string Name => "Merge sort";

    /// <inheritdoc />
    public void Sort(ref int[] array)
    {
        array = Sort(array, 0, array.Length - 1);
    }

    private static int[] Sort(int[] array, int start, int end)
    {
        if (start >= end)
        {
            return new[] { array[start] };
        }

        var middle = (end + start) / 2;
        var leftArr = Sort(array, start, middle);
        var rightArr = Sort(array, middle + 1, end);
        var mergedArr = SortUtils.MergeArray(leftArr, rightArr);
        return mergedArr;
    }
}
