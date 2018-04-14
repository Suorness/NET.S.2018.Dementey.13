namespace CustomQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// The class that implements the queue.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the item in the queue.
    /// </typeparam>
    public class Queue<T> : IEnumerable<T>
    {
        #region private fields
        private const int DefaultCapacity = 10;
        private const int DefaultExpansion = 2;
        private T[] _collection;
        private int _head;
        private int _tail;
        private int _count;
        private int _version;
        #endregion private fields

        /// <summary>
        /// The constructor of the class.
        /// </summary>
        /// <param name="capacity">
        /// The initial number of elements.
        /// </param>
        public Queue(int capacity = DefaultCapacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(capacity)} must be greater than or equal to zero");
            }

            _collection = new T[DefaultCapacity];
        }

        /// <summary>
        /// The constructor of the class.
        /// </summary>
        /// <param name="capacity">
        /// The initial number of elements.
        /// </param>
        /// <param name="collection">
        /// start collection in queue 
        /// </param>
        public Queue(IEnumerable<T> collection, int capacity = DefaultCapacity) : this(capacity)
        {
            foreach (var item in collection)
            {
                Enqueue(item);
            }
        }

        /// <summary>
        /// Amount of elements.
        /// </summary>
        public int Count
        {
            get => _count;
        }

        /// <summary>
        /// Place in the queue.
        /// </summary>
        /// <param name="item">
        /// An element that is placed in the queue.
        /// </param>
        public void Enqueue(T item)
        {
            if (ReferenceEquals(item, null))
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (_count == _collection.Length)
            {
                Array.Resize(ref _collection, _collection.Length * DefaultExpansion);
            }

            _collection[_tail++] = item;
            _count++;
            _version++;
        }

        /// <summary>
        /// Extract an item from the queue.
        /// </summary>
        /// <returns>
        /// Element from the queue.
        /// </returns>
        public T Dequeue()
        {
            if (_collection.Length == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            var result = _collection[_head];
            _collection[_head++] = default(T);
            _count--;
            _version++;

            return result;
        }

        /// <summary>
        /// Clears the queue.
        /// </summary>
        public void Clear()
        {
            _head = 0;
            _tail = 0;
            _count = 0;
            _version++;
            Array.Clear(_collection, 0, _collection.Length);
        }

        private T GetElementByIndex(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return _collection[index];
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        #region Enumerator
        public struct Enumerator : IEnumerator<T>, IEnumerator
        {
            #region private fields
            private readonly Queue<T> _queue;
            private readonly int _enumeratorVersion;
            private int _currentIndex;
            private T _current;
            private bool isDispose;

            #endregion private fields

            internal Enumerator(Queue<T> queue)
            {
                if (ReferenceEquals(queue, null))
                {
                    throw new ArgumentNullException(nameof(queue));
                }

                isDispose = false;
                _current = default(T);
                _currentIndex = -1;
                _queue = queue;
                _enumeratorVersion = queue._version;
            }

            /// <summary>
            /// The current item.
            /// </summary>
            public T Current
            {
                get
                {
                    if (isDispose)
                    {
                        throw new InvalidOperationException("Enumerator is dispose.");
                    }

                    if (_enumeratorVersion != _queue._version)
                    {
                        throw new InvalidOperationException("Queue was changed");
                    }

                    if (_currentIndex == -1)
                    {
                        throw new InvalidOperationException("The current item is not installed.");
                    }

                    if (_currentIndex == _queue.Count)
                    {
                        throw new InvalidOperationException();
                    }

                    return _current;
                }
            }

            /// <summary>
            /// The current item.
            /// </summary>
            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            /// <summary>
            /// Reset the position of the current item.
            /// </summary>
            public void Reset()
            {
                if (isDispose)
                {
                    throw new InvalidOperationException("Enumerator is dispose.");
                }

                if (_enumeratorVersion != _queue._version)
                {
                    throw new InvalidOperationException("Queue was changed");
                }

                _currentIndex = -1;
            }

            /// <summary>
            /// Go to the next item.
            /// </summary>
            /// <returns></returns>
            public bool MoveNext()
            {
                if (isDispose)
                {
                    throw new InvalidOperationException("Enumerator is dispose.");
                }

                if (_enumeratorVersion != _queue._version)
                {
                    throw new InvalidOperationException("Queue was changed");
                }

                if (++_currentIndex >= _queue.Count)
                {
                    return false;
                }

                _current = _queue.GetElementByIndex(_currentIndex);
                return true;
            }

            /// <summary>
            /// Dispose enumerator.
            /// </summary>
            public void Dispose()
            {
                isDispose = true;
            }
        }
        #endregion Enumerator
    }
}
