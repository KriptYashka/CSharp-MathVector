using System;
using System.Collections;
using CSharp_LinearAlgebra;

namespace VectorDemo
{
    class Program
    {
        /// <summary>
        /// Операции меню, которые можно совершить в приложении
        /// </summary>
        public enum Operations
        {
            exit = 0,
            add = 1,
            show = 2,
            sum = 3,
            minus = 4,
            multiply = 5,
            divide = 6,
            distance = 7,
        }

        private static MathVector ReadVector()
        {
            Console.Write("Введите точки: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string[] points = Console.ReadLine().Split();
            Console.ResetColor();
            double[] newPoints = new double[points.Length];
            for (int i = 0; i < points.Length; ++i)
            {
                newPoints[i] = Convert.ToDouble(points[i]);
            }
            Console.WriteLine($"Вектор с количеством точек {points.Length} сохранен!\n");
            return new MathVector(newPoints);
        }

        private static void WriteMenu()
        {
            string text = "1. Добавить вектор\n2. Показать всё\n3. Суммировать\n";
            text += "4. Вычесть\n5. Умножить вектор\n6. Делить\n7. Дистанция между векторами\n";
            text += "0. Выход\n----------\nВыбор: ";
            Console.Write(text);
        }

        private static Operations ReadSelect()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string select = Console.ReadLine();
            Console.ResetColor();
            return (Operations)Convert.ToInt32(select);
        }

        private static int ReadNumberOrVector()
        {
            Console.Write("1. Работать с числом\n2. Работать с другим вектором\nВыбор: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string sel = Console.ReadLine();
            Console.ResetColor();
            return Convert.ToInt32(sel);
        }

        private static int SelectIdVector()
        {
            Console.Write("Введите ID вектора: ");
            Console.ForegroundColor = ConsoleColor.Green;
            int idCurrent = Convert.ToInt32(Console.ReadLine());
            Console.ResetColor();
            return idCurrent - 1;
        }

        private static int ReadNumber()
        {
            Console.Write("Введите число: ");
            Console.ForegroundColor = ConsoleColor.Green;
            int number = Convert.ToInt32(Console.ReadLine());
            Console.ResetColor();
            return number;
        }

        private static bool WriteErrorId(int id, int count)
        {
            bool flag = false;
            if ((id < 0) || (id >= count))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ошибка: вектора {id + 1} не существует");
                Console.ResetColor();
                flag = true;
            }
            return flag;
        }

        private static bool WriteErrorDimensions(IMathVector vec1, IMathVector vec2)
        {
            bool flag = false;
            if (vec1.Dimensions != vec2.Dimensions)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ошибка: вектора имеют разные пространства");
                Console.ResetColor();
                flag = true;
            }
            return flag;
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Программа \"Математические вектора\"\n");
            Console.ResetColor();

            /* Проверка на отработку Exception */

            double[] points = {1, 4, 4};
            MathVector vector1 = new MathVector(points);
            points = new double[] { 1, 4, 4, 3};
            MathVector vector2 = new MathVector(points);
            Console.WriteLine($"{vector1 + vector2}");

            MathVector[] vectors = new MathVector[50];
            int count = 0;
            Operations select;
            int sel, idCurrent, idSecond;
            do
            {
                WriteMenu();
                select = ReadSelect();
                switch (select)
                {
                    case Operations.add:
                        vectors[count++] = ReadVector();
                        break;
                    case Operations.show:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine();
                        for (int i = 0; i < count; ++i)
                        {
                            Console.WriteLine($"{i + 1}. " + vectors[i]);
                        }
                        Console.ResetColor();
                        break;
                    case Operations.sum:
                        sel = ReadNumberOrVector();
                        idCurrent = SelectIdVector();
                        if (WriteErrorId(idCurrent, count)) break;
                        if (sel == 1)
                        {
                            int k = ReadNumber();
                            vectors[idCurrent] = (MathVector)(vectors[idCurrent] + k); // Взаимодействие с интерфейсом
                        }
                        else if (sel == 2)
                        {
                            idSecond = SelectIdVector();
                            if (WriteErrorId(idSecond, count)) break;
                            if (WriteErrorDimensions(vectors[idCurrent], vectors[idSecond])) break;
                            vectors[idCurrent] = (MathVector)(vectors[idCurrent] + vectors[idSecond]);
                        }
                        break;
                    case Operations.minus:
                        sel = ReadNumberOrVector();
                        idCurrent = SelectIdVector();
                        if (WriteErrorId(idCurrent, count)) break;
                        if (sel == 1)
                        {
                            int k = ReadNumber();
                            vectors[idCurrent] = (MathVector)(vectors[idCurrent] - k); // Взаимодействие с интерфейсом
                        }
                        else if (sel == 2)
                        {
                            idSecond = SelectIdVector();
                            if (WriteErrorId(idSecond, count)) break;
                            if (WriteErrorDimensions(vectors[idCurrent], vectors[idSecond])) break;
                            vectors[idCurrent] = (MathVector)(vectors[idCurrent] - vectors[idSecond]);
                        }
                        break;
                    case Operations.multiply:
                        sel = ReadNumberOrVector();
                        idCurrent = SelectIdVector();
                        if (WriteErrorId(idCurrent, count)) break;
                        if (sel == 1)
                        {
                            int k = ReadNumber();
                            vectors[idCurrent] = (MathVector)(vectors[idCurrent] * k); // Взаимодействие с интерфейсом
                        }
                        else if (sel == 2)
                        {

                            idSecond = SelectIdVector();
                            if (WriteErrorId(idSecond, count)) break;
                            if (WriteErrorDimensions(vectors[idCurrent], vectors[idSecond])) break;
                            Console.Write("1. Покомпонентное умножение\n2. Скалярное умножение\nВыбор: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            sel = Convert.ToInt32(Console.ReadLine());
                            Console.ResetColor();
                            if (sel == 1)
                            {
                                vectors[idCurrent] = (MathVector)(vectors[idCurrent] * vectors[idSecond]);
                            } else if (sel == 2)
                            {
                                double res = vectors[idCurrent] % vectors[idSecond];
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine($"Скалярное умножение векторов {idCurrent} и {idSecond}: {res}");
                                Console.ResetColor();
                            }
                        }
                        break;
                    case Operations.divide:
                        sel = ReadNumberOrVector();
                        idCurrent = SelectIdVector();
                        if (WriteErrorId(idCurrent, count)) break;
                        if (sel == 1)
                        {
                            int k = ReadNumber();
                            vectors[idCurrent] = (MathVector)(vectors[idCurrent] / k); // Взаимодействие с интерфейсом
                        }
                        else if (sel == 2)
                        {
                            idSecond = SelectIdVector();
                            if (WriteErrorId(idSecond, count)) break;
                            vectors[idCurrent] = (MathVector)(vectors[idCurrent] / vectors[idSecond]);
                        }
                        break;
                    case Operations.distance:
                        idCurrent = SelectIdVector();
                        idSecond = SelectIdVector();
                        if (WriteErrorId(idCurrent, count)) break;
                        if (WriteErrorId(idSecond, count)) break;
                        if (WriteErrorDimensions(vectors[idCurrent], vectors[idSecond])) break;
                        double dist = vectors[idCurrent].CalcDistance(vectors[idSecond]);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"Расстояние между вектором {idCurrent + 1} и {idSecond + 1} равно {dist}");
                        Console.ResetColor();
                        break;
                    default:
                        select = Operations.exit;
                        break;
                }
            } while (select != Operations.exit);
        }
    }
}
