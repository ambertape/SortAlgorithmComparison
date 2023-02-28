// Source: https://github.com/Mika-dot/Array-sorting
// Article: https://habr.com/ru/post/689738/

using SortAlgorithmComparison.Algorithms.Interfaces;
using SortAlgorithmComparison.Utils;
using Waves.Core.Base.Attributes;

namespace SortAlgorithmComparison.Algorithms;

/// <summary>
/// Shell sort.
/// </summary>
[WavesPlugin(typeof(ISortingAlgorithm))]
public class ShellSort : ISortingAlgorithm
{
    /// <inheritdoc />
    public string Name => "Shell sort";

    /// <inheritdoc />
    public void Sort(ref int[] array)
    {
        var d = array.Length / 2;
        while (d >= 1)
        {
            for (var i = d; i < array.Length; i++)
            {
                var j = i;
                while ((j >= d) && (array[j - d] > array[j]))
                {
                    SortUtils.Swap(ref array[j], ref array[j - d]);
                    j = j - d;
                }
            }

            d /= 2;
        }
    }
}
