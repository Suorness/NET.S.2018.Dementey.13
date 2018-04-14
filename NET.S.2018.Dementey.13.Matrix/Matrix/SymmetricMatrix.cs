namespace Matrix
{
    using System;

    /// <summary>
    /// Сlass representing a symmetric matrix.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SymmetricMatrix<T> : AbstractSquareMatrix<T>
    {
        #region private field
        private T[,] _elements;
        #endregion private field

        /// <summary>
        /// Creates an instance of the symmetric matrix.
        /// </summary>
        /// <param name="order">The order of the matrix.</param>
        public SymmetricMatrix(int order) : base(order)
        {
            this._elements = new T[Order, Order];
        }

        /// <summary>
        /// Creates an instance of the symmetric matrix.
        /// </summary>
        /// <param name="matrix">Elements of the matrix.</param>
        public SymmetricMatrix(T[,] matrix)
        {
            if (object.ReferenceEquals(matrix, null))
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            if (!this.IsSquareMatrix(matrix))
            {
                throw new ArgumentException($"{nameof(matrix)} is not a symmetric matrix.");
            }

            this.Order = matrix.GetLength(0);
            this._elements = new T[Order, Order];

            for (int row = 0; row < this.Order; row++)
            {
                for (int column = 0; column < this.Order; column++)
                {
                    this.SetValue(matrix[row, column], row, column);
                }
            }
        }

        protected override T GetValue(int row, int column)
        {
            return this._elements[row, column];
        }

        protected override void SetValue(T value, int row, int column)
        {
            this._elements[row, column] = value;
            this._elements[column, row] = value;
        }
    }
}
