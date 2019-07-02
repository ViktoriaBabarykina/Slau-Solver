using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra.Vectors
{
    public interface IVectorFactory
    {
        Vector CreateVector();
        Vector CreateVector(int dimensionSize);
        Vector CreateVector(IEnumerable<double> data);
        Vector CreateVector(Vector init);
    }
}
