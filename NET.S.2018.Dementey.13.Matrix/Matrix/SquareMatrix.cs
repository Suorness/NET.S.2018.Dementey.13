namespace Matrix
{
    using System;

    /// <summary>
    /// Сlass representing a square matrix.
    /// </summary>
    /// <typeparam name="T">The data type.</typeparam>
    public class SquareMatrix<T> : AbstractSquareMatrix<T>
    {
        #region private field
        private T[,] _elements;
        #endregion private field

        /// <summary>
        /// Creates an instance of the square matrix.
        /// </summary>
        /// <param name="order">The order of the matrix.</param>
        public SquareMatrix(int order) : base(order)
        {
            this._elements = new T[this.Order, this.Order];
        }

        /// <summary>
        /// Creates an instance of the square matrix.
        /// </summary>
        /// <param name="matrix">Elements of the matrix.</param>
        public SquareMatrix(T[,] matrix)
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

            this._elements = new T[this.Order, this.Order];

            Array.Copy(matrix, this._elements, this.Order * this.Order);
            /////Check this
        }

        protected override T GetValue(int row, int column)
        {
            return this._elements[row, column];
        }

        protected override void SetValue(T value, int row, int column)
        {
            this._elements[row, column] = value;
        }
    }
}
