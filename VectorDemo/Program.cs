using System;
using System.Collections;
using CSharp_LinearAlgebra;

namespace VectorDemo
{
    class Program
    {
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

        private static string ReadSelect()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string select = Console.ReadLine();
            Console.ResetColor();
            return select;
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

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Программа \"Математические вектора\"\n");
            Console.ResetColor();
            // double[] points = {1, 4, 4};
            // MathVector vector1 = new MathVector(points);
            MathVector[] vectors = new MathVector[50];
            int count = 0;
            string select = "";
            int sel, idCurrent, idSecond;
            while (select != "0")
            {
                WriteMenu();
                select = ReadSelect();
                switch (select)
                {
                    case "1":
                        vectors[count++] = ReadVector();
                        break;
                    case "2":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        for (int i = 0; i < count; ++i)
                        {
                            Console.WriteLine($"{i+1}. " + vectors[i]);
                        }
                        Console.ResetColor();
                        break;
                    case "3":
                        sel = ReadNumberOrVector();
                        idCurrent = SelectIdVector();
                        if (sel == 1)
                        {
                            int k = ReadNumber();
                            vectors[idCurrent] = (MathVector)(vectors[idCurrent] + k); // Взаимодействие с интерфейсом
                        } else if (sel == 2)
                        {
                            idSecond = SelectIdVector();
                            vectors[idCurrent] = (MathVector)(vectors[idCurrent] + vectors[idSecond]);
                        }
                        break;
                    case "4":
                        sel = ReadNumberOrVector();
                        idCurrent = SelectIdVector();
                        if (sel == 1)
                        {
                            int k = ReadNumber();
                            vectors[idCurrent] = (MathVector)(vectors[idCurrent] - k); // Взаимодействие с интерфейсом
                        }
                        else if (sel == 2)
                        {
                            idSecond = SelectIdVector();
                            vectors[idCurrent] = (MathVector)(vectors[idCurrent] - vectors[idSecond]);
                        }
                        break;
                    case "5":
                        sel = ReadNumberOrVector();
                        idCurrent = SelectIdVector();
                        if (sel == 1)
                        {
                            int k = ReadNumber();
                            vectors[idCurrent] = (MathVector)(vectors[idCurrent] * k); // Взаимодействие с интерфейсом
                        }
                        else if (sel == 2)
                        {
                            idSecond = SelectIdVector();
                            vectors[idCurrent] = (MathVector)(vectors[idCurrent] * vectors[idSecond]);
                        }
                        break;
                    case "6":
                        sel = ReadNumberOrVector();
                        idCurrent = SelectIdVector();
                        if (sel == 1)
                        {
                            int k = ReadNumber();
                            vectors[idCurrent] = (MathVector)(vectors[idCurrent] / k); // Взаимодействие с интерфейсом
                        }
                        else if (sel == 2)
                        {
                            idSecond = SelectIdVector();
                            vectors[idCurrent] = (MathVector)(vectors[idCurrent] / vectors[idSecond]);
                        }
                        break;
                    case "7":
                        idCurrent = SelectIdVector();
                        idSecond = SelectIdVector();
                        double dist = vectors[idCurrent].CalcDistance(vectors[idSecond]);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"Расстояние между вектором {idCurrent} и вектором {idSecond} равно {dist}");
                        Console.ResetColor();
                        break;
                    default:
                        select = "0";
                        break;
                }
            }
        }
    }
}
