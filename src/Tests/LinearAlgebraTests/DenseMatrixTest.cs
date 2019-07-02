using System;
using LinearAlgebra.Matrices;
using LinearAlgebra.Vectors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LinearAlgebraTests
{
    [TestClass]
    public class DenseMatrixTest : MatrixTest
    {
        public DenseMatrixTest()
        {
            _matrixFactory = new DenseMatrixFactory();
            _vectorFactory = new DenseVectorFactory();
        }
    }
}
