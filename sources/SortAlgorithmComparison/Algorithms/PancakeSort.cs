// Source: https://github.com/Mika-dot/Array-sorting
// Article: https://habr.com/ru/post/689738/

using SortAlgorithmComparison.Algorithms.Interfaces;
using SortAlgorithmComparison.Utils;
using Waves.Core.Base.Attributes;

namespace SortAlgorithmComparison.Algorithms;

/// <summary>
/// Insertion sort algorithm.
/// </summary>
[WavesPlugin(typeof(ISortingAlgorithm))]
public class PancakeSort : SortingAlgorithmBase
{
    /// <inheritdoc />
    public override string Name => "Pancake sort";

    /// <inheritdoc />
    public override void Sort(ref int[] array)
    {
        for (var subArrayLength = array.Length - 1; subArrayLength >= 0; subArrayLength--)
        {
            var indexOfMax = SortUtils.IndexOfMax(array, subArrayLength);
            if (indexOfMax == subArrayLength)
            {
                continue;
            }

            SortUtils.Flip(array, indexOfMax);
            SortUtils.Flip(array, subArrayLength);
        }
    }
}
