using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    /// <summary>
    /// A class describing a node of a binary tree.
    /// </summary>
    /// <typeparam name="T">The type of stored data.</typeparam>
    internal class Node<T>
    {
        internal Node<T> Left;

        internal Node<T> Right;

        internal T Item;

        internal Node(Node<T> left, Node<T> right, T item)
        {
            Left = left;
            Right = right;
            Item = item;
        }

        internal Node(T item)
        {
            Left = null;
            Right = null;
            Item = item;
        }
    }
}
