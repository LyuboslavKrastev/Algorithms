using System;
using System.Collections.Generic;
using System.Text;

namespace P01_MergeSort
{
    class MergeSort<T> where T : IComparable
    {
        public static void Sort(T[] arr, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex) // 1 element array
            {
                return;
            }

            var middleIndex = (startIndex + endIndex) / 2;

            Sort(arr, startIndex, middleIndex); // left portion
            Sort(arr, middleIndex + 1, endIndex); // right portion

            Merge(arr, startIndex, middleIndex, endIndex);
        }



        private static void Merge(T[] arr, int startIndex, int middleIndex, int endIndex)
        {
            if (middleIndex < 0 || middleIndex + 1 >= arr.Length
                || IsLessOrEqual(arr[middleIndex], arr[middleIndex + 1])) // sorted
            {
                return;
            }

            T[] auxArray = new T[arr.Length];

            for (int i = startIndex; i <= endIndex; i++)
            {
                auxArray[i] = arr[i];
            }

            int leftIndex = startIndex;
            int rightIndex = middleIndex + 1;

            for (int i = startIndex; i <= endIndex; i++)
            {
                if (leftIndex > middleIndex)
                {
                    arr[i] = auxArray[rightIndex++];
                }
                else if (rightIndex > endIndex)
                {
                    arr[i] = auxArray[leftIndex++];
                }
                else if (IsLessOrEqual(auxArray[leftIndex], auxArray[rightIndex]))
                {
                    arr[i] = auxArray[leftIndex++];
                }
                else
                {
                    arr[i] = auxArray[rightIndex++];
                }
            }
        }
        static bool IsLessOrEqual(IComparable first, IComparable second)
        {
            return first.CompareTo(second) <= 0;
        }
    }
}
