using System;
using System.Linq;

namespace P01_MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Quicksort(input, 0, input.Length - 1);

            //       Console.WriteLine(string.Join(" ", input));
            Console.WriteLine(string.Join(" ", input));
        }

        public static void Quicksort(int[] elements, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int leftIndex = start;
            int rightIndex = end;
            int pivot = elements[(start + end) / 2];

            while (leftIndex <= rightIndex)
            {
                while (elements[leftIndex].CompareTo(pivot) < 0)
                {
                    leftIndex++;
                }

                while (elements[rightIndex].CompareTo(pivot) > 0)
                {
                    rightIndex--;
                }

                if (leftIndex <= rightIndex)
                {
                    if (leftIndex < rightIndex)
                    {
                        Swap(elements, leftIndex, rightIndex);
                    }

                    leftIndex++;
                    rightIndex--;
                }
            }

            if (start < rightIndex)
            {
                Quicksort(elements, start, rightIndex);
            }

            if (leftIndex < end)
            {
                Quicksort(elements, leftIndex, end);
            }
        }

        private static void Swap(int[] elements, int leftIndex, int rightIndex)
        {
            int tmp = elements[leftIndex];
            elements[leftIndex] = elements[rightIndex];
            elements[rightIndex] = tmp;
        }
    }


}