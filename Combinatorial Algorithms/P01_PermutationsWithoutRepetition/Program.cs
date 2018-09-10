using System;
using System.Linq;

namespace P01_PermutationsWithoutRepetition
{
    public class Program
    {
        static char[] elements;

        public static void Main(string[] args)
        {
            elements = Console.ReadLine().Split().Select(char.Parse).ToArray();

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
                for (int i = index + 1; i < elements.Length; i++)
                {
                    Swap(index, i);
                    Permute(index + 1);
                    Swap(index, i);
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
