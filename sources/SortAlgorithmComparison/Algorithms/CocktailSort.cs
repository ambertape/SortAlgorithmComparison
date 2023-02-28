// Source: https://github.com/Mika-dot/Array-sorting
// Article: https://habr.com/ru/post/689738/

using SortAlgorithmComparison.Algorithms.Interfaces;
using Waves.Core.Base.Attributes;

namespace SortAlgorithmComparison.Algorithms;

/// <summary>
/// Cocktail sort.
/// </summary>
[WavesPlugin(typeof(ISortingAlgorithm))]
public class CocktailSort : SortingAlgorithmBase
{
    /// <inheritdoc />
    public override string Name => "Cocktail sort";

    /// <inheritdoc />
    public override void Sort(ref int[] array)
    {
        var start = 0;
        var end = array.Length - 1;
        var swapped = true;

        while (swapped)
        {
            swapped = false;

            int temp;
            for (var i = 0; i < end; i++)
            {
                if (array[i] > array[i + 1])
                {
                    temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                    swapped = true;
                }
            }

            if (!swapped)
            {
                break;
            }

            swapped = false;
            end -= 1;

            for (var i = end; i >= start; i--)
            {
                if (array[i] <= array[i + 1])
                {
                    continue;
                }

                temp = array[i];
                array[i] = array[i + 1];
                array[i + 1] = temp;
                swapped = true;
            }

            start += 1;
        }
    }
}
