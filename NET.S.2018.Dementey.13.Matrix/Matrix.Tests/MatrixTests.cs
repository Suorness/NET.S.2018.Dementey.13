namespace Matrix.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class MatrixTests
    {

        int[,] arrayData = new[,]
        {
            { 1, 2, 3, 4, 5},
            { 4, 3, 2, 3, 5},
            { 4, 3, 2, 3, 5},
            { 4, 3, 2, 3, 5},
            { 4, 3, 2, 3, 5}
        };

        int[,] arrayData2 = new[,]
        {
            { 1, 2, 3, 4, 5},
            { 4, 3, 2, 3, 5},
            { 4, 3, 2, 3, 5},
            { 4, 3, 2, 3, 5}
        };

        [TestCase(new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 0, 5, 1 })]
        [TestCase(new[] { 2, 8, 16, 23, 42 })]
        public void DiagonalAddTests(int[] array)
        {
            var matrix = new DiagonalMatrix<int>(array);

            for (int i = 0; i < matrix.Order; i++)
            {
                for (int j = 0; j < matrix.Order; j++)
                {
                    if (i != j)
                    {
                        Assert.AreEqual(matrix[i, j], default(int));
                    }
                    else
                    {
                        Assert.AreEqual(matrix[i, j], array[i]);
                    }
                }
            }
        }

        [Test]
        public void SquareAddTests()
        {
            var array = arrayData;
            var matrix = new SquareMatrix<int>(array);
            for (int i = 0; i < matrix.Order; i++)
            {
                for (int j = 0; j < matrix.Order; j++)
                {
                    Assert.AreEqual(matrix[i, j], array[i, j]);
                }
            }
        }

        [Test]
        public void SquareAddTestThrowsArgumentException()
        {
            var array = arrayData2;
            Assert.Throws<ArgumentException>(() => new SquareMatrix<int>(array));
        }

        [Test]
        public void SymmetricAddTestThrowsArgumentException()
        {
            var array = arrayData2;
            Assert.Throws<ArgumentException>(() => new SymmetricMatrix<int>(array));
        }

        [Test]
        public void SymmetricAddTest()
        {
            var array = arrayData;
            var matrix = new SymmetricMatrix<int>(array);

            for (int i = 0; i < matrix.Order; i++)
            {
                for (int j = 0; j < matrix.Order; j++)
                {
                    Assert.AreEqual(matrix[i, j], matrix[j, i]);
                }
            }
        }

        [Test]
        public void AddExtentionTest()
        {
            var array = arrayData;
            var matrix = new SquareMatrix<int>(array);
            var otherMatrix = new SquareMatrix<int>(array);

            var resultMatrix = matrix.Add(otherMatrix);

            for (int i = 0; i < matrix.Order; i++)
            {
                for (int j = 0; j < matrix.Order; j++)
                {
                    Assert.AreEqual(resultMatrix[i,j],matrix[i,j]+ otherMatrix[i,j]);
                }
            }
        }
    }
}