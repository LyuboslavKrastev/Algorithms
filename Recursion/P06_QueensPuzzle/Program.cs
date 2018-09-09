﻿using System;
using System.Collections.Generic;

namespace P06_QueensPuzzle
{
    class Program
    {
        const int Size = 8;
        static bool[,] chessBoard = new bool[8, 8];
        static int solutionsFound = 0;

        static HashSet<int> attackedCols = new HashSet<int>();
        static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        static HashSet<int> attackedRightDiagonals = new HashSet<int>();

        static void Main(string[] args)
        {
            PlaceQueens(0);
        }

        static void PlaceQueens(int row)
        {
            if (row == Size)
            {
                PrintSolution();
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAllAttackedPositions(row, col);
                        PlaceQueens(row + 1);
                        UnmarkAllAttackedPositions(row, col);
                    }
                }
            }
        }

        static bool CanPlaceQueen(int row, int col)
        {
            int leftDiagonal = col - row;
            int rightDiagonal = row + col;

            bool positionUnavailable = attackedCols.Contains(col) 
                || attackedLeftDiagonals.Contains(leftDiagonal)
                || attackedRightDiagonals.Contains(rightDiagonal);

            return !positionUnavailable;
        }

        static void MarkAllAttackedPositions(int row, int col)
        {
            int leftDiagonal = col - row;
            int rightDiagonal = row + col;

            attackedCols.Add(col);
            attackedLeftDiagonals.Add(leftDiagonal);
            attackedRightDiagonals.Add(rightDiagonal);

            chessBoard[row, col] = true;
        }

        static void UnmarkAllAttackedPositions(int row, int col)
        {
            int leftDiagonal = col - row;
            int rightDiagonal = row + col;

            attackedCols.Remove(col);
            attackedLeftDiagonals.Remove(leftDiagonal);
            attackedRightDiagonals.Remove(rightDiagonal);

            chessBoard[row, col] = false;
        }

        static void PrintSolution()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if (chessBoard[row, col] == true)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            solutionsFound++;
        }
    }
}
