using LinearAlgebra.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra.Vectors
{
    public class DenseVector : Vector
    {
        List<double> Data { get; set; }

        public override int Size => Data.Count;

        public DenseVector()
        {
            _vectorFactory = new DenseVectorFactory();
            Data = new List<double>();
            Data.Add(0);
        }

        public DenseVector(int dimensionSize)
        {
            _vectorFactory = new DenseVectorFactory();
            Data = new List<double>(dimensionSize);
            for (int i = 0; i < dimensionSize; i++)
                Data.Add(0);
        }

        public DenseVector(IEnumerable<double> data)
        {
            _vectorFactory = new DenseVectorFactory();
            Data = data.ToList();
        }

        public DenseVector(Vector init)
        {
            _vectorFactory = new DenseVectorFactory();
            Data = init.ConvertToEnumerable().ToList();
        }

        public override IEnumerable<double> ConvertToEnumerable()
        {
            return new List<double>(Data);
        }

        public override double GetElement(int elementIndex)
        {
            if ((elementIndex < 0) || (elementIndex > Size))
            {
                throw new OutOfRangeException($"Error in GetElement. " +
                    $"Given index is {elementIndex}. But size is {Size}.");
            }
            return Data[elementIndex];
        }

        public override void SetElement(int elementIndex, double value)
        {  
            if ((elementIndex < 0) || (elementIndex > Size))
            {
                throw new OutOfRangeException($"Error in SetElement. " +
                    $"Given index is {elementIndex}. But size is {Size}.");
            }
            Data[elementIndex] = value;
        }
    }
}
