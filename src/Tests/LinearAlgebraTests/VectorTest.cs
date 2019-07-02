using System;
using System.Collections.Generic;
using System.Linq;
using LinearAlgebra;
using LinearAlgebra.Exceptions;
using LinearAlgebra.Vectors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LinearAlgebraTests
{
    abstract public class VectorTest
    {
        protected IVectorFactory _vectorFactory;

        [TestMethod]
        public void SizeTest()
        {
            // arrange
            Vector v1 = _vectorFactory.CreateVector(new List<double> { 1, 2, 3 });
            
            // act
            int result = v1.Size;

            // assert
            int expected = 3;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ConvertToEnumerableTest()
        {
            // arrange
            Vector v1 = _vectorFactory.CreateVector(new List<double> { 1, 2, 3 });

            // act 
            List<double> result = v1.ConvertToEnumerable().ToList();

            // assert
            bool areEqual = true;

            for(int i = 0; i < v1.Size; i++)
            {
                if (!DoubleComparator.AreEqual(v1[i], result[i]))
                {
                    areEqual = false;
                    break;
                }
            }
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void AreEqualTest1()
        {
            // arrange
            Vector v1 = _vectorFactory.CreateVector(new List<double> { 1, 2, 3 });
            Vector v2 = _vectorFactory.CreateVector(new List<double> { 1, 2, 3 });

            // act
            bool result = v1.AreEqual(v2);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AreEqualTest2()
        {
            // arrange
            Vector v1 = _vectorFactory.CreateVector(new List<double> { 1, 2, 3 });
            Vector v2 = _vectorFactory.CreateVector(new List<double> { 1, 2, 5 });

            // act
            bool result = v1.AreEqual(v2);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(SizesDismatchException))]
        public void AreEqualTest3()
        {
            // arrange
            Vector v1 = _vectorFactory.CreateVector(new List<double> { 1, 2, 3 });
            Vector v2 = _vectorFactory.CreateVector(new List<double> { 1, 2, 3, 0 });

            // act
            v1.AreEqual(v2);

            // Можно было без атрибута. Тогда нужен код ниже:
            // act
            //bool exceptionRaised = false;
            //try
            //{
            //    bool result = v1.AreEquals(v2);
            //}
            //catch (SizesDismatchException e)
            //{
            //    exceptionRaised = true;
            //}

            //// assert
            //Assert.IsTrue(exceptionRaised);
        }
        
        [TestMethod]
        public void SubTest1()
        {
            // arrange
            Vector v1 = _vectorFactory.CreateVector(new List<double> { 1, 2, 3 });
            Vector v2 = _vectorFactory.CreateVector(new List<double> { 4, 5, 6 });

            // act
            Vector result = v1 - v2;

            // assert
            Vector expected = _vectorFactory.CreateVector(new List<double> { -3, -3, -3 });
            Assert.IsTrue(expected.AreEqual(result));
        }

        [TestMethod]
        [ExpectedException(typeof(SizesDismatchException))]
        public void SubTest2()
        {
            // arrange
            Vector v1 = _vectorFactory.CreateVector(new List<double> { 1, 2, 3 });
            Vector v2 = _vectorFactory.CreateVector(new List<double> { 1, 2, 3, 0 });

            // act
            Vector result = v1 - v2;
        }

        [TestMethod]
        public void AddTest1()
        {
            // arrange
            Vector v1 = _vectorFactory.CreateVector(new List<double> { 1, 2, 3 });
            Vector v2 = _vectorFactory.CreateVector(new List<double> { 4, 5, 6 });

            // act
            Vector result = v1 + v2;

            // assert
            Vector expected = _vectorFactory.CreateVector(new List<double> { 5, 7, 9 });
            Assert.IsTrue(expected.AreEqual(result));
        }

        [TestMethod]
        [ExpectedException(typeof(SizesDismatchException))]
        public void AddTest2()
        {
            // arrange
            Vector v1 = _vectorFactory.CreateVector(new List<double> { 1, 2, 3 });
            Vector v2 = _vectorFactory.CreateVector(new List<double> { 1, 2, 3, 0 });

            // act
            Vector result = v1 + v2;
        }

        [TestMethod]
        public void VectorMultipleTest1()
        {
            // arrange
            Vector v1 = _vectorFactory.CreateVector(new List<double> { 1, 2, 3 });
            Vector v2 = _vectorFactory.CreateVector(new List<double> { 4, 5, 6 });

            // act
            Vector result = v1 * v2;

            // assert
            Vector expected = _vectorFactory.CreateVector(new List<double> { 4, 10, 18 });
            Assert.IsTrue(expected.AreEqual(result));
        }

        [TestMethod]
        [ExpectedException(typeof(SizesDismatchException))]
        public void VectorMultipleTest2()
        {
            // arrange
            Vector v1 = _vectorFactory.CreateVector(new List<double> { 1, 2, 3 });
            Vector v2 = _vectorFactory.CreateVector(new List<double> { 1, 2, 3, 0 });

            // act
            Vector result = v1 * v2;
        }

        [TestMethod]
        public void ScalarMultipleTest1()
        {
            // arrange
            Vector v1 = _vectorFactory.CreateVector(new List<double> { 1, 2, 3 });
            Vector v2 = _vectorFactory.CreateVector(new List<double> { 4, 5, 6 });

            // act
            double result = v1.ScalarMultiply(v2);

            // assert
            double expected = 32;
            Assert.IsTrue(DoubleComparator.AreEqual(result, expected));
        }

        [TestMethod]
        [ExpectedException(typeof(OutOfRangeException))]
        public void OutOfRangeTest()
        {
            // arrange
            Vector v1 = _vectorFactory.CreateVector(new List<double> { 1, 2, 3 });
            int index = 6;

            // act
            double result = v1[index];
        }

        [TestMethod]
        [ExpectedException(typeof(SizesDismatchException))]
        public void ScalarMultipleTest2()
        {
            // arrange
            Vector v1 = _vectorFactory.CreateVector(new List<double> { 1, 2, 3 });
            Vector v2 = _vectorFactory.CreateVector(new List<double> { 1, 2, 3, 0 });

            // act
            double result = v1.ScalarMultiply(v2);
        }

        [TestMethod]
        public void NumberMultipleTest1()
        {
            // arrange
            Vector v1 = _vectorFactory.CreateVector(new List<double> { 1, 2, 3 });
            double number = 2;

            // act
            Vector result = v1 * number;

            // assert
            Vector expected = _vectorFactory.CreateVector(new List<double> { 2, 4, 6 });
            Assert.IsTrue(expected.AreEqual(result));
        }

        [TestMethod]
        public void NumberMultipleTest2()
        {
            // arrange
            Vector v1 = _vectorFactory.CreateVector(new List<double> { 1, 2, 3 });
            double number = 2;

            // act
            Vector result = number * v1;

            // assert
            Vector expected = _vectorFactory.CreateVector(new List<double> { 2, 4, 6 });
            Assert.IsTrue(expected.AreEqual(result));
        }

        [TestMethod]
        public void IndexGetTest()
        {
            // arrange
            Vector v1 = _vectorFactory.CreateVector(new List<double> { 1, 2, 3 });

            // act
            double result = v1[1];

            // assert
            double expected = 2;
            Assert.IsTrue(DoubleComparator.AreEqual(expected, result));
        }

        [TestMethod]
        public void IndexSetTest()
        {
            // arrange
            Vector v1 = _vectorFactory.CreateVector(new List<double> { 1, 2, 3 });

            // act
            v1[2] = 6;

            // assert
            Vector expected = _vectorFactory.CreateVector(new List<double> { 1, 2, 6 });
            Assert.IsTrue(expected.AreEqual(v1));
        }
        
    }
}
