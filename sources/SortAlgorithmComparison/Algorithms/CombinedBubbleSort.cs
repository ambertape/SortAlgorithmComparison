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
    public override async Task<int[]> Sort(int[] array, CancellationToken token)
    {
        var length = array.Length;

        var temp = array[0];

        for (var i = 0; i < length; i++)
        {
            if (token.IsCancellationRequested)
            {
                break;
            }

            for (var j = i + 1; j < length; j++)
            {
                if (array[i] <= array[j])
                {
                    continue;
                }

                temp = array[i];
                array[i] = array[j];
                array[j] = temp;
                await OnUpdated(array);
            }
        }

        return array;
    }
}
