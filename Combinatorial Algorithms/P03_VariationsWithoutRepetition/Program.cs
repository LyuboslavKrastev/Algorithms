using System;
using System.Linq;

namespace P03_VariationsWithoutRepetition
{
    class Program
    {
        static string[] elements;
        static string[] variations;
        static bool[] used;
        static int k;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split().ToArray();
            used = new bool[elements.Length];
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
                    if (!used[i])
                    {
                        used[i] = true;
                        variations[index] = elements[i];
                        Variations(index + 1);
                        used[i] = false;
                    }
                }
            }
        }
    }
}
