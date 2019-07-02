using System;
using LinearAlgebra.Matrices;
using LinearAlgebra.Vectors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlauSolving;

namespace Tests.SlauSolvingTests
{
    [TestClass]
    public class ConjugateGradientSlauSolverTest : SlauSolverTest
    {
        public ConjugateGradientSlauSolverTest()
        {
            _matrixFactory = new DenseMatrixFactory();
            _vectorFactory = new DenseVectorFactory();
            _slauSolverFactory = new ConjugateGradientSlauSolverFactory(_vectorFactory, _matrixFactory);
        }
    }
}
