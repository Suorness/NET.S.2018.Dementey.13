namespace CustomQueue.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class QueueTests
    {
        [TestCase(999)]
        public void EnumeratorTests(int length)
        {
            var queue = new Queue<int>(Enumerable.Range(0, length));
            int value = 0;

            foreach (var item in queue)
            {
                Assert.AreEqual(item, value);
                value++;
            }

            Assert.AreEqual(value, length);
        }

        [TestCase(999)]
        public void EnumeratorTestsThrowsInvalidOperationException(int length)
        {
            var queue = new Queue<int>(Enumerable.Range(0, length));

            var enumerator = queue.GetEnumerator();
            queue.Dequeue();

            Assert.Throws<InvalidOperationException>(() => enumerator.MoveNext());
        }

        [TestCase(999)]
        public void DequeueTests(int length)
        {
            var queue = new Queue<int>(Enumerable.Range(0, length));
            int startValue = 0;

            for (int i = 0; i < length; i++)
            {
                int value = startValue;
                foreach (var item in queue)
                {
                    Assert.AreEqual(item, value);
                    value++;
                }

                Assert.AreEqual(startValue, queue.Dequeue());
                startValue++;
            }
        }

        [TestCase(999)]
        public void EnqueueTests(int length)
        {
            var queue = new Queue<int>();
            int startValue = 0;

            for (int i = 0; i < length; i++)
            {
                int value = 0;
                foreach (var item in queue)
                {
                    Assert.AreEqual(item, value);
                    value++;
                }

                Assert.AreEqual(value, startValue);
                queue.Enqueue(startValue++);
            }
        }

        [TestCase(999)]
        public void CountTests(int length)
        {
            var queue = new Queue<int>();
            int startValue = 0;

            for (int i = 0; i < length; i++)
            {
                int value = 0;
                foreach (var item in queue)
                {
                    value++;
                }

                Assert.AreEqual(value, queue.Count);
                queue.Enqueue(startValue++);
            }
        }
    }
}
