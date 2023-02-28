// Source: https://github.com/Mika-dot/Array-sorting
// Article: https://habr.com/ru/post/689738/

using SortAlgorithmComparison.Algorithms.Interfaces;
using SortAlgorithmComparison.Utils;
using Waves.Core.Base.Attributes;

namespace SortAlgorithmComparison.Algorithms;

/// <summary>
/// Gnome sort.
/// </summary>
[WavesPlugin(typeof(ISortingAlgorithm))]
public class GnomeSort : SortingAlgorithmBase
{
    /// <inheritdoc />
    public override string Name => "Gnome sort";

    /// <inheritdoc />
    public override void Sort(ref int[] array)
    {
        var index = 1;
        var nextIndex = index + 1;

        while (index < array.Length)
        {
            if (array[index - 1] < array[index])
            {
                index = nextIndex;
                nextIndex++;
            }
            else
            {
                SortUtils.Swap(ref array[index - 1], ref array[index]);
                index--;
                if (index != 0)
                {
                    continue;
                }

                index = nextIndex;
                nextIndex++;
            }
        }
    }
}
