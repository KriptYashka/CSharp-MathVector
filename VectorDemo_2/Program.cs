using System;
using CSharp_LinearAlgebra;

namespace VectorDemo_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] points1 = new double[] { 1, -2, 3, 0 };
            double[] points2 = new double[] { 2, 2, 2, 10 };
            MathVector vec1 = new MathVector(points1);
            MathVector vec2 = new MathVector(points2);
            double res = 0;

            Console.WriteLine("Суммирование");
            MathVector vec_res = (MathVector)(vec1 + vec2);
            Console.WriteLine(vec_res);
            vec_res = (MathVector)(vec1.Sum(vec2));
            Console.WriteLine(vec_res);
            vec_res = (MathVector)(vec1 - vec2);
            Console.WriteLine(vec_res);
            vec_res = (MathVector)(vec1.SumNumber(2));
            Console.WriteLine(vec_res);
            vec_res = (MathVector)(vec1 + 2);
            Console.WriteLine(vec_res);
            Console.WriteLine("Умножение");
            vec_res = (MathVector)(vec1.Multiply(vec2));
            Console.WriteLine(vec_res);
            vec_res = (MathVector)(vec1 * vec2);
            Console.WriteLine(vec_res);
            vec_res = (MathVector)(vec1 * 2);
            Console.WriteLine(vec_res);
            Console.WriteLine("Скалярное");
            res = vec1 % vec2;
            Console.WriteLine(res);
            res = vec1.ScalarMultiply(vec2);
            Console.WriteLine(res);
            Console.WriteLine("Дистанция");
            res = vec1.CalcDistance(vec2);
            Console.WriteLine(res);
            Console.WriteLine("Деление");
            vec_res = (MathVector)(vec1 / vec2);
            Console.WriteLine(vec_res);
            vec_res = (MathVector)(vec1.Divide(vec2));
            Console.WriteLine(vec_res);
            vec_res = (MathVector)(vec1.Divide(2));
            Console.WriteLine(vec_res);
            Console.WriteLine("Enumerator");
            foreach(double point in vec1)
            {
                Console.WriteLine(point);
            }
        }
    }
}
