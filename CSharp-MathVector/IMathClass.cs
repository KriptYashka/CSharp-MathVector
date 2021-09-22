using System;
using System.Collections;
using System.Text;

namespace CSharp_LinearAlgebra
{
	public interface IMathVector : IEnumerable
	{
		/// <summary>
		/// Получить размерность вектора (количество координат).
		/// </summary>
		int Dimensions { get; }

		/// <summary>
		/// Индексатор для доступа к элементам вектора. Нумерация с нуля.
		/// </summary>
		double this[int i] { get; set; }

		/// <summary>
		/// Рассчитать длину (модуль) вектора.
		/// </summary>
		double Length { get; }

		/// <summary>
		/// Покомпонентное сложение с числом.
		/// </summary>
		IMathVector SumNumber(double number);

		/// <summary>
		/// Покомпонентное умножение на число.
		/// </summary>
		IMathVector MultiplyNumber(double number);

		/// <summary>
		/// Сложение с другим вектором.
		/// </summary>
		IMathVector Sum(IMathVector vector);

		/// <summary>
		/// Покомпонентное умножение с другим вектором.
		/// </summary>
		IMathVector Multiply(IMathVector vector);

		/// <summary>
		/// Скалярное умножение на другой вектор.
		/// </summary>
		double ScalarMultiply(IMathVector vector);

		/// <summary>
		/// Покомпонентно поделить на другой вектор
		/// </summary>
		public IMathVector Divide(IMathVector vector);

		public IMathVector Divide(double k);


		/// <summary>
		/// Вычислить Евклидово расстояние до другого вектора.
		/// </summary>
		/// http://kadm.kmath.ru/files/linalg17.pdf#:~:text=Расстоянием%20между%20векторами%20x%20и,с%20обычным%20скалярным%20произведением%20векторов
		double CalcDistance(IMathVector vector);
	}
}
