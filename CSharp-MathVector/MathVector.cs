using System;
using System.Collections;

namespace CSharp_LinearAlgebra
{
	public class MathVector : IMathVector
	{
		private double[] points;

		/// <summary>
		/// Create MathVector with points from parameter vector
		/// </summary>
		/// <param name="vector">Copy vector</param>
		public MathVector(MathVector vector)
        {
			points = new double[vector.Dimensions];
			for (int i = 0; i < vector.Dimensions; ++i)
            {
				this.points[i] = vector[i];
            }
        }
		/// <summary>
		/// Create MathVector with points from parameter array
		/// </summary>
		/// <param name="newPoints">Array of points</param>
		public MathVector(double[] newPoints)
        {
			points = new double[newPoints.Length];
			for (int i = 0; i < newPoints.Length; ++i)
            {
				this.points[i] = newPoints[i];
            }
        }

		/// <summary>
		/// Get the dimension of the vector.
		/// </summary>
		/// <value>Count of coordinats.</value>
		public int Dimensions 
		{
            get
            {
				return points.Length;
            }
		}

		/// <summary>
		/// Index of element in vector.
		/// </summary>
		/// <value>Point "i" in vector.</value>
		/// <exception cref="IndexOutOfRangeException">Index out of range</exception>
		public double this[int i] 
		{
			get 
			{
				if (i < 0 || i >= this.Dimensions)
					throw new IndexOutOfRangeException();
				return points[i];
			}
			set 
			{
				if (i < 0 || i >= this.Dimensions)
					throw new IndexOutOfRangeException();
				points[i] = value;
			}
		}

		/// <summary>
		/// Calculate length of vector.
		/// </summary>
		/// <value>Length of vector.</value>
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

		/// <summary>
		/// Add a vector with a number component.
		/// </summary>
		/// <param name="number">Number, that vector is sum.</param>
		/// <returns>Vector with added number.</returns>
		/// <exception cref="Exception">Error of dimensions.</exception>
		public IMathVector SumNumber(double number) {
			double[] newPoints = new double[Dimensions];
			for (int i = 0; i < Dimensions; ++i)
            {
				newPoints[i] = points[i] + number;
            }
			return new MathVector(newPoints);
		}

		/// <summary>
		/// Multiply a vector with a number component.
		/// </summary>
		/// <param name="number">Число, с которым будет умножение всех элементов вектора.</param>
		/// <returns>Вектор, умноженный на число.</returns>
		public IMathVector MultiplyNumber(double number)
        {
			double[] newPoints = new double[Dimensions];
			for (int i = 0; i < Dimensions; ++i)
			{
				newPoints[i] = points[i] * number;
			}
			return new MathVector(newPoints);
		}

		/// <summary>
		/// Add a vector with a vector component.
		/// </summary>
		/// <param name="vector">MathVector.</param>
		/// <returns>Вектор, сложенный покомпонентно с другим вектором.</returns>
		/// <exception cref="Exception">Error of dimensions.</exception>
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

		/// <summary>
		/// Multiply a vector with a vector component.
		/// </summary>
		/// <param name="vector">MathVector.</param>
		/// <returns>New vector</returns>
		/// <exception cref="Exception">Error of dimensions.</exception>
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

		/// <summary>
		/// Scalar multiply a vector with a vector.
		/// </summary>
		/// <param name="vector">Mathvector.</param>
		/// <returns>Result of scalar multiply a vector with a vector.</returns>
		/// <exception cref="Exception">Error of dimensions.</exception>
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

		/// <summary>
		/// Divide a vector with a number component.
		/// </summary>
		/// <param name="number">Double number</param>
		/// <returns>Divided vector on vector component.</returns>
		/// <exception cref="DivideByZeroException">Divide by zero</exception>
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

		/// <summary>
		/// Divide a vector with a vector component.
		/// </summary>
		/// <param name="vector">MathVector.</param>
		/// <returns>Divided vector on vector component.</returns>
		/// <exception cref="Exception">Error of dimensions.</exception>
		/// <exception cref="DivideByZeroException">Divide by zero.</exception>
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

