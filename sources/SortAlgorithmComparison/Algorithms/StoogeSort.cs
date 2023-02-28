// using SortAlgorithmComparison.Algorithms.Interfaces;
// using SortAlgorithmComparison.Utils;
// using Waves.Core.Base.Attributes;
//
// namespace SortAlgorithmComparison.Algorithms;
//
// /// <summary>
// /// Stooge sort.
// /// </summary>
// [WavesPlugin(typeof(ISortingAlgorithm))]
// public class StoogeSort : ISortingAlgorithm
// {
//     /// <inheritdoc />
//     public string Name => "Stooge sort";
//
//     /// <inheritdoc />
//     public Task<int[]> Sort(int[] array)
//     {
//         Stooge(ref array, 0, array.Length - 1);
//         return Task.FromResult(array);
//     }
//
//     private static void Stooge(ref int[] array, int startIndex, int endIndex)
//     {
//         if (array[startIndex] > array[endIndex])
//         {
//             SortUtils.Swap(ref array[startIndex], ref array[endIndex]);
//         }
//
//         if (endIndex - startIndex <= 1)
//         {
//             return;
//         }
//
//         var len = (endIndex - startIndex + 1) / 3;
//         Stooge(ref array, startIndex, endIndex - len);
//         Stooge(ref array, startIndex + len, endIndex);
//         Stooge(ref array, startIndex, endIndex - len);
//     }
// }
