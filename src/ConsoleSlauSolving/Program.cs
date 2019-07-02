using LinearAlgebra.Matrices;
using LinearAlgebra.Vectors;
using SlauSolving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSlauSolving
{
    class Program
    {
        static void Main(string[] args)
        {
            IVectorFactory vectorFactory = new DenseVectorFactory();
            IMatrixFactory matrixFactory = new DenseMatrixFactory();

            ISlauSolver slauSolver = new ConjugateGradientSlauSolver(vectorFactory, matrixFactory);
            Console.ForegroundColor = ConsoleColor.Red; 
            Console.WriteLine($"Введите размер матрицы А.");
            Console.ResetColor(); 

            int Size = Convert.ToInt32(Console.ReadLine());
            Matrix mas = matrixFactory.CreateMatrix(Size, Size);
            Vector func = vectorFactory.CreateVector(Size);

            for (int i = 0; i < Size; i++)
            {
                func[i] = Size + 1;
                for (int j = 0; j < Size; j++)
                {
                    if (i == j)
                        mas[i, j] = 2;
                    else
                        mas[i, j] = 10;
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"A * X = B.");
            Console.WriteLine($"A:");
            Console.ResetColor();

            Console.WriteLine(mas);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"B:");
            Console.ResetColor();
            Console.WriteLine(func);

            Vector result = slauSolver.SolveSlau(mas, func);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("----------");
            Console.WriteLine($"Расчет по формуле Флетчера - Ривса:");
            Console.WriteLine($"X:");
            Console.ResetColor();
            Console.WriteLine(result);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Создадим возмущение, прибавив 0.0001 к В.");

            for (int i = 0; i < Size; i++)
            {
                func[i] = Size + 1 + 0.0001;
            }
            //Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"A * X = B.");
            Console.WriteLine($"A:");
            Console.ResetColor();
            Console.WriteLine(mas);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"B:");
            Console.ResetColor();
            Console.WriteLine(func);

            result = slauSolver.SolveSlau(mas, func);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("----------");
            Console.WriteLine($"X:");
            Console.ResetColor();
            Console.WriteLine(result);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Расчет по формуле Полака - Райбера:");
            Console.ResetColor();
            for (int i = 0; i < Size; i++)
            {
                func[i] = Size + 1;
            }
            slauSolver = new ConjugateGradientPolakRibiereSlauSolver(vectorFactory, matrixFactory);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"A * X = B.");
            Console.WriteLine($"A:");
            Console.ResetColor();
            Console.WriteLine(mas);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"B:");
            Console.ResetColor();
            Console.WriteLine(func);

            result = slauSolver.SolveSlau(mas, func);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("----------");
            Console.WriteLine($"X:");
            Console.ResetColor();
            Console.WriteLine(result);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Создадим возмущение, прибавив 0.0001 к В.");
            for (int i = 0; i < Size; i++)
            {
                func[i] = Size + 1 + 0.0001;
            }
            Console.WriteLine($"A * X = B.");
            Console.WriteLine($"A:");
            Console.ResetColor();
            Console.WriteLine(mas);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"B:");
            Console.ResetColor();
            Console.WriteLine(func);

            result = slauSolver.SolveSlau(mas, func);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("----------");
            Console.WriteLine($"X:");
            Console.ResetColor();
            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
