using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Sorting
{
    class QuickSort
    {
        public static void Sort<T>(T[] arr)
            where T : IComparable
        {
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Sort<T>(T[] arr, int leftIndex, int rightIndex) 
            where T : IComparable
        {
            if (leftIndex > rightIndex)
            {
                return;
            }

            int pivot = Partition(arr, leftIndex, rightIndex);

            Sort(arr, leftIndex, pivot - 1);
            Sort(arr, pivot + 1, rightIndex);
        }

        private static int Partition<T>(T[] arr, int leftIndex, int rightIndex) where T : IComparable
        {
            if (leftIndex >= rightIndex)
            {
                return leftIndex;
            }

            int i = leftIndex;
            int j = rightIndex + 1;

            while (true)
            {
                while (IsLess(arr[++i], arr[leftIndex]))
                {
                    if (i == rightIndex)
                    {
                        break;
                    }
                }

                while (IsLess(arr[leftIndex], arr[--j]))
                {
                    if (j == leftIndex)
                    {
                        break;
                    }
                }

                if (i >= j)
                {
                    break;
                }
                Swap(arr, i, j);
            }

            Swap(arr, leftIndex, j);
            return j;
        }
        
        private static bool IsLess(IComparable firstElement, IComparable secondElement)
        {
            return firstElement.CompareTo(secondElement) < 0;
        }

        private static void Swap<T>(T[] arr, int left, int right)
        {
            T temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
        }
    }
}
