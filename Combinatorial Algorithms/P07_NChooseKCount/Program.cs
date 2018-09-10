using System;

namespace P07_NChooseKCount
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = int.Parse(Console.ReadLine());
            double k = int.Parse(Console.ReadLine());

            double result = Factorial(n) / (Factorial(k) * Factorial(n - k));

            Console.WriteLine(result);
        }

        static double Factorial(double number)
        {
            double result = 1;
            while (number != 1)
            {
                result *= number;
                number--;
            }
            return result;
        }
    }
}
