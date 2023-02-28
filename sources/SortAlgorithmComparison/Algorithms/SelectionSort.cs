// Source: https://github.com/Mika-dot/Array-sorting
// Article: https://habr.com/ru/post/689738/

using SortAlgorithmComparison.Algorithms.Interfaces;
using SortAlgorithmComparison.Utils;
using Waves.Core.Base.Attributes;

namespace SortAlgorithmComparison.Algorithms;

/// <summary>
/// Selection sort.
/// </summary>
[WavesPlugin(typeof(ISortingAlgorithm))]
public class SelectionSort : SortingAlgorithmBase
{
    /// <inheritdoc />
    public override string Name => "Selection sort";

    /// <inheritdoc />
    public override async Task<int[]> Sort(int[] array, CancellationToken token)
    {
        Sorting(ref array, 0, token);
        await OnUpdated(array);
        return array;
    }

    private static void Sorting(ref int[] array, int currentIndex = 0, CancellationToken token = default)
    {
        while (true)
        {
            if (token.IsCancellationRequested)
            {
                break;
            }

            if (currentIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(currentIndex));
            }

            if (currentIndex == array.Length)
            {
                return;
            }

            var index = SortUtils.IndexOfMin(array, currentIndex);
            if (index != currentIndex)
            {
                SortUtils.Swap(ref array[index], ref array[currentIndex]);
            }

            currentIndex += 1;
        }
    }
}
