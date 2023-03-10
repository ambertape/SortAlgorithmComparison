// Source: https://github.com/Mika-dot/Array-sorting
// Article: https://habr.com/ru/post/689738/

using SortAlgorithmComparison.Algorithms.Interfaces;
using SortAlgorithmComparison.Utils;
using Waves.Core.Base.Attributes;

namespace SortAlgorithmComparison.Algorithms;

/// <summary>
/// Comb sort.
/// </summary>
[WavesPlugin(typeof(CombSort))]
public class CombSort : SortingAlgorithmBase
{
    /// <inheritdoc />
    public override string Name => "Comb sort";

    /// <inheritdoc />
    public override async Task<int[]> Sort(int[] array, CancellationToken token)
    {
        var arrayLength = array.Length;
        var currentStep = arrayLength - 1;

        while (currentStep > 1)
        {
            if (token.IsCancellationRequested)
            {
                break;
            }

            for (var i = 0; i + currentStep < array.Length; i++)
            {
                if (array[i] > array[i + currentStep])
                {
                    SortUtils.Swap(ref array[i], ref array[i + currentStep]);
                    await OnUpdated(array);
                }
            }

            currentStep = GetNextStep(currentStep);
        }

        for (var i = 1; i < arrayLength; i++)
        {
            if (token.IsCancellationRequested)
            {
                break;
            }

            var swapFlag = false;
            for (var j = 0; j < arrayLength - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    SortUtils.Swap(ref array[j], ref array[j + 1]);
                    await OnUpdated(array);
                    swapFlag = true;
                }
            }

            if (!swapFlag)
            {
                break;
            }
        }

        return array;
    }

    private static int GetNextStep(int s)
    {
        s = s * 1000 / 1247;
        return s > 1 ? s : 1;
    }
}
