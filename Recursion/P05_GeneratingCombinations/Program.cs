using System;
using System.Linq;

namespace P05_GeneratingCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] set = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int vectorLength = int.Parse(Console.ReadLine());

            GenerateCombs(set, new int[vectorLength], 0, 0);
        }

        static void GenerateCombs(int[] set, int[] vector, int index, int border)
        {
            if (index >= vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
            }
            else
            {
                for (int i = border; i < set.Length; i++)
                {
                    vector[index] = set[i];
                    int nextIndex = index + 1;
                    int nextBorder = i + 1;
                    GenerateCombs(set, vector, nextIndex, nextBorder);
                }
            }
        }
    }
}
