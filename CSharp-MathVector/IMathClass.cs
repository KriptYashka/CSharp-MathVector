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
		/// <exception cref="Exception">Индекс вне вектора</exception>
		double this[int i] { get; set; }

		/// <summary>
		/// Рассчитать длину (модуль) вектора.
		/// </summary>
		/// <value>Длина вектора в пространстве.</value>
		double Length { get; }

		/// <summary>
		/// Покомпонентное сложение с числом.
		/// </summary>
		/// <param name="number">Число, с которым будет сложение всех элементов вектора.</param>
		/// <returns>Вектор, сложенный с числом.</returns>
		/// <exception cref="Exception">Ошибка разных пространств векторов</exception>
		IMathVector SumNumber(double number);

		/// <summary>
		/// Покомпонентное умножение на число.
		/// </summary>
		/// <param name="number">Число, с которым будет умножение всех элементов вектора.</param>
		/// <returns>Вектор, умноженный на число.</returns>
		IMathVector MultiplyNumber(double number);

		/// <summary>
		/// Сложение с другим вектором.
		/// </summary>
		/// <param name="vector">Математический вектор.</param>
		/// <returns>Вектор, сложенный покомпонентно с другим вектором.</returns>
		/// <exception cref="Exception">Ошибка разных пространств векторов</exception>
		IMathVector Sum(IMathVector vector);

		/// <summary>
		/// Покомпонентное умножение с другим вектором.
		/// </summary>
		/// <param name="vector">Математический вектор.</param>
		/// <returns>Вектор, умноженный покомпонентно на другой вектор.</returns>
		/// <exception cref="Exception">Ошибка разных пространств векторов</exception>
		IMathVector Multiply(IMathVector vector);

		/// <summary>
		/// Скалярное умножение на другой вектор.
		/// </summary>
		/// <param name="vector">Математический вектор.</param>
		/// <returns>Результат скалярного умножения векторов.</returns>
		/// <exception cref="Exception">Ошибка разных пространств векторов</exception>
		double ScalarMultiply(IMathVector vector);

		/// <summary>
		/// Покомпонентно поделить на другой вектор
		/// </summary>
		/// <param name="vector">Математический вектор.</param>
		/// <returns>Вектор, поделенный покомпонентно на другой вектор.</returns>
		/// <exception cref="Exception">Ошибка разных пространств векторов</exception>
		/// <exception cref="Exception">Деление на нуль</exception>
		public IMathVector Divide(IMathVector vector);

		/// <summary>
		/// Покомпонентно делит вектор на число
		/// </summary>
		/// <param name="number">Вещественное число, на которое делится вектор</param>
		/// <returns>Вектор, поделенный на число</returns>
		/// <exception cref="Exception">Деление на нуль</exception>
		public IMathVector Divide(double number);


		/// <summary>
		/// Вычислить Евклидово расстояние до другого вектора.
		/// </summary>
		/// <param name="vector">Математический вектор.</param>
		/// <returns>Расстояние между двумя векторами.</returns>
		/// <exception cref="Exception">Ошибка разных пространств векторов</exception>
		/// http://kadm.kmath.ru/files/linalg17.pdf#:~:text=Расстоянием%20между%20векторами%20x%20и,с%20обычным%20скалярным%20произведением%20векторов
		double CalcDistance(IMathVector vector);
	}
}
