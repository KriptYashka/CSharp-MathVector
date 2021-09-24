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
		/// <value>Количество координат.</value>
		int Dimensions { get; }

		/// <summary>
		/// Индексатор для доступа к элементам вектора. Нумерация с нуля.
		/// </summary>
		/// <value>i-ая точка в математическом векторе.</value>
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
		IMathVector Sum(IMathVector vector);

		/// <summary>
		/// Покомпонентное умножение с другим вектором.
		/// </summary>
		/// <param name="vector">Математический вектор.</param>
		/// <returns>Вектор, умноженный покомпонентно на другой вектор.</returns>
		IMathVector Multiply(IMathVector vector);

		/// <summary>
		/// Скалярное умножение на другой вектор.
		/// </summary>
		/// <param name="vector">Математический вектор.</param>
		/// <returns>Результат скалярного умножения векторов.</returns>
		double ScalarMultiply(IMathVector vector);

		/// <summary>
		/// Покомпонентно поделить на другой вектор
		/// </summary>
		/// <param name="vector">Математический вектор.</param>
		/// <returns>Вектор, поделенный покомпонентно на другой вектор.</returns>
		public IMathVector Divide(IMathVector vector);

		/// <summary>
		/// Покомпонентно делит вектор на число
		/// </summary>
		/// <param name="number">Вещественное число, на которое делится вектор</param>
		/// <returns>Вектор, поделенный на число</returns>
		public IMathVector Divide(double number);


		/// <summary>
		/// Вычислить Евклидово расстояние до другого вектора.
		/// </summary>
		/// <param name="vector">Математический вектор.</param>
		/// <returns>Расстояние между двумя векторами.</returns>
		/// http://kadm.kmath.ru/files/linalg17.pdf#:~:text=Расстоянием%20между%20векторами%20x%20и,с%20обычным%20скалярным%20произведением%20векторов
		double CalcDistance(IMathVector vector);
	}
}
