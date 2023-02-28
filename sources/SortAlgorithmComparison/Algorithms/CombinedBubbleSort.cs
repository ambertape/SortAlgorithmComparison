// Source: https://github.com/Mika-dot/Array-sorting
// Article: https://habr.com/ru/post/689738/

using SortAlgorithmComparison.Algorithms.Interfaces;
using Waves.Core.Base.Attributes;

namespace SortAlgorithmComparison.Algorithms;

/// <summary>
/// Combined bubble sort.
/// </summary>
[WavesPlugin(typeof(ISortingAlgorithm))]
public class CombinedBubbleSort : SortingAlgorithmBase
{
    /// <inheritdoc />
    public override string Name => "Combined bubble sort";

    /// <inheritdoc />
    public override void Sort(ref int[] array)
    {
        var length = array.Length;

        var temp = array[0];

        for (var i = 0; i < length; i++)
        {
            for (var j = i + 1; j < length; j++)
            {
                if (array[i] <= array[j])
                {
                    continue;
                }

                temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }
}
