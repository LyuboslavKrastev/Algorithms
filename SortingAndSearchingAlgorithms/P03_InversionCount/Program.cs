using System;
using System.Linq;

namespace P03_InversionCount
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] temp = new int[arr.Length];
            int inversionCount = mergeSort(arr, temp, 0, arr.Length - 1);
            Console.WriteLine(inversionCount);
        }

        static int mergeSort(int[] arr, int[] temp, int left, int right)
        {
            int inversionCount = 0;

            if (right > left)
            {
                /* Divide the array into two parts and call _mergeSortAndCountInv() 
                   for each of the parts */
                int mid = (right + left) / 2;

                /* Inversion count will be sum of inversions in left-part, right-part 
                  and number of inversions in merging */
                inversionCount = mergeSort(arr, temp, left, mid);
                inversionCount += mergeSort(arr, temp, mid + 1, right);

                /*Merge the two parts*/
                inversionCount += merge(arr, temp, left, mid + 1, right);
            }

            return inversionCount;
        }

        static int merge(int[] arr, int[] temp, int left, int mid, int right)
        {
            int inversionCount = 0;

            int i = left; /* index for the left subarray */
            int j = mid;  /* index for the right subarray */
            int k = left; /* index for the resultant merged subarray */

            while ((i <= mid - 1) && (j <= right))
            {
                if (arr[i] <= arr[j])
                {
                    temp[k++] = arr[i++];
                }
                else
                {
                    temp[k++] = arr[j++];
                    inversionCount += (mid - i); /*if a[i] is greater than a[j], then there are (mid – i) inversions. */
                }
            }

            /* Copy the remaining elements of left subarray 
             (if there are any) to temp*/
            while (i <= mid - 1)
            {
                temp[k++] = arr[i++];
            }

            /* Copy the remaining elements of right subarray 
             (if there are any) to temp*/
            while (j <= right)
            {
                temp[k++] = arr[j++];
            }

            /*Copy back the merged elements to original array*/
            for (i = left; i <= right; i++)
            {
                arr[i] = temp[i];
            }

            return inversionCount;
        }
    }
}