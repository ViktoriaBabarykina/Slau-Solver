using LinearAlgebra.Vectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra.Matrices
{
    public interface IMatrixFactory
    {
        Matrix CreateMatrix();
        Matrix CreateRowMatrix(Vector vector);
        Matrix CreateColumnMatrix(Vector vector);
        Matrix CreateMatrix(int rowCount, int columnCount);
        Matrix CreateMatrix(double[,] matrix);
        Matrix CreateMatrix(Matrix matrix);
        Matrix CreateMatrix(IEnumerable<IEnumerable<double>> matrix);
    }
}
