using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
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
