// Source: https://github.com/Mika-dot/Array-sorting
// Article: https://habr.com/ru/post/689738/

using SortAlgorithmComparison.Algorithms.Interfaces;
using SortAlgorithmComparison.Utils;
using Waves.Core.Base.Attributes;

namespace SortAlgorithmComparison.Algorithms;

/// <summary>
/// Shaker sort.
/// </summary>
[WavesPlugin(typeof(ISortingAlgorithm))]
public class ShakerSort : ISortingAlgorithm
{
    /// <inheritdoc />
    public string Name => "Shaker sort";

    /// <inheritdoc />
    public void Sort(ref int[] array)
    {
        for (var i = 0; i < array.Length / 2; i++)
        {
            var swapFlag = false;
            for (var j = i; j < array.Length - i - 1; j++)
            {
                if (array[j] <= array[j + 1])
                {
                    continue;
                }

                SortUtils.Swap(ref array[j], ref array[j + 1]);
                swapFlag = true;
            }

            for (var j = array.Length - 2 - i; j > i; j--)
            {
                if (array[j - 1] <= array[j])
                {
                    continue;
                }

                SortUtils.Swap(ref array[j - 1], ref array[j]);
                swapFlag = true;
            }

            if (!swapFlag)
            {
                break;
            }
        }
    }
}
