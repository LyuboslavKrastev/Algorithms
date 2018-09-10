using System;
using System.Linq;

namespace P05_CombinationsWithRepetitions
{
    class Program
    {
        static string[] elements;
        static string[] combinations;
        static int k;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split().ToArray();
            k = int.Parse(Console.ReadLine());
            combinations = new string[k];
            Combinations(0, 0);
        }


        static void Combinations(int index, int start)
        {
            if (index >= k)
            {
                Console.WriteLine(string.Join(" ", combinations));
            }
            else
            {
                for (int i = start; i < elements.Length; i++)
                {
                    combinations[index] = elements[i];
                    Combinations(index + 1, i);
                }
            }
        }
    }
}
