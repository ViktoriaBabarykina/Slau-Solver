using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinearAlgebra.Matrices;
using LinearAlgebra.Vectors;
using SlauSolving;

namespace Tests.SlauSolvingTests
{
    
    [TestClass]
    public class ConjugateGradientPolakRibiereSlauSolverTest : SlauSolverTest
    {
        public ConjugateGradientPolakRibiereSlauSolverTest()
        {
            _matrixFactory = new DenseMatrixFactory();
            _vectorFactory = new DenseVectorFactory();
            _slauSolverFactory = new ConjugateGradientPolakRibiereSlauSolverFactory(_vectorFactory, _matrixFactory);
        }

    }
}
