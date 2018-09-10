using System;
using System.Linq;

namespace P04_VariationsWithRepetition
{
    class Program
    {
        static string[] elements;
        static string[] variations;
        static int k;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split().ToArray();
            k = int.Parse(Console.ReadLine());
            variations = new string[k];
            Variations(0);
        }

        static void Variations(int index)
        {
            if (index >= k)
            {
                Console.WriteLine(string.Join(" ", variations));
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    variations[index] = elements[i];
                    Variations(index + 1);
                }
            }
        }

    }
}
