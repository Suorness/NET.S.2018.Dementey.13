namespace Matrix
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Abstract class representing a square matrix.
    /// </summary>
    /// <typeparam name="T">The data type.</typeparam>
    public abstract class AbstractSquareMatrix<T> : IEnumerable<T>
    {
        protected AbstractSquareMatrix()
        {
        }

        protected AbstractSquareMatrix(int order)
        {
            Order = order;
        }

        /// <summary>
        /// A notification event about changing the matrix fields.
        /// </summary>
        public event EventHandler<ElementChangesEventArgs<T>> ElementChanged = delegate { };

        /// <summary>
        /// The dimension of the matrix.
        /// </summary>
        public int Order { get; protected set; }

        /// <summary>
        /// Provides access to the matrix fields.
        /// </summary>
        /// <param name="row"> Row number.</param>
        /// <param name="column">Column number.</param>
        /// <returns>
        /// A field with given indices.
        /// </returns>
        public T this[int row, int column]
        {
            get
            {
                VerifyPosition(row, column);
                return GetValue(row, column);
            }

            set
            {
                VerifyPosition(row, column);
                var eventArgs = new ElementChangesEventArgs<T>(GetValue(row, column), value, row, column);
                SetValue(value, row, column);
                ElementChanged?.Invoke(this, eventArgs);
            }
        }

        /// <summary>
        /// Provides access to enumeration of data.
        /// </summary>
        /// <returns>
        /// Enumeration of data.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int row = 0; row < Order; row++)
            {
                for (int column = 0; column < Order; column++)
                {
                    yield return GetValue(row, column);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        protected bool IsSquareMatrix(T[,] matrix)
        {
            return matrix.GetLength(0) == matrix.GetLength(1);
        }

        protected abstract void SetValue(T value, int row, int column);

        protected abstract T GetValue(int row, int column);

        private void VerifyPosition(int row, int column)
        {
            if ((row < 0) || (column < 0))
            {
                throw new ArgumentOutOfRangeException($"{nameof(row)} and {nameof(column)} must be greater than or equal to zero.");
            }

            if ((row > Order) || (column > Order))
            {
                throw new ArgumentOutOfRangeException($"{nameof(row)} and {nameof(column)} should not be more than {nameof(Order)}.");
            }
        }
    }
}