		/// <summary>
		/// Calculate Evklid distance to vector.
		/// </summary>
		/// <param name="vector">MathVector.</param>
		/// <returns>Distance between two vectors.</returns>
		/// <exception cref="Exception">Error of dimensions</exception>
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
		/// <summary>
		/// Add a vector with a number.
		/// </summary>
		/// <param name="k">Added number</param>
		/// <returns>New vector</returns>
		/// <exception cref="Exception">Error of dimensions.</exception>
		public static IMathVector operator +(MathVector vector, double k)
		{
			return vector.SumNumber(k);
		}
		/// <summary>
		/// Add a vector with a vector component.
		/// </summary>
		/// <param name="vector2">MathVector.</param>
		/// <returns>New vector, added with second vector.</returns>
		/// <exception cref="Exception">Error of dimensions.</exception>
		public static IMathVector operator +(MathVector vector, MathVector vector2)
		{
			return vector.Sum(vector2);
		}

		/// <summary>
		/// Add a vector with a vector component.
		/// </summary>
		/// <param name="k">Minused number.</param>
		/// <returns>New vector.</returns>
		/// <exception cref="Exception">Error of dimensions.</exception>
		public static IMathVector operator -(MathVector vector, double k)
		{
			return vector.SumNumber(-k);
		}
		/// <summary>
		/// Add a vector with a vector component.
		/// </summary>
		/// <param name="vector2">MathVector.</param>
		/// <returns>Вектор, сложенный покомпонентно с другим вектором.</returns>
		/// <exception cref="Exception">Error of dimensions.</exception>
		public static IMathVector operator -(MathVector vector, MathVector vector2)
		{
			return vector.Sum(vector2.MultiplyNumber(-1));
		}
		/// <summary>
		/// Multiply a vector with a number component.
		/// </summary>
		/// <param name="k">Multiply number.</param>
		/// <returns>New vector.</returns>
		public static IMathVector operator *(MathVector vector, double k)
		{
			return vector.MultiplyNumber(k);
		}
		/// <summary>
		/// Multiply a vector with a vector component.
		/// </summary>
		/// <param name="vector2">MathVector.</param>
		/// <returns>New vector, that multiply on second vector.</returns>
		/// <exception cref="Exception">Error of dimensions.</exception>
		public static IMathVector operator *(MathVector vector, MathVector vector2)
		{
			return vector.Multiply(vector2);
		}
		/// <summary>
		/// Divide a vector with a number component.
		/// </summary>
		/// <param name="number">Double number</param>
		/// <returns>Divided vector on vector component.</returns>
		/// <exception cref="DivideByZeroException">Divide by zero</exception>
		public static IMathVector operator /(MathVector vector, double k)
		{
			return vector.Divide(k);
		}
		/// <summary>
		/// Divide a vector with a vector component.
		/// </summary>
		/// <param name="vector">MathVector.</param>
		/// <returns>Divided vector on vector component.</returns>
		/// <exception cref="Exception">Error of dimensions.</exception>
		/// <exception cref="DivideByZeroException">Divide by zero.</exception>
		public static IMathVector operator /(MathVector vector, MathVector vector2)
		{
			return vector.Divide(vector2);
		}
		/// <summary>
		/// Scalar multiply a vector with a vector.
		/// </summary>
		/// <param name="vector">Mathvector.</param>
		/// <returns>Result of scalar multiply a vector with a vector.</returns>
		/// <exception cref="Exception">Error of dimensions.</exception>
		public static double operator %(MathVector vector, MathVector vector2)
		{
			return vector.ScalarMultiply(vector2);
		}
		/// <summary>
		/// Check on equal two mathvectors.
		/// </summary>
		/// <param name="vector2">Mathvector.</param>
		/// <returns>True, if they not equal</returns>
		/// <exception cref="Exception">Error of dimensions.</exception>
		public static bool operator ==(MathVector vector1, MathVector vector2)
        {
			bool flag = true;
			if (vector1.Dimensions != vector2.Dimensions)
            {
				flag = false;
			} 
			else
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

		/// <summary>
		/// Check on equal two mathvectors.
		/// </summary>
		/// <param name="vector2">Mathvector.</param>
		/// <returns>True, if they not equal</returns>
		/// <exception cref="Exception">Error of dimensions.</exception>
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
		/// <summary>
		/// Convert vector to string text.
		/// </summary>
		/// <returns>Information about vector</returns>
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
		/// <summary>
		/// Get iterator of points in vector.
		/// </summary>
		/// <returns>Iterator of points.</returns>
		public IEnumerator GetEnumerator()
		{
			return points.GetEnumerator();
		}


	}
}
