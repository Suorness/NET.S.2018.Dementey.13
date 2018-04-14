namespace BinaryTree.Tests.Comparers
{
    using System.Collections.Generic;

    public class BookComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (ReferenceEquals(x, y))
            {
                return 0;
            }
            
            if (ReferenceEquals(x, null))
            {
                return -1;
            }

            if (ReferenceEquals(y, null))
            {
                return 1;
            }

            return string.CompareOrdinal(x.Title, y.Title);
        }
    }
}
