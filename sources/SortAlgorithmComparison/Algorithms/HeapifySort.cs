// Source: https://github.com/Mika-dot/Array-sorting
// Article: https://habr.com/ru/post/689738/

using SortAlgorithmComparison.Algorithms.Interfaces;
using Waves.Core.Base.Attributes;

namespace SortAlgorithmComparison.Algorithms;

/// <summary>
/// Heapify sort.
/// </summary>
[WavesPlugin(typeof(ISortingAlgorithm))]
public class HeapifySort : SortingAlgorithmBase
{
    /// <inheritdoc />
    public override string Name => "Heapify sort";

    /// <inheritdoc />
    public override async Task<int[]> Sort(int[] array, CancellationToken token)
    {
        for (var i = array.Length / 2 - 1; i >= 0; i--)
        {
            if (token.IsCancellationRequested)
            {
                break;
            }

            Heapify(array, array.Length, i);
            await OnUpdated(array);
        }

        for (var i = array.Length - 1; i >= 0; i--)
        {
            if (token.IsCancellationRequested)
            {
                break;
            }

            (array[0], array[i]) = (array[i], array[0]);
            Heapify(array, i, 0);
            await OnUpdated(array);
        }

        return array;
    }

    private static void Heapify(int[] arr, int heapSize, int heapRoot)
    {
        while (true)
        {
            var max = heapRoot;

            var leftChildIndex = 2 * heapRoot + 1;
            var rightChildIndex = 2 * heapRoot + 2;

            if (leftChildIndex < heapSize && arr[leftChildIndex] > arr[max])
            {
                max = leftChildIndex;
            }

            if (rightChildIndex < heapSize && arr[rightChildIndex] > arr[max])
            {
                max = rightChildIndex;
            }

            if (max != heapRoot)
            {
                (arr[heapRoot], arr[max]) = (arr[max], arr[heapRoot]);

                heapRoot = max;
                continue;
            }

            break;
        }
    }
}
