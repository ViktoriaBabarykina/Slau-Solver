using LinearAlgebra.Matrices;
using LinearAlgebra.Vectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlauSolving
{
    public class ConjugateGradientSlauSolverFactory : ISlauSolverFactory
    {
        private IMatrixFactory _matrixFactory;
        private IVectorFactory _vectorFactory;

        public ConjugateGradientSlauSolverFactory(IVectorFactory vectorFactory, IMatrixFactory matrixFactory)
        {
            _vectorFactory = vectorFactory;
            _matrixFactory = matrixFactory;
        }

        public ISlauSolver CreateSlauSolver()
        {
            return new ConjugateGradientSlauSolver(_vectorFactory, _matrixFactory);
        }
    }
}
