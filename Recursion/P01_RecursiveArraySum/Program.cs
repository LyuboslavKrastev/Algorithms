using System;
using System.Linq;

namespace P01_RecursiveArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();

            int result = ArraySum(array, 0);

            Console.WriteLine(result);
        }

        static int ArraySum(int[] array, int index)
        {
            if (index == array.Length)
            {
                return 0; 
            }

            return array[index] + ArraySum(array, index + 1);
        }
    }
}
