namespace BinaryTree.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BinaryTree.Tests.Comparers;
    using NUnit.Framework;

    [TestFixture]
    public class BinarySearchTreeTests
    {
        #region int test-cases

        public static IEnumerable<TestCaseData> IntPreorderTestCaseData
        {
            get
            {
                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5 }).Returns(new int[] { 1, 2, 3, 4, 5 });
                yield return new TestCaseData(new int[] { 8, 4, 16, 2, 25 }).Returns(new int[] { 8, 4, 2, 16, 25 });
                yield return new TestCaseData(new int[] { 5, 4, 3, 2, 1 }).Returns(new int[] { 5, 4, 3, 2, 1 });
                yield return new TestCaseData(new int[] { 16, 29, 4, 3, 2, 1, 41 }).Returns(new int[] { 16, 4, 3, 2, 1, 29, 41 });
            }
        }

        public static IEnumerable<TestCaseData> IntInorderTestCaseData
        {
            get
            {
                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5 }).Returns(new int[] { 1, 2, 3, 4, 5, });
                yield return new TestCaseData(new int[] { 8, 4, 16, 2, 25 }).Returns(new int[] { 2, 4, 8, 16, 25 });
                yield return new TestCaseData(new int[] { 5, 4, 3, 2, 1 }).Returns(new int[] { 1, 2, 3, 4, 5 });
                yield return new TestCaseData(new int[] { 16, 29, 4, 2, 3, 1, 41 }).Returns(new int[] { 1, 2, 3, 4, 16, 29, 41 });
            }
        }

        public static IEnumerable<TestCaseData> IntPostorderTestCaseData
        {
            get
            {
                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5 }).Returns(new int[] { 5, 4, 3, 2, 1 });
                yield return new TestCaseData(new int[] { 8, 4, 16, 2, 25 }).Returns(new int[] { 2, 4, 25, 16, 8 });
                yield return new TestCaseData(new int[] { 5, 4, 3, 2, 1 }).Returns(new int[] { 1, 2, 3, 4, 5 });
                yield return new TestCaseData(new int[] { 16, 29, 4, 2, 3, 1, 41 }).Returns(new int[] { 1, 3, 2, 4, 41, 29, 16 });
            }
        }

        [TestCaseSource(nameof(IntPreorderTestCaseData))]
        public IEnumerable<int> AddIntTests(int[] collection)
        {
            var tree = new BinarySearchTree<int>();

            foreach (var item in collection)
            {
                tree.Add(item);
            }

            return tree.GetPreorderEnumerator().ToArray();
        }

        [TestCaseSource(nameof(IntPreorderTestCaseData))]
        public IEnumerable<int> AddIntWithCustomComparerTests(int[] collection)
        {
            var tree = new BinarySearchTree<int>(new IntComparer().Compare);

            foreach (var item in collection)
            {
                tree.Add(item);
            }

            return tree.GetPreorderEnumerator().ToArray();
        }

        [TestCaseSource(nameof(IntPostorderTestCaseData))]
        public IEnumerable<int> PostorderEnumerableIntTests(int[] collection)
        {
            var tree = new BinarySearchTree<int>(collection);

            return tree.GetPostorderEnumerator().ToArray();
        }

        [TestCaseSource(nameof(IntPreorderTestCaseData))]
        public IEnumerable<int> PreoerderEnumerableIntTests(int[] collection)
        {
            var tree = new BinarySearchTree<int>(collection);

            return tree.GetPreorderEnumerator().ToArray();
        }

        [TestCaseSource(nameof(IntInorderTestCaseData))]
        public IEnumerable<int> InorderEnumerableIntTests(int[] collection)
        {
            var tree = new BinarySearchTree<int>(collection);

            return tree.GetInorderEnumerator().ToArray();
        }

        [TestCase(16)]
        [TestCase(1)]
        [TestCase(41)]
        [TestCase(29)]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(3)]
        public void RemoveIntTest(int value)
        {
            int[] collection = new int[] { 16, 29, 4, 2, 3, 1, 41 };

            var tree = new BinarySearchTree<int>(collection);

            Assert.IsTrue(tree.Constains(value));
            var result = tree.Remove(value);
            Assert.IsTrue(result);
            Assert.IsFalse(tree.Constains(value));

            foreach (var item in collection)
            {
                if (item != value)
                {
                    Assert.IsTrue(tree.Constains(item));
                }
            }
        }
        #endregion int test-cases

        #region string test-cases

        [Test]
        public void AddStringTests()
        {
            var collection = new[] { "a", "b", "c", "d", "e" };
            var tree = new BinarySearchTree<string>();

            foreach (var item in collection)
            {
                tree.Add(item);
            }

            foreach (var item in collection)
            {
                Assert.IsTrue(tree.Constains(item));
            }
        }

        [TestCase("4444")]
        [TestCase("22")]
        [TestCase("1")]
        [TestCase("333")]
        [TestCase("666666")]
        [TestCase("7777777")]
        [TestCase("55555")]
        public void RemoveStringTests(string removeString)
        {
            var collection = new[] { "4444", "22", "1", "333", "666666", "7777777", "55555" };

            var tree = new BinarySearchTree<string>(collection, new Comparers.StringComparer().Compare);

            Assert.IsTrue(tree.Constains(removeString));
            var result = tree.Remove(removeString);
            Assert.IsTrue(result);
            Assert.IsFalse(tree.Constains(removeString));

            foreach (var item in collection)
            {
                if (item != removeString)
                {
                    Assert.IsTrue(tree.Constains(item));
                }
            }
        }
        #endregion string test-cases

        #region Custom class Book test-cases
        [Test]
        public void AddBookTests()
        {
            var collection = new Book[]
            {
                new Book(4, "4"),
                new Book(2, "2"),
                new Book(1, "1"),
                new Book(3, "3"),
                new Book(6, "6"),
                new Book(7, "7"),
                new Book(5, "5")
            };
            var tree = new BinarySearchTree<Book>();

            foreach (var item in collection)
            {
                tree.Add(item);
            }

            foreach (var item in collection)
            {
                Assert.IsTrue(tree.Constains(item));
            }
        }

        [TestCase(4)]
        [TestCase(2)]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(5)]
        public void RemoveBookTests(int removeYear)
        {
            var removeItem = new Book(removeYear, removeYear.ToString());
            var collection = new Book[]
            {
                new Book(4, "4"),
                new Book(2, "2"),
                new Book(1, "1"),
                new Book(3, "3"),
                new Book(6, "6"),
                new Book(7, "7"),
                new Book(5, "5")
            };
            var comparer = new BookComparer();
            var tree = new BinarySearchTree<Book>(collection, comparer.Compare);

            Assert.IsTrue(tree.Constains(removeItem));
            var result = tree.Remove(removeItem);
            Assert.IsTrue(result);
            Assert.IsFalse(tree.Constains(removeItem));

            foreach (var item in collection)
            {
                if (comparer.Compare(item, removeItem) != 0)
                {
                    Assert.IsTrue(tree.Constains(item));
                }
            }
        }
        #endregion Custom class Book test-cases

        #region custom struct Point test-cases

        [Test]
        public void AddPointTests()
        {
            var collection = new Point[]
            {
                new Point(4),
                new Point(2),
                new Point(1),
                new Point(3),
                new Point(6),
                new Point(5),
                new Point(7)
            };
            var comparer = new PointComparer();
            var tree = new BinarySearchTree<Point>(comparer.Compare);

            foreach (var item in collection)
            {
                tree.Add(item);
            }

            foreach (var item in collection)
            {
                Assert.IsTrue(tree.Constains(item));
            }
        }

        [TestCase(4)]
        [TestCase(2)]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(5)]
        public void RemovePointTests(int removeValue)
        {
            var collection = new Point[]
            {
                new Point(4),
                new Point(2),
                new Point(1),
                new Point(3),
                new Point(6),
                new Point(5),
                new Point(7)
            };

            var comparer = new PointComparer();
            var tree = new BinarySearchTree<Point>(collection, comparer.Compare);
            var removeItem = new Point(removeValue);

            Assert.IsTrue(tree.Constains(removeItem));
            var result = tree.Remove(removeItem);
            Assert.IsTrue(result);
            Assert.IsFalse(tree.Constains(removeItem));

            foreach (var item in collection)
            {
                if (comparer.Compare(item, removeItem) != 0)
                {
                    Assert.IsTrue(tree.Constains(item));
                }
            }
        }
        #endregion custom struct Point test-cases
    }
}
