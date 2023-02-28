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
public class ShellSort : SortingAlgorithmBase
{
    /// <inheritdoc />
    public override string Name => "Shell sort";

    /// <inheritdoc />
    public override async Task<int[]> Sort(int[] array, CancellationToken token)
    {
        var d = array.Length / 2;
        while (d >= 1)
        {
            if (token.IsCancellationRequested)
            {
                break;
            }

            for (var i = d; i < array.Length; i++)
            {
                if (token.IsCancellationRequested)
                {
                    break;
                }

                var j = i;
                while ((j >= d) && (array[j - d] > array[j]))
                {
                    SortUtils.Swap(ref array[j], ref array[j - d]);
                    j = j - d;
                    await OnUpdated(array);
                }
            }

            d /= 2;
        }

        return array;
    }
}
