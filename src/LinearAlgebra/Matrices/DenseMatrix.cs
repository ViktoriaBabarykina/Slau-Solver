using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinearAlgebra.Exceptions;
using LinearAlgebra.Vectors;

namespace LinearAlgebra.Matrices
{
    public class DenseMatrix : Matrix
    {
        double[,] Data;

        public DenseMatrix()
        {
            _matrixFactory = new DenseMatrixFactory();
            _vectorFactory = new DenseVectorFactory();
            Data = new double[1, 1];
        }

        public DenseMatrix(int rowCount, int columnCount) 
            : this()
        {
            Data = new double[rowCount, columnCount];
        }

        public DenseMatrix(double[,] matrix)  
            : this()
        {
            Data = new double[matrix.GetLength(0), matrix.GetLength(1)];

            for(int i = 0; i < RowsCount; i++)
            {
                for(int j = 0; j < ColumnsCount; j++)
                {
                    Data[i, j] = matrix[i, j];
                }
            }
            
        }

        public DenseMatrix(Matrix matrix)
            : this()
        {
            Data = new double[RowsCount, ColumnsCount];

            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    Data[i, j] = matrix[i, j];
                }
            }
        }
        public static Matrix CreateRowMatrix(Vector vector)
        {
            Matrix result = new DenseMatrix(1, vector.Size);
            for (int i = 0; i < vector.Size; i++)
            {
                result[0, i] = vector[i];
            }
            return result;
        }

        public static Matrix CreateColumnMatrix(Vector vector)
        {
            Matrix result = new DenseMatrix(vector.Size, 1);
            for (int i = 0; i < vector.Size; i++)
            {
                result[i, 0] = vector[i];
            }
            return result;
        }

        public DenseMatrix(IEnumerable<IEnumerable<double>> matrix)
        {
            _matrixFactory = new DenseMatrixFactory();
            Data = new double[RowsCount, ColumnsCount];

            List<List<double>> indexedMatrix = matrix.Select(row => row.ToList()).ToList();
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    Data[i, j] = indexedMatrix[i][j];
                }
            }
        }

        public override int RowsCount => Data.GetLength(0);

        public override int ColumnsCount => Data.GetLength(1);

        public override double GetElement(int rowIndex, int columnIndex)
        {
            if ((rowIndex < 0) || (rowIndex > RowsCount) || (columnIndex < 0) || (columnIndex > ColumnsCount))
            {
                throw new OutOfRangeException($"Error in GetElement method. " +
                    $"Given index is [{rowIndex},{columnIndex}]. But size is [{RowsCount},{ColumnsCount}].");
            }

            return Data[rowIndex, columnIndex];
        }

        public override void SetElement(int rowIndex, int columnIndex, double value)
        {
            if ((rowIndex < 0) || (rowIndex > RowsCount) || (columnIndex < 0) || (columnIndex > ColumnsCount))
            {
                throw new OutOfRangeException($"Error in SetElement method. " +
                    $"Given index is [{rowIndex},{columnIndex}]. But size is [{RowsCount},{ColumnsCount}].");
            }

            Data[rowIndex, columnIndex] = value;
        }
    }
}
