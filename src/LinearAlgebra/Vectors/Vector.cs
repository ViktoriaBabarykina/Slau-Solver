using LinearAlgebra.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra.Vectors
{
    abstract public class Vector
    {
        abstract public int Size { get; }

        abstract public IEnumerable<double> ConvertToEnumerable();
        abstract public double GetElement(int elementIndex);
        abstract public void SetElement(int elementIndex, double value);

        protected IVectorFactory _vectorFactory;

        public Vector Add(Vector a)
        {
            if (Size != a.Size)
                throw new SizesDismatchException($"Error in addition two vectors: their sizes must match." +
                    $"Size of left vector: {Size}, size of right vector: {a.Size}.");

            //Vector result = (Vector) Activator.CreateInstance(this.GetType(), Size);
            Vector result = _vectorFactory.CreateVector(Size);

            for (int i = 0; i < Size; i++)
            {
                result[i] = this[i] + a[i];
            }

            return result;
        }

        public Vector Sub(Vector a)
        {
            if (Size != a.Size)
                throw new SizesDismatchException($"Error in addition two vectors: their sizes must match." +
                    $"Size of left vector: {Size}, size of right vector: {a.Size}.");
            Vector result = _vectorFactory.CreateVector(Size);
            for (int i = 0; i < Size; i++)
            {
                result[i] = this[i] - a[i];
            }

            return result;
        }

        public Vector Multiply(Vector a)
        {
            if (Size != a.Size)
                throw new SizesDismatchException($"Error in multiply two vectors: their sizes must match." +
                    $"Size of left vector: {Size}, size of right vector: {a.Size}.");

            Vector result = _vectorFactory.CreateVector(Size);
            for (int i = 0; i < Size; i++)
            {
                result[i] = this[i] * a[i];
            }

            return result;
        }


        public Vector Multiply(double a)
        {
            Vector result = _vectorFactory.CreateVector(Size);
            for (int i = 0; i < Size; i++)
            {
                result[i] = this[i] * a;
            }

            return result;
        }

        public  double ScalarMultiply(Vector a)
        {
            if (Size != a.Size)
                throw new SizesDismatchException($"Error in multiply two vectors: their sizes must match." +
                    $"Size of left vector: {Size}, size of right vector: {a.Size}.");

            double sum = 0;
            for (int i = 0; i < Size; i++)
            {
                sum += this[i] * a[i];
            }

            return sum;
        }

        public bool AreEqual(Vector a)
        {
            if (Size != a.Size)
                throw new SizesDismatchException($"Error in multiply two vectors: their sizes must match." +
                    $"Size of left vector: {Size}, size of right vector: {a.Size}.");

            bool result = true;
            for (int i = 0; i < Size; i++)
            {
                if (!DoubleComparator.AreEqual(a[i], this[i]))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public double this[int index]
        {
            get
            {
                if ((index < 0) || (index > Size))
                {
                    throw new OutOfRangeException($"Error in index operator. " +
                        $"Given index is {index}. But size is {Size}.");
                }                 
                return GetElement(index);
            }
            set
            {
                if ((index < 0) || (index > Size))
                {
                    throw new OutOfRangeException($"Error in index operator. " +
                        $"Given index is {index}. But size is {Size}.");
                }
                SetElement(index, value);
            }
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Size; i++)
                result += this[i].ToString() + (i < Size - 1 ? " " : ""); 

            return result;
        }

        #region Operators overloading

        public static Vector operator +(Vector lvalue, Vector rvalue)
        {
            return lvalue.Add(rvalue);
        }

        public static Vector operator -(Vector lvalue, Vector rvalue)
        {
            return lvalue.Sub(rvalue);
        }

        public static Vector operator *(Vector lvalue, double rvalue)
        {
            return lvalue.Multiply(rvalue);
        }

        public static Vector operator *(double lvalue, Vector rvalue)
        {
            return rvalue.Multiply(lvalue);
        }

        public static Vector operator *(Vector lvalue, Vector rvalue)
        {
            return lvalue.Multiply(rvalue);
        }

        #endregion
    }

}
