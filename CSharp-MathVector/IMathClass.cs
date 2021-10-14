using System;
using System.Collections;
using System.Text;

namespace CSharp_LinearAlgebra
{
	public interface IMathVector : IEnumerable
	{
		/// <summary>
		/// Get the dimension of the vector.
		/// </summary>
		/// <value>Count of coordinats.</value>
		int Dimensions { get; }

		/// <summary>
		/// Index of element in vector.
		/// </summary>
		/// <value>Point "i" in vector.</value>
		/// <exception cref="IndexOutOfRangeException">Index out of range</exception>
		double this[int i] { get; set; }

		/// <summary>
		/// Calculate length of vector.
		/// </summary>
		/// <value>Length of vector.</value>
		double Length { get; }

		/// <summary>
		/// Add a vector with a number component.
		/// </summary>
		/// <param name="number">Number, that vector is sum.</param>
		/// <returns>Vector with added number.</returns>
		/// <exception cref="Exception">Error of dimensions.</exception>
		IMathVector SumNumber(double number);

		/// <summary>
		/// Multiply a vector with a number component.
		/// </summary>
		/// <param name="number">Число, с которым будет умножение всех элементов вектора.</param>
		/// <returns>Вектор, умноженный на число.</returns>
		IMathVector MultiplyNumber(double number);

		/// <summary>
		/// Add a vector with a vector component.
		/// </summary>
		/// <param name="vector">MathVector.</param>
		/// <returns>Вектор, сложенный покомпонентно с другим вектором.</returns>
		/// <exception cref="Exception">Error of dimensions.</exception>
		IMathVector Sum(IMathVector vector);

		/// <summary>
		/// Multiply a vector with a vector component.
		/// </summary>
		/// <param name="vector">MathVector.</param>
		/// <returns>Вектор, умноженный покомпонентно на другой вектор.</returns>
		/// <exception cref="Exception">Error of dimensions.</exception>
		IMathVector Multiply(IMathVector vector);

		/// <summary>
		/// Scalar multiply a vector with a vector.
		/// </summary>
		/// <param name="vector">Mathvector.</param>
		/// <returns>Result of scalar multiply a vector with a vector.</returns>
		/// <exception cref="Exception">Error of dimensions.</exception>
		double ScalarMultiply(IMathVector vector);

		/// <summary>
		/// Divide a vector with a vector component.
		/// </summary>
		/// <param name="vector">MathVector.</param>
		/// <returns>Divided vector on vector component.</returns>
		/// <exception cref="Exception">Error of dimensions.</exception>
		/// <exception cref="DivideByZeroException">Divide by zero.</exception>
		public IMathVector Divide(IMathVector vector);

		/// <summary>
		/// Divide a vector with a number component.
		/// </summary>
		/// <param name="number">Double number</param>
		/// <returns>Divided vector on vector component.</returns>
		/// <exception cref="DivideByZeroException">Divide by zero</exception>
		public IMathVector Divide(double number);


		/// <summary>
		/// Calculate Evklid distance to vector.
		/// </summary>
		/// <param name="vector">MathVector.</param>
		/// <returns>Distance between two vectors.</returns>
		/// <exception cref="Exception">Error of dimensions</exception>
		/// http://kadm.kmath.ru/files/linalg17.pdf#:~:text=Расстоянием%20между%20векторами%20x%20и,с%20обычным%20скалярным%20произведением%20векторов
		double CalcDistance(IMathVector vector);
	}
}
