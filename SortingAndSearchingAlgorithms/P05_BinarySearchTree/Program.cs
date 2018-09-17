using System;
using System.Collections.Generic;

namespace P05_BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.Insert(5);
            bst.Insert(4);
            bst.Insert(3);
            bst.Insert(7);
            bst.Insert(6);

            var list = new List<int>();


            BinarySearchTree<int> searchResult = bst.Search(7);

            var searchList = new List<int>();

            searchResult.Insert(9);

            bst.EachInOrder(list.Add);
            searchResult.EachInOrder(searchList.Add);

            Console.WriteLine(bst.Contains(9));

            Console.WriteLine(string.Join(" ", list));

            Console.WriteLine(string.Join(" ", searchList));

            Console.WriteLine(string.Join(" ", bst.Range(4, 6)));
        }
    }
}
