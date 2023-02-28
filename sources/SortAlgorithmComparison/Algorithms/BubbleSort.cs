// Source: https://github.com/Mika-dot/Array-sorting
// Article: https://habr.com/ru/post/689738/

using SortAlgorithmComparison.Algorithms.Interfaces;
using SortAlgorithmComparison.Utils;
using Waves.Core.Base.Attributes;

namespace SortAlgorithmComparison.Algorithms;

/// <summary>
/// Bubble sort implementation.
/// </summary>
[WavesPlugin(typeof(ISortingAlgorithm))]
public class BubbleSort : SortingAlgorithmBase
{
    /// <inheritdoc />
    public override string Name => "Bubble sort";

    /// <inheritdoc />
    public override void Sort(ref int[] array)
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
