using System;
using System.Collections;
using CSharp_LinearAlgebra;

namespace VectorDemo
{
    class Program
    {
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

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Программа \"Математические вектора\"\n");
            Console.ResetColor();
            // double[] points = {1, 4, 4};
            // MathVector vector1 = new MathVector(points);
            MathVector[] vectors = new MathVector[50];
            int count = 0;
            Operations select = Operations.add;
            int sel, idCurrent, idSecond;
            while (select != Operations.exit)
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
                        for (int i = 0; i < count; ++i)
                        {
                            Console.WriteLine($"{i+1}. " + vectors[i]);
                        }
                        Console.ResetColor();
                        break;
                    case Operations.sum:
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
                    case Operations.minus:
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
                    case Operations.multiply:
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
                            Console.Write("1. Покомпонентное умножение\n2. Скалярное умножение\nВыбор: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            sel = Convert.ToInt32(Console.ReadLine());
                            Console.ResetColor();
                            vectors[idCurrent] = (MathVector)(vectors[idCurrent] * vectors[idSecond]);
                        }
                        break;
                    case Operations.divide:
                        sel = ReadNumberOrVector();
                        idCurrent = SelectIdVector();
                        if (idCurrent < 0 || idCurrent >= count){
                            break;
                        }
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
                    case Operations.distance:
                        idCurrent = SelectIdVector();
                        idSecond = SelectIdVector();
                        double dist = vectors[idCurrent].CalcDistance(vectors[idSecond]);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"Расстояние между вектором {idCurrent} и вектором {idSecond} равно {dist}");
                        Console.ResetColor();
                        break;
                    default:
                        select = Operations.exit;
                        break;
                }
            }
        }
    }
}
