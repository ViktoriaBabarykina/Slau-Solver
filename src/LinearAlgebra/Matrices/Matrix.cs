using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinearAlgebra.Exceptions;
using LinearAlgebra.Vectors;

namespace LinearAlgebra.Matrices
{
    public abstract class Matrix
    {
        protected IMatrixFactory _matrixFactory;
        protected IVectorFactory _vectorFactory;


        /// <summary>
        /// Конвертирует всю матрицу в один большой вектор.
        /// </summary>
        /// <returns>Возвращает всю матрицу как один большой вектор.</returns>
        public Vector ConvertToVector()
        {
            int k = 0;
            Vector result = _vectorFactory.CreateVector(RowsCount * ColumnsCount);

            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    result[k++] = this[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Возвращает запрошенную строку матрицы как вектор.
        /// </summary>
        /// <param name="rowIndex">Индекс строки, которую нужно вернуть.</param>
        /// <returns>Возвращает запрошенную строку матрицы как вектор.</returns>
        public Vector GetRow(int rowIndex)
        {
            if ((rowIndex < 0) || (rowIndex > RowsCount))
            {
                throw new OutOfRangeException($"Error in index operator. " +
                    $"Given index is [{rowIndex}]. But size is [{RowsCount}].");
            }

            Vector row = _vectorFactory.CreateVector(ColumnsCount);
            for (int j = 0; j < ColumnsCount; j++)
            {
                row[j] = this[rowIndex, j];
            }

            return row;
        }

        public void SetRow(int rowIndex, Vector row)
        {
            if ((rowIndex < 0) || (rowIndex > RowsCount))
            {
                throw new OutOfRangeException($"Error in index operator. " +
                    $"Given index is [{rowIndex}]. But size is [{RowsCount}].");
            }
            if ((row.Size < 0) || (row.Size > RowsCount))
            {
                throw new OutOfRangeException($"Error in index operator. " +
                    $"Given index is [{row.Size}]. But size is [{RowsCount}].");
            }

            for (int j = 0; j < ColumnsCount; j++)
            {
                this[rowIndex, j] = row[j];
            }
        }

        /// <summary>
        /// Создает и возвращает массив векторов, каждый из которых является строкой в матрице.
        /// </summary>
        /// <returns>Возвращает все строки матрицы как векторы.</returns>
        public List<Vector> GetAllRows()
        {
            List<Vector> result = new List<Vector>(); 
            for (int i = 0; i < RowsCount; i++)
            {
                Vector row = GetRow(i);
                result.Add(row);
            }

            return result;
        }

        abstract public double GetElement(int rowIndex, int columnIndex);
        abstract public void SetElement(int rowIndex, int columnIndex, double value); //a[i]=2

        abstract public int RowsCount { get; }
        abstract public int ColumnsCount { get; }

        public double this[int rowIndex, int columnIndex]
        {
            get
            {
                if ((rowIndex < 0) || (rowIndex > RowsCount) || (columnIndex < 0) || (columnIndex > ColumnsCount))
                {
                    throw new OutOfRangeException($"Error in index operator. " +
                        $"Given index is [{rowIndex},{columnIndex}]. But size is [{RowsCount},{ColumnsCount}].");
                }
                return GetElement(rowIndex, columnIndex);
            }
            set
            {
                if ((rowIndex < 0) || (rowIndex > RowsCount) || (columnIndex < 0) || (columnIndex > ColumnsCount))

                {
                    throw new OutOfRangeException($"Error in index operator. " +
                        $"Given index is [{rowIndex},{columnIndex}]. But size is [{RowsCount},{ColumnsCount}].");
                }
                SetElement(rowIndex, columnIndex, value);
            }
        }

        public Vector this[int rowIndex]
        {
            get
            {
                if ((rowIndex < 0) || (rowIndex > RowsCount))
                {
                    throw new OutOfRangeException($"Error in index operator. " +
                        $"Given index is [{rowIndex}]. But size is [{RowsCount}].");
                }
                return GetRow(rowIndex);
            }
            set
            {
                if ((rowIndex < 0) || (rowIndex > RowsCount))

                {
                    throw new OutOfRangeException($"Error in index operator. " +
                        $"Given index is [{rowIndex}]. But size is [{RowsCount}].");
                }
                SetRow(rowIndex, value);
                
            }
        }

        public Matrix Add(Matrix a)
        {
            if ((RowsCount != a.RowsCount) || (ColumnsCount != a.ColumnsCount))
                throw new SizesDismatchException($"Error in addition two matrices: their sizes must match." +
                    $"Size of left matrix: [{RowsCount},{ColumnsCount}], " +
                    $"size of right matrix: [{a.RowsCount},{a.ColumnsCount}].");


            Matrix result = _matrixFactory.CreateMatrix(RowsCount, ColumnsCount);
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    result[i, j] = this[i, j] + a[i, j];
                }
            }
            return result;
        }

