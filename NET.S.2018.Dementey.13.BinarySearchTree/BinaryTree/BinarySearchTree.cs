namespace BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class representing the binary search tree.
    /// </summary>
    /// <typeparam name="T">Element of the node.</typeparam>
    public class BinarySearchTree<T>
    {
        #region private field
        private Node<T> _root;
        private Comparison<T> _сomparer;

        #endregion private field

        public BinarySearchTree(Comparison<T> comparer)
        {
            Comparer = comparer;
        }

        /// <summary>
        /// The comparison comparator
        /// </summary>
        public Comparison<T> Comparer
        {
            get => _сomparer;
            private set
            {
                if (ReferenceEquals(value, null))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _сomparer = value;
            }
        }

        /// <summary>
        /// Adds an element to the tree.
        /// </summary>
        /// <param name="item">
        /// The item to add.
        /// </param>
        public void Add(T item)
        {
            Add(ref _root, item);
        }

        /// <summary>
        /// Removing an item from a tree.
        /// </summary>
        /// <param name="item">
        /// The item to delete.
        /// </param>
        /// <returns>
        /// True if successful, otherwise false
        /// </returns>
        public bool Remove(T item)
        {
            return Remove(ref _root, item);
        }

        /// <summary>
        /// Check for the presence of an element in the tree.
        /// </summary>
        /// <param name="item">The element to search for.</param>
        /// <returns>
        /// True if successful, otherwise false
        /// </returns>
        public bool Constains(T item)
        {
            Node<T> node;
            Node<T> parent;
            return Contains(ref _root, item, out node, out parent);
        }

        private void Add(ref Node<T> root, T item)
        {
            if (ReferenceEquals(root, null))
            {
                root = new Node<T>(item);
                return;
            }

            var resultCompare = Comparer(item, root.Item);

            if (resultCompare > 0)
            {
                Add(ref root.Right, item);
                return;
            }

            if (resultCompare < 0)
            {
                Add(ref root.Left, item);
            }
        }

        private bool Contains(ref Node<T> root, T item, out Node<T> node, out Node<T> parent)
        {
            parent = root;

            while (true)
            {
                if (ReferenceEquals(root, null))
                {
                    node = null;
                    return false;
                }

                var resultCompare = Comparer(item, root.Item);

                if (resultCompare > 0)
                {
                    parent = root;
                    root = root.Right;
                }

                if (resultCompare < 0)
                {
                    parent = root;
                    root = root.Left;
                }

                if (resultCompare == 0)
                {
                    node = root;
                    return true;
                }
            }
        }

        private IEnumerable<T> GetPreorderEnumerator(Node<T> root)
        {
            while (true)
            {
                yield return root.Item;

                if (!ReferenceEquals(root.Left, null))
                {
                    foreach (var item in GetPreorderEnumerator(root.Left))
                    {
                        yield return item;
                    }
                }

                if (!ReferenceEquals(root.Right, null))
                {
                    root = root.Right;
                    continue;
                }

                break;
            }
        }

        private bool Remove(ref Node<T> root, T item)
        {
            Node<T> node;
            Node<T> parent;
            if (!Contains(ref root, item, out node, out parent))
            {
                return false;
            }

            var items = GetPreorderEnumerator(node).ToList().Skip(1);

            if (ReferenceEquals(parent, node))
            {
                parent = null;
            }
            else
            {
                if (ReferenceEquals(parent.Left, node))
                {
                    parent.Left = null;
                }
                else
                {
                    parent.Right = null;
                }
            }

            foreach (var itemOnCollection in items)
            {
                Add(ref _root, itemOnCollection);
            }

            return true;
        }
    }
}
