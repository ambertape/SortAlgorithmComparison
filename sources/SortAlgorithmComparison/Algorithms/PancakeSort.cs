using SortAlgorithmComparison.Algorithms.Interfaces;
using SortAlgorithmComparison.Utils;
using Waves.Core.Base.Attributes;

namespace SortAlgorithmComparison.Algorithms;

/// <summary>
/// Insertion sort algorithm.
/// </summary>
[WavesPlugin(typeof(ISortingAlgorithm))]
public class PancakeSort : ISortingAlgorithm
{
    /// <inheritdoc />
    public string Name => "Pancake sort";

    /// <inheritdoc />
    public void Sort(ref int[] array)
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
