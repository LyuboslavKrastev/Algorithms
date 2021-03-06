﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Words
{
    public class Program
    {
        private static char[] elements;
        private static int count;

        public static void Permute(int index)
        {
            if (index >= elements.Length)
            {
                for (int i = 0; i < elements.Length - 1; i++)
                {
                    if (elements[i] == elements[i + 1])
                    {
                        return;
                    }
                }
                count++;
            }
            else
            {
                HashSet<int> swapped = new HashSet<int>();
                for (int i = index; i < elements.Length; i++)
                {
                    if (!swapped.Contains(elements[i]))
                    {
                        Swap(index, i);
                        Permute(index + 1);
                        Swap(index, i);
                        swapped.Add(elements[i]);
                    }
                }
            }         
        }

        private static void Swap(int first, int second)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }

        public static void Main(string[] args)
        {
            elements = Console.ReadLine().ToCharArray();

            bool isComposedOfFullyUniqueCharacters = elements.Distinct().Count() == elements.Length;

            if (isComposedOfFullyUniqueCharacters)
            {
                count = 1;

                for (int i = 1; i <= elements.Length; i++)
                {
                    count *= i;
                }
            }
            else
            {
                Permute(0);

            }
            Console.WriteLine(count);
        }
    }

}
