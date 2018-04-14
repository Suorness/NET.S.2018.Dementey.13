namespace Matrix
{
    using System;

    /// <summary>
    /// Describes the diagonal matrix.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DiagonalMatrix<T> : AbstractSquareMatrix<T>
    {
        #region private field
        private T[] _diagonalElements;
        #endregion private field

        /// <summary>
        /// Creates an instance of the diagonal matrix.
        /// </summary>
        /// <param name="order">The order of the matrix.</param>
        public DiagonalMatrix(int order) : base(order)
        {
            this._diagonalElements = new T[this.Order];
        }

        /// <summary>
        /// Creates an instance of the diagonal matrix.
        /// </summary>
        /// <param name="diagonalElements">The value of the diagonal elements.</param>
        public DiagonalMatrix(T[] diagonalElements)
        {
            if (object.ReferenceEquals(diagonalElements, null))
            {
                throw new ArgumentNullException(nameof(diagonalElements));
            }

            this.Order = diagonalElements.Length;
            this._diagonalElements = new T[this.Order];
            Array.Copy(diagonalElements, this._diagonalElements, diagonalElements.Length);
        }

        protected override T GetValue(int row, int column)
        {
            if (row == column)
            {
                return this._diagonalElements[column];
            }
            else
            {
                return default(T);
            }
        }

        protected override void SetValue(T value, int row, int column)
        {
            if (row == column)
            {
                this._diagonalElements[column] = value;
            }
        }
    }
}
