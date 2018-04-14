namespace BinaryTree.Tests.Comparers
{
    using System.Collections.Generic;

    public class StringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x.Length == y.Length)
            {
                return 0;
            }
            else
            {
                if (x.Length > y.Length)
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
