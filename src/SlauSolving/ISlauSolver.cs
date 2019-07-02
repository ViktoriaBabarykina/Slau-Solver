using LinearAlgebra.Matrices;
using LinearAlgebra.Vectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlauSolving
{
    public interface ISlauSolver
    {
        /// <summary>
        /// Решает СЛАУ вида A*X = B.
        /// </summary>
        /// <param name="leftMatrix">Матрица условий - A.</param>
        /// <param name="resultVector">Вектор результатов - B.</param>
        /// <returns>Вектор решений - X.</returns>
        Vector SolveSlau(Matrix leftMatrix, Vector resultVector);
    }
}
