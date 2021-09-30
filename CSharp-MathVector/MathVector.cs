﻿using System;
using System.Collections;

namespace CSharp_LinearAlgebra
{
	public class MathVector : IMathVector
	{
		private double[] points;

		public MathVector(MathVector vector)
        {
			points = new double[vector.Dimensions];
			for (int i = 0; i < vector.Dimensions; ++i)
            {
				this.points[i] = vector[i];
            }
        }

		public MathVector(double[] newPoints)
        {
			points = new double[newPoints.Length];
			for (int i = 0; i < newPoints.Length; ++i)
            {
				this.points[i] = newPoints[i];
            }
        }

		public int Dimensions 
		{
            get
            {
				return points.Length;
            }
		}

		public double this[int i] 
		{
			get 
			{
				if (i < 0 || i >= this.Dimensions)
					throw new Exception("Ошибка разных пространств векторов");
				return points[i];
			}
			set 
			{
				if (i < 0 || i >= this.Dimensions)
					throw new IndexOutOfRangeException();
				points[i] = value;
			}
		}

		public double Length 
		{
            get
            {
				double result = 0;
				foreach (double point in points)
                {
					result += point * point;
                }
				result = Math.Sqrt(result);
				return result;
            }
		}

		public IMathVector SumNumber(double number) {
			double[] newPoints = new double[Dimensions];
			for (int i = 0; i < Dimensions; ++i)
            {
				newPoints[i] = points[i] + number;
            }
			return new MathVector(newPoints);
		}

		public IMathVector MultiplyNumber(double number)
        {
			double[] newPoints = new double[Dimensions];
			for (int i = 0; i < Dimensions; ++i)
			{
				newPoints[i] = points[i] * number;
			}
			return new MathVector(newPoints);
		}

		public IMathVector Sum(IMathVector vector)
        {
			if (vector.Dimensions != this.Dimensions)
			{
				throw new Exception("Ошибка разных пространств векторов");
			}
			double[] newPoints = new double[Dimensions];
			for (int i = 0; i < Dimensions; ++i)
			{
				newPoints[i] = this[i] + vector[i];
			}
			return new MathVector(newPoints);
		}

		public IMathVector Multiply(IMathVector vector)
        {
			if (vector.Dimensions != this.Dimensions)
			{
				throw new Exception("Ошибка разных пространств векторов");
			}
			double[] newPoints = new double[Dimensions];
			for (int i = 0; i < Dimensions; ++i)
			{
				newPoints[i] = vector[i] * this[i];
			}
			return new MathVector(newPoints);
		}

		public double ScalarMultiply(IMathVector vector)
        {
			if (vector.Dimensions != this.Dimensions)
			{
				throw new Exception("Ошибка разных пространств векторов");
			}
			double res = 0;
			for (int i = 0; i < Dimensions; ++i)
			{
				res += vector[i] * this[i];
			}
			return res;
		}

		public IMathVector Divide(double k)
        {
			double[] newPoints = new double[this.Dimensions];
			if (k == 0)
			{
				throw new DivideByZeroException();
			}
			for (int i = 0; i < this.Dimensions; ++i)
			{
				newPoints[i] = this[i] / k;
			}
			return new MathVector(newPoints);
		}

		public IMathVector Divide(IMathVector vector)
		{
			if (vector.Dimensions != this.Dimensions)
			{
				throw new Exception("Ошибка разных пространств векторов");
			}
			double[] newPoints = new double[Dimensions];
			for (int i = 0; i < Dimensions; ++i)
			{
				if (vector[i] == 0)
					throw new DivideByZeroException();
				
				newPoints[i] = this[i] / vector[i];
			}
			return new MathVector(newPoints);
		}

		public double CalcDistance(IMathVector vector)
        {
			if (vector.Dimensions != this.Dimensions)
			{
				throw new Exception("Ошибка разных пространств векторов");
			}
			double[] newPoints = new double[Dimensions];
			for (int i = 0; i < Dimensions; ++i)
			{
				newPoints[i] = this[i] - vector[i];
			}
			double res = new MathVector(newPoints).Length;
			return res;
        }

		/* Перегрузка операторов */
		public static IMathVector operator +(MathVector vector, double k)
		{
			return vector.SumNumber(k);
		}

		public static IMathVector operator +(MathVector vector, MathVector vector2)
		{
			return vector.Sum(vector2);
		}

		public static IMathVector operator -(MathVector vector, double k)
		{
			return vector.SumNumber(-k);
		}

		public static IMathVector operator -(MathVector vector, MathVector vector2)
		{
			return vector.Sum(vector2.MultiplyNumber(-1));
		}

		public static IMathVector operator *(MathVector vector, double k)
		{
			return vector.MultiplyNumber(k);
		}

		public static IMathVector operator *(MathVector vector, MathVector vector2)
		{
			return vector.Multiply(vector2);
		}

		public static IMathVector operator /(MathVector vector, double k)
		{
			return vector.Divide(k);
		}

		public static IMathVector operator /(MathVector vector, MathVector vector2)
		{
			return vector.Divide(vector2);
		}

		public static double operator %(MathVector vector, MathVector vector2)
		{
			return vector.ScalarMultiply(vector2);
		}

		public static bool operator ==(MathVector vector1, MathVector vector2)
        {
			bool flag = true;
			if (vector1.Dimensions != vector2.Dimensions)
            {
				flag = false;
			} else
            {
				for (int i = 0; i < vector1.Dimensions; ++i)
				{
					if (vector1[i] != vector2[i])
					{
						flag = false;
						break;
					}
				}
			}
			return flag;
		}

		public static bool operator !=(MathVector vector1, MathVector vector2)
		{
			bool flag = false;
			if (vector1.Dimensions != vector2.Dimensions)
			{
				flag = true;
			}
			else
			{
				for (int i = 0; i < vector1.Dimensions; ++i)
				{
					if (vector1[i] != vector2[i])
					{
						flag = true;
						break;
					}
				}
			}
			return flag;
		}

		public override string ToString()
		{
			string res = $"Вектор\nКоличество точек: {Dimensions}\nТочки:";
			foreach (double point in this) // Работа с IEnumerator
            {
				res += " " + point.ToString();
            }
			res += $"\nДлина вектора: {Length}\n";
			return res;
		}

		public IEnumerator GetEnumerator()
		{
			return points.GetEnumerator();
		}
	}
}
