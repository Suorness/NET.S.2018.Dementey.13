using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.Tests.Comparers
{
    class PointComparer : IComparer<Point>
    {
        public int Compare(Point x, Point y)
        {
            if (x.X == y.X)
            {
                return 0;
            }
            else
            {
                if(x.X > y.X)
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
