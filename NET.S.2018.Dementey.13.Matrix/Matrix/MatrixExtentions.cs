namespace Matrix
{
    using System;

    /// <summary>
    /// The extension allows you to fold the matrix.
    /// </summary>
    public static class MatrixExtentions
    {
        /// <summary>
        /// Addition of matrices.
        /// </summary>
        /// <typeparam name="T">The data type.</typeparam>
        /// <param name="matrix">The first matrix. </param>
        /// <param name="otherMatrix">The second matrix.</param>
        /// <returns>
        /// Resulting matrix.
        /// </returns>
        public static AbstractSquareMatrix<T> Add<T>(this AbstractSquareMatrix<T> matrix, AbstractSquareMatrix<T> otherMatrix)
        {
            if (ReferenceEquals(matrix, null))
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            if (ReferenceEquals(otherMatrix, null))
            {
                throw new ArgumentNullException(nameof(otherMatrix));
            }

            if (matrix.Order != otherMatrix.Order)
            {
                throw new ArgumentException($"{nameof(matrix)} and {nameof(otherMatrix)} should be of equal order.");
            }

            var resultMatrix = new SquareMatrix<T>(matrix.Order);

            for (int row = 0; row < matrix.Order; row++)
            {
                for (int column = 0; column < matrix.Order; column++)
                {
                    resultMatrix[row, column] = (dynamic)matrix[row, column] + (dynamic)otherMatrix[row, column];
                }
            }

            return resultMatrix;
        }
    }
}
