// Source: https://github.com/Mika-dot/Array-sorting
// Article: https://habr.com/ru/post/689738/

namespace SortAlgorithmComparison.Utils;

/// <summary>
/// Sorting utils.
/// </summary>
public static class SortUtils
{
    /// <summary>
    /// Merge arrays.
    /// </summary>
    /// <param name="leftArr">First array.</param>
    /// <param name="rightArr">Right array.</param>
    /// <returns>Returns merged array.</returns>
    public static int[] MergeArray(int[] leftArr, int[] rightArr)
    {
        var mergedArr = new int[leftArr.Length + rightArr.Length];
        var leftIndex = 0;
        var rightIndex = 0;
        var mergedIndex = 0;

        // Traverse both arrays simultaneously and store the smallest element of both to mergedArr
        while (leftIndex < leftArr.Length && rightIndex < rightArr.Length)
        {
            if (leftArr[leftIndex] < rightArr[rightIndex])
            {
                mergedArr[mergedIndex++] = leftArr[leftIndex++];
            }
            else
            {
                mergedArr[mergedIndex++] = rightArr[rightIndex++];
            }
        }

        // If any elements remain in the left array, append them to mergedArr
        while (leftIndex < leftArr.Length)
        {
            mergedArr[mergedIndex++] = leftArr[leftIndex++];
        }

        // If any elements remain in the right array, append them to mergedArr
        while (rightIndex < rightArr.Length)
        {
            mergedArr[mergedIndex++] = rightArr[rightIndex++];
        }

        return mergedArr;
    }

    /// <summary>
    /// Gets index of element with max value in array.
    /// </summary>
    /// <param name="array">Array.</param>
    /// <param name="n">Count.</param>
    /// <returns>Returns index.</returns>
    public static int IndexOfMax(int[] array, int n)
    {
        int result = 0;
        for (var i = 1; i <= n; ++i)
        {
            if (array[i] > array[result])
            {
                result = i;
            }
        }

        return result;
    }

    /// <summary>
    /// Gets index of element with min value in array.
    /// </summary>
    /// <param name="array">Array.</param>
    /// <param name="n">Count.</param>
    /// <returns>Returns index.</returns>
    public static int IndexOfMin(int[] array, int n)
    {
        int result = n;
        for (var i = n; i < array.Length; ++i)
        {
            if (array[i] < array[result])
            {
                result = i;
            }
        }

        return result;
    }

    /// <summary>
    /// Flips array.
    /// </summary>
    /// <param name="array">Array.</param>
    /// <param name="end">Count.</param>
    public static void Flip(int[] array, int end)
    {
        for (var start = 0; start < end; start++, end--)
        {
            (array[start], array[end]) = (array[end], array[start]);
        }
    }

    /// <summary>
    /// Swaps elements.
    /// </summary>
    /// <param name="e1">First element.</param>
    /// <param name="e2">Second element.</param>
    public static void Swap(ref int e1, ref int e2)
    {
        (e1, e2) = (e2, e1);
    }

    /// <summary>
    /// Returns the index of the reference element.
    /// </summary>
    /// <param name="array">Array.</param>
    /// <param name="minIndex">Min index.</param>
    /// <param name="maxIndex">Max index.</param>
    /// <returns>Returns index.</returns>
    public static int Partition(int[] array, int minIndex, int maxIndex)
    {
        var pivot = minIndex - 1;
        for (var i = minIndex; i < maxIndex; i++)
        {
            if (array[i] >= array[maxIndex])
            {
                continue;
            }

            pivot++;
            Swap(ref array[pivot], ref array[i]);
        }

        pivot++;
        Swap(ref array[pivot], ref array[maxIndex]);
        return pivot;
    }

    /// <summary>
    /// Gets whether list is ordered.
    /// </summary>
    /// <param name="list">List.</param>
    /// <param name="comparer">Comparer.</param>
    /// <typeparam name="T">Type.</typeparam>
    /// <returns>Returns ordered or not.</returns>
    public static bool IsOrdered<T>(this IList<T> list, IComparer<T> comparer = null)
    {
        if (comparer == null)
        {
            comparer = Comparer<T>.Default;
        }

        if (list.Count > 1)
        {
            for (int i = 1; i < list.Count; i++)
            {
                if (comparer.Compare(list[i - 1], list[i]) > 0)
                {
                    return false;
                }
            }
        }

        return true;
    }
}
