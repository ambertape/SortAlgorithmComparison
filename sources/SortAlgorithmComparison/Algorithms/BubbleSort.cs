// Source: https://github.com/Mika-dot/Array-sorting

using SortAlgorithmComparison.Algorithms.Interfaces;
using SortAlgorithmComparison.Utils;
using Waves.Core.Base.Attributes;

namespace SortAlgorithmComparison.Algorithms;

/// <summary>
/// Bubble sort implementation.
/// </summary>
[WavesPlugin(typeof(ISortingAlgorithm))]
public class BubbleSort : ISortingAlgorithm
{
    /// <inheritdoc />
    public string Name => "Bubble sort";

    /// <inheritdoc />
    public void Sort(ref int[] array)
    {
        var len = array.Length;
        for (var i = 1; i < len; i++)
        {
            for (var j = 0; j < len - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    SortUtils.Swap(ref array[j], ref array[j + 1]);
                }
            }
        }
    }
}