        public Matrix Sub(Matrix a)
        {
            if ((RowsCount != a.RowsCount) || (ColumnsCount != a.ColumnsCount))
                throw new SizesDismatchException($"Error in addition two matrices: their sizes must match." +
                    $"Size of left matrix: [{RowsCount},{ColumnsCount}], " +
                    $"size of right matrix: [{a.RowsCount},{a.ColumnsCount}].");


            Matrix result = _matrixFactory.CreateMatrix(RowsCount, ColumnsCount);
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    result[i, j] = this[i, j] - a[i, j];
                }
            }
            return result;
        }

        public Matrix Multiply(Matrix a)
        {
            if ((ColumnsCount != a.RowsCount))
                throw new SizesDismatchException($"Error in multiply two matrices: columns of the first must be equal " +
                    $"to rows of the second." +
                    $"Size of left matrix: [{RowsCount},{ColumnsCount}], " +
                    $"size of right matrix: [{a.RowsCount},{a.ColumnsCount}].");

            Matrix result = _matrixFactory.CreateMatrix(RowsCount, a.ColumnsCount);
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < a.ColumnsCount; j++)
                {
                    for (int k = 0; k < ColumnsCount; k++)
                    {
                        result[i, j] += this[i, k] * a[k, j];
                    }

                }
            }
            return result;
        }

        public bool AreEqual(Matrix a)
        {
            if ((RowsCount != a.RowsCount) || (ColumnsCount != a.ColumnsCount))
                throw new SizesDismatchException($"matrices sizes must match." +
                    $"Size of left matrix: [{RowsCount},{ColumnsCount}], " +
                    $"size of right matrix: [{a.RowsCount},{a.ColumnsCount}].");

            bool result = true;
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    if (!DoubleComparator.AreEqual(a[i, j], this[i, j]))
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }

        public Matrix Multiply(double a)
        {
            Matrix result = _matrixFactory.CreateMatrix(RowsCount, ColumnsCount);
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    result[i, j] = this[i, j] * a;
                }
            }
            return result;
        }

        /// <summary>
        /// Умножение вектора-строки на текущую матрицу.
        /// </summary>
        /// <param name="a">Вектор-строка.</param>
        /// <returns>Результирующая новая матрица.</returns>
        public Matrix MultiplyRowLeft(Vector a)
        {
            Matrix lValue = _matrixFactory.CreateRowMatrix(a);
            return lValue * this;
        }

        /// <summary>
        /// Умножение текущий матрицы на вектор-строку.
        /// </summary>
        /// <param name="a">Вектор-строка.</param>
        /// <returns>Результирующая новая матрица.</returns>
        public Matrix MultiplyRowRight(Vector a)
        {
            Matrix rValue = _matrixFactory.CreateRowMatrix(a);
            return this * rValue;
        }

        /// <summary>
        /// Умножение вектора-столбца на текущую матрицу.
        /// </summary>
        /// <param name="a">Вектор-строка.</param>
        /// <returns>Результирующая новая матрица.</returns>
        public Matrix MultiplyColumnRight(Vector a)
        {
            Matrix lValue = _matrixFactory.CreateColumnMatrix(a);
            return lValue * this;
        }

        /// <summary>
        /// Умножение текущий матрицы на вектор-столбец.
        /// </summary>
        /// <param name="a">Вектор-строка.</param>
        /// <returns>Результирующая новая матрица.</returns>
        public Matrix MultiplyColumnLeft(Vector a)
        {
            Matrix rValue = _matrixFactory.CreateColumnMatrix(a);
            return this * rValue;
        }

        public Matrix Transpose()
        {
            Matrix result = _matrixFactory.CreateMatrix(ColumnsCount, RowsCount);

            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    result[j, i] = this[i, j];
                }
            }
            return result;
        }

        /// <summary>
        /// Возвращает обратную матрицу, если она есть.
        /// </summary>
        /// <returns>Обратная матрица.</returns>
        public Matrix Reverse()
        {

            // Если обратной матрицы нет, кидать эксепшен (создать под это новый класс).
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string result = "";
            for(int i = 0; i < RowsCount; i++)
            {
                result += this[i] + "\n";
            }

            return result;
        }

        #region Operators overloading

        public static Matrix operator +(Matrix lvalue, Matrix rvalue)
        {
            return lvalue.Add(rvalue);
        }

        public static Matrix operator -(Matrix lvalue, Matrix rvalue)
        {
            return lvalue.Sub(rvalue);
        }

        public static Matrix operator *(Matrix lvalue, Matrix rvalue)
        {
            return lvalue.Multiply(rvalue);
        }

        public static Matrix operator *(Matrix lvalue, double rvalue)
        {
            return lvalue.Multiply(rvalue);
        }

        public static Matrix operator *(double lvalue, Matrix rvalue)
        {
            return rvalue.Multiply(lvalue);
        }
        public static Matrix operator *(Matrix lvalue, Vector rvalue)
        {
            return lvalue.MultiplyRowRight(rvalue);
        }

        public static Matrix operator *(Vector lvalue, Matrix rvalue)
        {
            return rvalue.MultiplyRowLeft(lvalue);
        }

       

        // TODO:
        // Добавить две перегрузки для умножения: умножение матрицы на число и числа на матрицу.+
        // Доделать ConvertToVector. +
        // Ну ладно, Вика - лапочка.+-
        // Покрыть все тестами.+ 
        // 
        // Переименовать проект SlauSolving в ConsoleSlauSolving.+
        // В проект ConsoleSlauSolving перенести код из Kill me please и попробовать изменить на использование векторов и матриц
        // Создать библиотеку "SlauSolving", куда вынести алгоритмы решения СЛАУ.
        // Воспользоваться этой библиотекой в ConsoleSlauSolving.
        // Создать windows forms проект WinFormsSlauSolving и воспользоваться в нем библиотеками LinearAlgebra и SlauSolving.

        #endregion
    }
}
