using System;
using System.Collections.Generic;
using LinearAlgebra;
using LinearAlgebra.Exceptions;
using LinearAlgebra.Matrices;
using LinearAlgebra.Vectors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LinearAlgebraTests
{
    abstract public class MatrixTest
    {
        protected IMatrixFactory _matrixFactory;
        protected IVectorFactory _vectorFactory;

        [TestMethod]
        public void ConvertToVectorTest()
        {
            // arrange
            double[,] matrix = new double[3, 3] {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
            Matrix m1 = _matrixFactory.CreateMatrix(matrix);

            // act
            Vector result = m1.ConvertToVector();

            // assert
            double[] vector = new double[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Vector expected = _vectorFactory.CreateVector(vector);
            Assert.IsTrue(expected.AreEqual(result));
        }

        [TestMethod]
        public void AddTest1()
        {
            // arrange
            double[,] matrix1 = new double[3, 3] {
               { 1, 2, 3 },
               { 4, 5, 6 },
               { 7, 8, 9 }
            };
            double[,] matrix2 = new double[3, 3] {
               { -1, -2, -3 },
               { -4, -5, -6 },
               { -7, -8, -9 }
            };
            Matrix m1 = _matrixFactory.CreateMatrix(matrix1);
            Matrix m2 = _matrixFactory.CreateMatrix(matrix2);

            // act
            Matrix result = m1 + m2;

            // assert
            double[,] matrix3 = new double[3, 3] {
               { 0, 0, 0 },
               { 0, 0, 0 },
               { 0, 0, 0 }
            };
            Matrix expected = _matrixFactory.CreateMatrix(matrix3);
            Assert.IsTrue(expected.AreEqual(result));

        }

        [TestMethod]
        public void SubTest1()
        {
            // arrange
            double[,] matrix1 = new double[3, 3] {
               { 1, 2, 3 },
               { 4, 5, 6 },
               { 7, 8, 9 }
            };
            double[,] matrix2 = new double[3, 3] {
               { 1, 2, 3 },
               { 4, 5, 6 },
               { 7, 8, 9 }
            };
            Matrix m1 = _matrixFactory.CreateMatrix(matrix1);
            Matrix m2 = _matrixFactory.CreateMatrix(matrix2);

            // act
            Matrix result = m1 - m2;

            // assert
            double[,] matrix3 = new double[3, 3] {
               { 0, 0, 0 },
               { 0, 0, 0 },
               { 0, 0, 0 }
            };
            Matrix expected = _matrixFactory.CreateMatrix(matrix3);
            Assert.IsTrue(expected.AreEqual(result));

        }

        [TestMethod]
        [ExpectedException(typeof(SizesDismatchException))]
        public void SubTest2()
        {
            // arrange
            double[,] matrix1 = new double[3, 3] {
               { 5, 8, -4 },
               { 6, 9, -5 },
               { 4, 7, -3 }
            };
            double[,] matrix2 = new double[4, 3] {
               { 3, 2, 5 },
               { 4, -1, 3 },
               { 9, 6, 5 },
               { 9, 6, 5 }
            };
            Matrix m1 = _matrixFactory.CreateMatrix(matrix1);
            Matrix m2 = _matrixFactory.CreateMatrix(matrix2);

            // act
            Matrix result = m1 - m2;

        }

        [ExpectedException(typeof(SizesDismatchException))]
        [TestMethod]
        public void SubTest3()
        {
            // arrange
            double[,] matrix1 = new double[3, 3] {
               { 5, 8, -4 },
               { 6, 9, -5 },
               { 4, 7, -3 }
            };
            double[,] matrix2 = new double[4, 4] {
               { 3, 2, 5, 8 },
               { 4, -1, 3, 9 },
               { 9, 6, 5, 0 },
               { 9, 6, 5, 7 }
            };
            Matrix m1 = _matrixFactory.CreateMatrix(matrix1);
            Matrix m2 = _matrixFactory.CreateMatrix(matrix2);

            // act
            Matrix result = m1 - m2;

        }

        [TestMethod]
        [ExpectedException(typeof(SizesDismatchException))]
        public void AddTest2()
        {
            // arrange
            double[,] matrix1 = new double[3, 3] {
               { 5, 8, -4 },
               { 6, 9, -5 },
               { 4, 7, -3 }
            };
            double[,] matrix2 = new double[4, 3] {
               { 3, 2, 5 },
               { 4, -1, 3 },
               { 9, 6, 5 },
               { 9, 6, 5 }
            };
            Matrix m1 = _matrixFactory.CreateMatrix(matrix1);
            Matrix m2 = _matrixFactory.CreateMatrix(matrix2);

            // act
            Matrix result = m1 + m2;

        }

        [ExpectedException(typeof(SizesDismatchException))]
        [TestMethod]
        public void AddTest3()
        {
            // arrange
            double[,] matrix1 = new double[3, 3] {
               { 5, 8, -4 },
               { 6, 9, -5 },
               { 4, 7, -3 }
            };
            double[,] matrix2 = new double[4, 4] {
               { 3, 2, 5, 8 },
               { 4, -1, 3, 9 },
               { 9, 6, 5, 0 },
               { 9, 6, 5, 7 }
            };
            Matrix m1 = _matrixFactory.CreateMatrix(matrix1);
            Matrix m2 = _matrixFactory.CreateMatrix(matrix2);

            // act
            Matrix result = m1 + m2;

        }

        [TestMethod]
        public void MultiplyTest1()
        {
            // arrange
            double[,] matrix1 = new double[3, 3] {
               { 5, 8, -4 },
               { 6, 9, -5 },
               { 4, 7, -3 }
            };
            double[,] matrix2 = new double[3, 3] {
               { 3, 2, 5 },
               { 4, -1, 3 },
               { 9, 6, 5 }
            };
            Matrix m1 = _matrixFactory.CreateMatrix(matrix1);
            Matrix m2 = _matrixFactory.CreateMatrix(matrix2);

            // act
            Matrix result = m1 * m2;

            // assert
            double[,] matrix3 = new double[3, 3] {
               { 11, -22, 29 },
               { 9, -27, 32 },
               { 13, -17, 26 }
            };
            Matrix expected = _matrixFactory.CreateMatrix(matrix3);
            Assert.IsTrue(expected.AreEqual(result));
        }

        [TestMethod]
        [ExpectedException(typeof(SizesDismatchException))]
        public void MultiplyTest2()
        {
            // arrange
            double[,] matrix1 = new double[3, 3] {
               { 5, 8, -4 },
               { 6, 9, -5 },
               { 4, 7, -3 }
            };
            double[,] matrix2 = new double[4, 4] {
               { 3, 2, 5, 8 },
               { 4, -1, 3, 9 },
               { 9, 6, 5, 0 },
               { 9, 6, 5, 7 }
            };
            Matrix m1 = _matrixFactory.CreateMatrix(matrix1);
            Matrix m2 = _matrixFactory.CreateMatrix(matrix2);

            // act
            Matrix result = m1 * m2;

        }

        [TestMethod]
        public void GetElementTest()
        {
            // arrange
            double[,] matrix1 = new double[3, 3] {
               { 5, 8, -4 },
               { 6, 9, -5 },
               { 4, 7, -3 }
            };
            Matrix m1 = _matrixFactory.CreateMatrix(matrix1);

            // act
            double result = m1[1, 2];

            // assert
            double expected = -5;
            Assert.IsTrue(DoubleComparator.AreEqual(expected, result));
        }

        [TestMethod]
        public void SetElementTest()
        {
            // arrange
            double[,] matrix1 = new double[3, 3] {
               { 5, 8, -4 },
               { 6, 9, -5 },
               { 4, 7, -3 }
            };
            Matrix m1 = _matrixFactory.CreateMatrix(matrix1);

            // act
            m1[1, 0] = 90;
            // assert
            double[,] matrix3 = new double[3, 3] {
               { 5, 8, -4 },
               { 90, 9, -5 },
               { 4, 7, -3 }
            };
            Matrix expected = _matrixFactory.CreateMatrix(matrix3);
            Assert.IsTrue(expected.AreEqual(m1));
        }

        [TestMethod]
        public void NumberMultiplyTest1()
        {
            // arrange
            double[,] matrix1 = new double[2, 3] {
                { 1, 1, 1 },
                { 1, 1, 1 },
            };

            Matrix m1 = _matrixFactory.CreateMatrix(matrix1);
            double a = 2;

            // act
            Matrix result = m1 * a;

            // assert
            double[,] matrix3 = new double[2, 3] {
               { 2, 2, 2 },
               { 2, 2, 2 },
            };
            Matrix expected = _matrixFactory.CreateMatrix(matrix3);
            Assert.IsTrue(expected.AreEqual(result));
        }

        [TestMethod]
        public void NumberMultiplyTest2()
        {
            // arrange
            double[,] matrix1 = new double[2, 3] {
                { 1, 1, 1 },
                { 1, 1, 1 },
            };

            Matrix m1 = _matrixFactory.CreateMatrix(matrix1);
            double a = 2;

            // act
            Matrix result = a * m1;

            // assert
            double[,] matrix3 = new double[2, 3] {
               { 2, 2, 2 },
               { 2, 2, 2 },
            };
            Matrix expected = _matrixFactory.CreateMatrix(matrix3);
            Assert.IsTrue(expected.AreEqual(result));
        }

        [TestMethod]
        public void AreEqualTest1()
        {
            // arrange
            double[,] matrix1 = new double[2, 3] {
                { 1, 1, 1 },
                { 1, 1, 1 },
            };
            double[,] matrix2 = new double[2, 3] {
                { 1, 1, 1 },
                { 1, 1, 1 },
            };
            Matrix m1 = _matrixFactory.CreateMatrix(matrix1);
            Matrix m2 = _matrixFactory.CreateMatrix(matrix2);

            // act
            bool result = m1.AreEqual(m2);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AreEqualTest2()
        {
            // arrange
            double[,] matrix1 = new double[2, 3] {
                { 1, 1, 1 },
                { 1, 1, 1 },
            };
            double[,] matrix2 = new double[2, 3] {
                { 1, 1, 1 },
                { 4, 1, 2 },
            };
            Matrix m1 = _matrixFactory.CreateMatrix(matrix1);
            Matrix m2 = _matrixFactory.CreateMatrix(matrix2);

            // act
            bool result = m1.AreEqual(m2);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(SizesDismatchException))]
        public void AreEqualTest3()
        {
            // arrange
            double[,] matrix1 = new double[2, 3] {
                { 1, 1, 1 },
                { 1, 1, 1 }
            };
            double[,] matrix2 = new double[3, 3] {
                { 1, 1, 1 },
                { 1, 1, 1 },
                { 1, 1, 1 }
            };
            Matrix m1 = _matrixFactory.CreateMatrix(matrix1);
            Matrix m2 = _matrixFactory.CreateMatrix(matrix2);

            // act
            m1.AreEqual(m2);
        }

        [TestMethod]
        public void TransposeTest()
        {
            // arrange
            double[,] matrix1 = new double[3, 3] {
               { 1, 2, 3 },
               { 4, 5, 6 },
               { 7, 8, 9 }
            };
            Matrix m1 = _matrixFactory.CreateMatrix(matrix1);

            // act
            Matrix result = m1.Transpose();

            // assert
            double[,] matrix2 = new double[3, 3] {
               { 1, 4, 7 },
               { 2, 5, 8 },
               { 3, 6, 9 }
            };
            Matrix expected = _matrixFactory.CreateMatrix(matrix2);
            Assert.IsTrue(expected.AreEqual(result));
        }

        [TestMethod]
        public void MultiplyRowLeftTest()
        {
            // arrange
            double[,] matrix1 = new double[3, 3] {
               { 1, 2, 3 },
               { 1, 2, 3 },
               { 1, 2, 3 }
            };
            Matrix m1 = _matrixFactory.CreateMatrix(matrix1);
            Vector v1 = _vectorFactory.CreateVector(new double[] { 1, 2, 3 });

            // act
            Matrix result = m1.MultiplyRowLeft(v1);

            // assert
            double[,] matrix2 = new double[1, 3]
            { { 6 , 12, 18 } };

            Matrix expected = _matrixFactory.CreateMatrix(matrix2);
            Assert.IsTrue(expected.AreEqual(result));
        }

        [TestMethod]
        public void MultiplyColumnLeftTest()
        {
            // arrange
            double[,] matrix1 = new double[1, 3] {
               { 1, 1, 1 },
            };
            Matrix m1 = _matrixFactory.CreateMatrix(matrix1);
            Vector v1 = _vectorFactory.CreateVector(new double[] { 1, 1, 1 });

            // act
            Matrix result = m1.MultiplyColumnLeft(v1);

            // assert
            double[,] matrix2 = new double[1, 1]
            { { 3 } };

            Matrix expected = _matrixFactory.CreateMatrix(matrix2);
            Assert.IsTrue(expected.AreEqual(result));
        }

        [TestMethod]
        public void MultiplyColumnRightTest()
        {
            // arrange
            double[,] matrix1 = new double[1, 3] {
               { 1, 1, 1 },
            };
            Matrix m1 = _matrixFactory.CreateMatrix(matrix1);
            Vector v1 = _vectorFactory.CreateVector(new double[] { 1, 1, 1 });

            // act
            Matrix result = m1.MultiplyColumnRight(v1);

            // assert
            double[,] matrix2 = new double[3, 3] {
               { 1, 1, 1 },
               { 1, 1, 1 },
               { 1, 1, 1 }
            };
            Matrix expected = _matrixFactory.CreateMatrix(matrix2);
            Assert.IsTrue(expected.AreEqual(result));
        }
        [TestMethod]
        public void MultiplyRowRightTest()
        {
            // arrange
            double[,] matrix1 = new double[3, 1] {
                { 1 },
                { 1 },
                { 1 }
            };
            Matrix m1 = _matrixFactory.CreateMatrix(matrix1);
            Vector v1 = _vectorFactory.CreateVector(new double[] { 1, 2, 3 });

            // act
            Matrix result = m1.MultiplyRowRight(v1);

            // assert
            double[,] matrix2 = new double[3, 3] {
               { 1, 2, 3 },
               { 1, 2, 3 },
               { 1, 2, 3 }
            };
            Matrix expected = _matrixFactory.CreateMatrix(matrix2);
            Assert.IsTrue(expected.AreEqual(result));
        }
       
    }
    

}
