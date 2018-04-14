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

        public BinarySearchTree() : this(GetDefaultComparer<T>())
        {
        }

        public BinarySearchTree(Comparison<T> comparer)
        {
            Comparer = comparer;
        }

        public BinarySearchTree(IEnumerable<T> collection) : this(GetDefaultComparer<T>())
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public BinarySearchTree(IEnumerable<T> collection, Comparison<T> comparer)
        {
            Comparer = comparer;

            foreach (var item in collection)
            {
                Add(item);
            }
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
            return Contains(_root, item, out node, out parent);
        }

        /// <summary>
        /// Get preorder enumerator.
        /// </summary>
        /// <returns>
        /// Preorder enumerator.
        /// </returns>
        public IEnumerable<T> GetPreorderEnumerator()
        {
            return GetPreorderEnumerator(_root);
        }

        /// <summary>
        /// Get inorder enumerator.
        /// </summary>
        /// <returns>
        /// Inorder enumerator.
        /// </returns>
        public IEnumerable<T> GetInorderEnumerator()
        {
            return GetInorderEnumerator(_root);
        }

        /// <summary>
        /// Get postorder enumerator.
        /// </summary>
        /// <returns>
        /// Postorder enumerator.
        /// </returns>
        public IEnumerable<T> GetPostorderEnumerator()
        {
            return GetPostorderEnumerator(_root);
        }

        private static Comparison<T> GetDefaultComparer<T>()
        {
            if (typeof(T) == typeof(string))
            {
                var comparer = StringComparer.CurrentCulture as IComparer<T>;
                return comparer.Compare;
            }

            return Comparer<T>.Default.Compare;
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

        private bool Contains(Node<T> root, T item, out Node<T> node, out Node<T> parent)
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
            if (ReferenceEquals(root, null))
            {
                yield break;
            }

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
                foreach (var item in GetPreorderEnumerator(root.Right))
                {
                    yield return item;
                }
            }
        }

        private IEnumerable<T> GetInorderEnumerator(Node<T> root)
        {
            if (ReferenceEquals(root, null))
            {
                yield break;
            }

            if (!ReferenceEquals(root.Left, null))
            {
                foreach (var item in GetInorderEnumerator(root.Left))
                {
                    yield return item;
                }
            }

            yield return root.Item;

            if (!ReferenceEquals(root.Right, null))
            {
                foreach (var item in GetInorderEnumerator(root.Right))
                {
                    yield return item;
                }
            }
        }

        private IEnumerable<T> GetPostorderEnumerator(Node<T> root)
        {
            if (ReferenceEquals(root, null))
            {
                yield break;
            }

            if (!ReferenceEquals(root.Left, null))
            {
                foreach (var item in GetPostorderEnumerator(root.Left))
                {
                    yield return item;
                }
            }

            if (!ReferenceEquals(root.Right, null))
            {
                foreach (var item in GetPostorderEnumerator(root.Right))
                {
                    yield return item;
                }
            }

            yield return root.Item;
        }

        private bool Remove(ref Node<T> root, T item)
        {
            Node<T> node;
            Node<T> parent;
            if (!Contains(_root, item, out node, out parent))
            {
                return false;
            }

            var items = Enumerable.Concat(GetPostorderEnumerator(node.Left).ToArray(), GetPostorderEnumerator(node.Right).ToArray());

            if (ReferenceEquals(parent, node))
            {
                _root = null;
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
