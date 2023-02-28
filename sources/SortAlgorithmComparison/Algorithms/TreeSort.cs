// Source: https://github.com/Mika-dot/Array-sorting
// Article: https://habr.com/ru/post/689738/

using SortAlgorithmComparison.Algorithms.Interfaces;
using SortAlgorithmComparison.Model;
using Waves.Core.Base.Attributes;

namespace SortAlgorithmComparison.Algorithms;

/// <summary>
/// Tree sort.
/// </summary>
[WavesPlugin(typeof(ISortingAlgorithm))]
public class TreeSort : SortingAlgorithmBase
{
    /// <inheritdoc />
    public override string Name => "Tree sort";

    /// <inheritdoc />
    public override async Task<int[]> Sort(int[] array, CancellationToken token)
    {
        var treeNode = new TreeNode(array[0]);
        for (var i = 1; i < array.Length; i++)
        {
            if (token.IsCancellationRequested)
            {
                break;
            }

            treeNode.Insert(new TreeNode(array[i]));
            await OnUpdated(array);
        }

        array = treeNode.Transform();
        return array;
    }
}
