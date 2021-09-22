using System;
using System.Collections;

namespace CSharp_LinearAlgebra
{
	public class MathVector : IMathVector
	{
		private double[] points;

		public MathVector(MathVector vector)
        {
			this.points = vector.points;
        }

		public MathVector(double[] newPoints)
        {
			points = newPoints;
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
				return points[i];
			}
			set 
			{
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
				return null;
			} 
			else
            {
				double[] newPoints = new double[Dimensions];
				for (int i = 0; i < Dimensions; ++i)
				{
					newPoints[i] = this[i] + vector[i];
				}
				return new MathVector(newPoints);
			}
		}

		public IMathVector Multiply(IMathVector vector)
        {
			if (vector.Dimensions != this.Dimensions)
			{
				return null;
			}
			else
			{
				double[] newPoints = new double[Dimensions];
				for (int i = 0; i < Dimensions; ++i)
				{
					newPoints[i] = vector[i] * this[i];
				}
				return new MathVector(newPoints);
			}
		}

		public double ScalarMultiply(IMathVector vector)
        {
			if (vector.Dimensions != this.Dimensions)
			{
				return 0;
			}
			else
			{
				double res = 0;
				for (int i = 0; i < Dimensions; ++i)
				{
					res += vector[i] * this[i];
				}
				return res;
			}
		}

		public IMathVector Divide(double k)
        {
			double[] newPoints = new double[this.Dimensions];
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
				return null;
			}
			else
			{
				double[] newPoints = new double[Dimensions];
				for (int i = 0; i < Dimensions; ++i)
				{
					newPoints[i] = this[i] / vector[i];
				}
				return new MathVector(newPoints);
			}
		}

		public double CalcDistance(IMathVector vector)
        {
			if (vector.Dimensions != this.Dimensions)
			{
				return 0;
			}
			else
			{
				double[] newPoints = new double[Dimensions];
				for (int i = 0; i < Dimensions; ++i)
				{
					newPoints[i] = this[i] - vector[i];
				}
				double res = new MathVector(newPoints).Length;
				return res;
			}
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
