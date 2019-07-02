using System;
using LinearAlgebra.Matrices;
using LinearAlgebra.Vectors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlauSolving;

namespace Tests.SlauSolvingTests
{
    abstract public class SlauSolverTest
    {
        protected IMatrixFactory _matrixFactory;
        protected IVectorFactory _vectorFactory;
        protected ISlauSolverFactory _slauSolverFactory;

        [TestMethod]
        public void SolveSlauTest1()
        {
            // arrange
            double[,] matrix = new double[3, 3] {
                { 4, 2, 2 },
                { 2, 4, 2 },
                { 2, 2, 4 }
            };
            double[] vector1 = new double[3] { 4, 4, 4 };

            Matrix m1 = _matrixFactory.CreateMatrix(matrix);
            Vector v1 = _vectorFactory.CreateVector(vector1);
           
            // act
            ISlauSolver solver = _slauSolverFactory.CreateSlauSolver();
            Vector result = solver.SolveSlau(m1, v1);
            

            // assert
            double[] vector2 = new double[3] { 0.5, 0.5, 0.5 };
            Vector expected = _vectorFactory.CreateVector(vector2);
            
            Assert.IsTrue(expected.AreEqual(result));
        }

        [TestMethod]
        public void SolveSlauTest2()
        {
            // arrange
            double[,] matrix = new double[3, 3] {
                { 4, 2, 2 },
                { 2, 6, 2 },
                { 2, 2, 4 }
            };
            double[] vector1 = new double[3] { 4, 4, 4 };

            Matrix m1 = _matrixFactory.CreateMatrix(matrix);
            Vector v1 = _vectorFactory.CreateVector(vector1);

            // act
            ISlauSolver solver = _slauSolverFactory.CreateSlauSolver();
            Vector result = solver.SolveSlau(m1, v1);

            // assert
            double[] vector2 = new double[3] { 0.5, 0.5, 0.5 };
            Vector expected = _vectorFactory.CreateVector(vector2);

            Assert.IsFalse(expected.AreEqual(result));
        }
    }
}
