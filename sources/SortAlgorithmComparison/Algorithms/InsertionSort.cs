// Source: https://github.com/Mika-dot/Array-sorting
// Article: https://habr.com/ru/post/689738/

using SortAlgorithmComparison.Algorithms.Interfaces;
using Waves.Core.Base.Attributes;

namespace SortAlgorithmComparison.Algorithms;

/// <summary>
/// Insertion sort algorithm.
/// </summary>
[WavesPlugin(typeof(ISortingAlgorithm))]
public class InsertionSort : ISortingAlgorithm
{
    /// <inheritdoc />
    public string Name => "Insertion sort";

    /// <inheritdoc />
    public void Sort(ref int[] array)
    {
        var n = array.Length;
        for (var i = 1; i < n; ++i)
        {
            var key = array[i];
            var j = i - 1;

            // Move elements of arr[0..i-1],
            // that are greater than key,
            // to one position ahead of
            // their current position
            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j = j - 1;
            }

            array[j + 1] = key;
        }
    }
}
