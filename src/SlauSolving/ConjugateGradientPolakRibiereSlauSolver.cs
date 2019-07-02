using LinearAlgebra.Matrices;
using LinearAlgebra.Vectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlauSolving
{
    public class ConjugateGradientPolakRibiereSlauSolver : ISlauSolver
    {
        private int Size { get; set; }

        Matrix mas;
        Vector func;
        double mF = 0;
        Vector Xk, Zk;
        Vector Rk, Sz;
        double alf, bet;
        double Spr, Spr1, Spz;
        double EPS = 0.00001 * 0.00001;
        double Rr;
        private readonly IVectorFactory _vectorFactory;
        private readonly IMatrixFactory _matrixFactory;

        public ConjugateGradientPolakRibiereSlauSolver(IVectorFactory vectorFactory, IMatrixFactory matrixFactory)
        {
            _vectorFactory = vectorFactory;
            _matrixFactory = matrixFactory;
        }

        private void Initialize(Matrix leftMatrix, Vector resultVector)
        {
            Size = leftMatrix.RowsCount;
            mas = leftMatrix;
            func = resultVector;
            Xk = _vectorFactory.CreateVector(Size);
            Rk = _vectorFactory.CreateVector(Size);

            for (int i = 0; i < Size; i++)
            {
                Xk[i] = 0.2;
            }
        }

        private Vector Solve()
        {
            mF = func.ScalarMultiply(func);
            Sz = (mas.MultiplyColumnLeft(Xk)).ConvertToVector();
            Rk = func - Sz;
            Zk = _vectorFactory.CreateVector(Rk);


            do
            {
                Spz = 0;
                Spr = 0;
                Sz = _vectorFactory.CreateVector(Size);
                Sz = mas.MultiplyColumnLeft(Zk).ConvertToVector();
                Spz = Sz.ScalarMultiply(Zk);
                Spr = Rk.ScalarMultiply(Rk);

                alf = Spr / Spz;
                Spr1 = 0;

                Xk = (alf * Zk) + Xk;
                Rk = Rk - alf * Sz;

                for (int i = 0; i < Size; i++)
                {
                    if (i > 0)
                        Rr = Rk[i] - Rk[i - 1];
                    else
                        Rr = 0;
                    Spr1 += Rk[i] * Rr;
                }
                bet = Spr1 / Spr;

                Zk = Rk + bet * Zk;
            }

            while (Spr1 / mF > EPS);

            return Xk;
        }

        public Vector SolveSlau(Matrix leftMatrix, Vector resultVector)
        {
            Initialize(leftMatrix, resultVector);

            return Solve();
        }
    }
}
