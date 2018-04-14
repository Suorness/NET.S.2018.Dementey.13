namespace BinaryTree.Tests
{
    using System;

    public class Book : IComparable<Book>
    {
        public readonly int Year;
        public readonly string Title;

        public Book(int year, string title)
        {
            Year = year;
            Title = title;
        }

        public int CompareTo(Book other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }

            if (Year == other.Year)
            {
                return 0;
            }
            else
            {
                if (Year > other.Year)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}
