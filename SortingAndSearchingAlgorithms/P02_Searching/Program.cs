using System;
using System.Linq;

namespace P02_Searching
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            //input = input.OrderBy(n =>n).ToArray();

            //int[] input = new [] {5, 4, 3, 2, 1};
            int item = int.Parse(Console.ReadLine());
            //int item = 2;            

            int index = IntArrayBinarySearch(input, item);

            Console.WriteLine(index);
        }

        public static int IntArrayLinearSearch(int[] arr, int element)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }

        public static int IntArrayBinarySearch(int[] arr, int element)
        {
            int min = 0;
            int max = arr.Length - 1;

            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (element > arr[mid])
                {
                    min = mid + 1;
                }

                else
                {
                    max = mid - 1;
                }

                if (arr[mid] == element)
                {
                    return mid;
                }
            }
            return -1;
        }
    }
}
