using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_PermutationsWithRepetition
{
    class Program
    {
        static string[] elements;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split().ToArray();

            Permute(0);
        }

        static void Permute(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
            }
            else
            {
                Permute(index + 1);
                var swapped = new HashSet<string>();
                swapped.Add(elements[index]);
                for (int i = index + 1; i < elements.Length; i++)
                {
                    if (!swapped.Contains(elements[i]))
                    {
                        swapped.Add(elements[i]);
                        Swap(index, i);
                        Permute(index + 1);
                        Swap(index, i);
                    }
                }
            }
        }

        static void Swap(int firstIndex, int secondIndex)
        {
            var temp = elements[firstIndex];
            elements[firstIndex] = elements[secondIndex];
            elements[secondIndex] = temp;
        }
    }
}
