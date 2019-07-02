using LinearAlgebra.Vectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra.Matrices
{
    public class DenseMatrixFactory : IMatrixFactory
    {
        public Matrix CreateMatrix()
        {
            return new DenseMatrix();
        }

        public Matrix CreateRowMatrix(Vector vector)
        {
            return DenseMatrix.CreateRowMatrix(vector);
        }

        public Matrix CreateColumnMatrix(Vector vector)
        {
            return DenseMatrix.CreateColumnMatrix(vector);
        }

        public Matrix CreateMatrix(int rowCount, int columnCount)
        {
            return new DenseMatrix(rowCount, columnCount);
        }

        public Matrix CreateMatrix(double[,] matrix)
        {
            return new DenseMatrix(matrix);
        }

        public Matrix CreateMatrix(Matrix matrix)
        {
            return new DenseMatrix(matrix);
        }

        public Matrix CreateMatrix(IEnumerable<IEnumerable<double>> matrix)
        {
            return new DenseMatrix(matrix);
        }
    }
}
