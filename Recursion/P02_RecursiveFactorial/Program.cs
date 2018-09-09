using System;

namespace P02_RecursiveFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            long result = Factorioal(int.Parse(Console.ReadLine()));
            Console.WriteLine(result);
        }

        static long Factorioal(int number)
        {
            if (number == 0)
            {
                return 1;
            }

            return number * Factorioal(number - 1);
        }
    }
}
