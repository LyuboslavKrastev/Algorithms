using System;

namespace P03_RecursiveDrawing
{
    class Program
    {
        static void Main(string[] args)
        {
            Draw(int.Parse(Console.ReadLine()));
        }

        static void Draw(int number)
        {
            if (number == 0)
            {
                return;
            }

            Console.WriteLine(new string('*', number));

            Draw(number - 1);

            Console.WriteLine(new string('#', number));
        }
    }
}
