using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra.Vectors
{
    public class DenseVectorFactory : IVectorFactory
    {
        public Vector CreateVector()
        {
            return new DenseVector();
        }

        public Vector CreateVector(int dimensionSize)
        {
            return new DenseVector(dimensionSize);
        }

        public Vector CreateVector(IEnumerable<double> data)
        {
            return new DenseVector(data);
        }

        public Vector CreateVector(Vector init)
        {
            return new DenseVector(init);
        }
    }
}
