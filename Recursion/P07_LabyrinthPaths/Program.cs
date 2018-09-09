using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_LabyrinthPaths
{
    class Program
    {
        static char[,] labyrinth;
        static List<char> path = new List<char>();

        static void Main(string[] args)
        {

            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            labyrinth = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    labyrinth[row, col] = line[col];
                }
            }

            FindPaths(0, 0, 'S');
        }

        private static void FindPaths(int row, int col, char direction)
        {
            if (!IsInBounds(row, col))
            {
                return;
            }

            path.Add(direction);

            if (IsExit(row, col))
            {
                PrintPath();
            }
            else if (!IsVisited(row, col) && IsFree(row, col))
            {
                Mark(row, col);
                FindPaths(row, col + 1, 'R');
                FindPaths(row + 1, col, 'D');
                FindPaths(row, col - 1, 'L');
                FindPaths(row - 1, col, 'U');
                Unmark(row, col);
            }

            path.RemoveAt(path.Count - 1);
        }

        private static bool IsVisited(int row, int col)
        {
            return labyrinth[row, col] == 'v';
        }

        private static bool IsFree(int row, int col)
        {
            return labyrinth[row, col] != '*';
        }

        private static void Mark(int row, int col)
        {
            labyrinth[row, col] = 'v';
        }


        private static void Unmark(int row, int col)
        {
            labyrinth[row, col] = '-';
        }

        private static bool IsInBounds(int row, int col)
        {
            bool rowIsInBounds = row >= 0 && row < labyrinth.GetLength(0);
            bool colIsInBounds = col >= 0 && col < labyrinth.GetLength(1);

            return rowIsInBounds && colIsInBounds;
        }


        private static bool IsExit(int row, int col)
        {
            return labyrinth[row, col] == 'e';
        }

        private static void PrintPath()
        {
            Console.WriteLine(String.Join("", path.Skip(1)));
        }
    }
}
