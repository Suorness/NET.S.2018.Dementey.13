namespace BinaryTree.Tests.Comparers
{
    using System.Collections.Generic;

    public class IntComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x == y)
            {
                return 0;
            }
            else
            {
                if (x > y)
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
