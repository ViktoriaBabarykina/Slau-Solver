using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra
{
    public class DoubleComparator
    {
        public static bool AreEqual(double a, double b, double eps = 0.000001)
        {
            return Math.Abs(a - b) < eps;
        }
    }
}
