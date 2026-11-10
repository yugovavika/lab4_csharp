
using System;
using System.Globalization;

namespace Lab4_Tasks6_7
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            double x1 = ReadDouble(
                "Введите x первого отрезка: ");
            double y1 = ReadDouble(
                "Введите y первого отрезка: ");

            double x2 = ReadDouble(
                "Введите x второго отрезка: ");
            double y2 = ReadDouble(
                "Введите y второго отрезка: ");

            LineSegment first = new LineSegment(x1, y1);
            LineSegment second = new LineSegment(x2, y2);

            Console.WriteLine();
            Console.WriteLine("Исходные отрезки:");
            Console.WriteLine("Первый: " + first);
            Console.WriteLine("Второй: " + second);

            Console.WriteLine();
            Console.WriteLine("Проверка преобразований:");

            int integerValue = first;
            double doubleValue = (double)first;

            Console.WriteLine(
                "Преобразование в int: " + integerValue);
            Console.WriteLine(
                "Преобразование в double: " + doubleValue);

            Console.WriteLine();
            Console.WriteLine("Проверка сложения:");

            LineSegment sumRight = first + 3;
            LineSegment sumLeft = 3 + first;

            Console.WriteLine(
                "Отрезок + 3: " + sumRight);
            Console.WriteLine(
                "3 + отрезок: " + sumLeft);

            Console.WriteLine();
            Console.WriteLine("Проверка пересечения:");

            LineSegment sumIntersection =
                sumRight.FindIntersection(second);

            if (sumIntersection == null)
            {
                Console.WriteLine(
                    "После сложения пересечения нет.");
            }
            else
            {
                Console.WriteLine(
                    "Пересечение после отрезок + 3: " +
                    sumIntersection);
            }

            LineSegment correctedFirst = !first;
            LineSegment correctedSecond = !second;

            Console.WriteLine();
            Console.WriteLine("Проверка оператора !:");

            Console.WriteLine(
                "Первый после !: " + correctedFirst);
            Console.WriteLine(
                "Второй после !: " + correctedSecond);

            LineSegment intersection =
                correctedFirst.FindIntersection(
                    correctedSecond);

            if (intersection == null)
            {
                Console.WriteLine(
                    "Пересечения исправленных отрезков нет.");
            }
            else
            {
                Console.WriteLine(
                    "Пересечение исправленных отрезков: " +
                    intersection);
            }

            Console.WriteLine();
            Console.WriteLine("Проверка оператора >:");

            bool isGreater = first > second;

            Console.WriteLine(
                "Первый содержит второй: " + isGreater);
        }

        private static double ReadDouble(string message)
        {
            double value = 0;
            bool isValid = false;

            while (!isValid)
            {
                Console.Write(message);

                string? input = Console.ReadLine();

                isValid = double.TryParse(
                    input,
                    NumberStyles.Float,
                    CultureInfo.InvariantCulture,
                    out value);

                if (!isValid)
                {
                    Console.WriteLine(
                        "Ошибка! Введите число.");
                }
            }

            return value;
        }
    }
}
