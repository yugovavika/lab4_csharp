
using System;
using System.Globalization;

namespace Lab4_Tasks6_7
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            TestConstructorsAndProperties();

            TestUnaryOperator();
            TestConversions();

            TestLeftAddition();
            TestRightAddition();

            TestIntersection();
            TestComparison();
        }

        private static void TestConstructorsAndProperties()
        {
            Console.WriteLine();
            Console.WriteLine("ПРОВЕРКА КОНСТРУКТОРОВ");

            LineSegment defaultSegment =
                new LineSegment();

            Console.WriteLine(
                "Без параметров: " +
                defaultSegment.ToString());

            double value = ReadDouble(
                "Введите значение: ");

            LineSegment oneValueSegment =
                new LineSegment(value);

            Console.WriteLine(
                "С одним параметром: " +
                oneValueSegment.ToString());

            double x = ReadDouble(
                "Введите координату X: ");

            double y = ReadDouble(
                "Введите координату Y: ");

            LineSegment twoValuesSegment =
                new LineSegment(x, y);

            Console.WriteLine(
                "С двумя параметрами: " +
                twoValuesSegment.ToString());

            Console.WriteLine();
            Console.WriteLine("ПРОВЕРКА СВОЙСТВ");

            x = ReadDouble("Введите новое значение X: ");
            y = ReadDouble("Введите новое значение Y: ");

            twoValuesSegment.X = x;
            twoValuesSegment.Y = y;

            Console.WriteLine(
                "После изменения свойств: " +
                twoValuesSegment.ToString());
        }

        private static void TestUnaryOperator()
        {
            Console.WriteLine();
            Console.WriteLine("ПРОВЕРКА ОПЕРАТОРА !");

            double x = ReadDouble("Введите X: ");
            double y = ReadDouble("Введите Y: ");

            LineSegment segment =
                new LineSegment(x, y);

            LineSegment result = !segment;

            Console.WriteLine(
                "Исходный отрезок: " + segment);

            Console.WriteLine(
                "Результат операции !: " + result);
        }

        private static void TestConversions()
        {
            Console.WriteLine();
            Console.WriteLine("ПРОВЕРКА ПРЕОБРАЗОВАНИЙ");

            double x = ReadDouble("Введите X: ");
            double y = ReadDouble("Введите Y: ");

            LineSegment segment =
                new LineSegment(x, y);

            int integerValue = segment;
            double doubleValue = (double)segment;

            Console.WriteLine(
                "Исходный отрезок: " + segment);

            Console.WriteLine(
                "Преобразование в int: " +
                integerValue);

            Console.WriteLine(
                "Преобразование в double: " +
                doubleValue);
        }

        private static void TestLeftAddition()
        {
            Console.WriteLine();
            Console.WriteLine(
                "ПРОВЕРКА ОПЕРАТОРА + (ОТРЕЗОК + ЧИСЛО)");

            double x = ReadDouble("Введите X: ");
            double y = ReadDouble("Введите Y: ");

            int value = ReadInt("Введите целое число: ");

            LineSegment original =
                new LineSegment(x, y);

            LineSegment segment = !original;

            LineSegment result = segment + value;

            Console.WriteLine(
                "Исходный отрезок: " + original);

            Console.WriteLine(
                "Исправленный отрезок: " + segment);

            Console.WriteLine(
                "Результат сложения: " + result);
        }

        private static void TestRightAddition()
        {
            Console.WriteLine();
            Console.WriteLine(
                "ПРОВЕРКА ОПЕРАТОРА + (ЧИСЛО + ОТРЕЗОК)");

            double x = ReadDouble("Введите X: ");
            double y = ReadDouble("Введите Y: ");

            int value = ReadInt("Введите целое число: ");

            LineSegment original =
                new LineSegment(x, y);

            LineSegment segment = !original;

            LineSegment result = value + segment;

            Console.WriteLine(
                "Исходный отрезок: " + original);

            Console.WriteLine(
                "Исправленный отрезок: " + segment);

            Console.WriteLine(
                "Результат сложения: " + result);
        }

        private static void TestIntersection()
        {
            Console.WriteLine();
            Console.WriteLine("ПРОВЕРКА ПЕРЕСЕЧЕНИЯ");

            Console.WriteLine("Первый отрезок:");

            double x1 = ReadDouble("Введите X: ");
            double y1 = ReadDouble("Введите Y: ");

            Console.WriteLine("Второй отрезок:");

            double x2 = ReadDouble("Введите X: ");
            double y2 = ReadDouble("Введите Y: ");

            LineSegment first =
                new LineSegment(x1, y1);

            LineSegment second =
                new LineSegment(x2, y2);

            LineSegment correctedFirst = !first;
            LineSegment correctedSecond = !second;

            LineSegment intersection =
                correctedFirst.FindIntersection(
                    correctedSecond);

            Console.WriteLine(
                "Первый исправленный: " +
                correctedFirst);

            Console.WriteLine(
                "Второй исправленный: " +
                correctedSecond);

            if (intersection == null)
            {
                Console.WriteLine(
                    "Пересечения нет.");
            }
            else
            {
                Console.WriteLine(
                    "Пересечение: " + intersection);
            }
        }

        private static void TestComparison()
        {
            Console.WriteLine();
            Console.WriteLine("ПРОВЕРКА ОПЕРАТОРА >");

            Console.WriteLine("Первый отрезок:");

            double x1 = ReadDouble("Введите X: ");
            double y1 = ReadDouble("Введите Y: ");

            Console.WriteLine("Второй отрезок:");

            double x2 = ReadDouble("Введите X: ");
            double y2 = ReadDouble("Введите Y: ");

            LineSegment first =
                new LineSegment(x1, y1);

            LineSegment second =
                new LineSegment(x2, y2);

            LineSegment correctedFirst = !first;
            LineSegment correctedSecond = !second;

            bool result =
                correctedFirst > correctedSecond;

            Console.WriteLine(
                "Первый исправленный: " +
                correctedFirst);

            Console.WriteLine(
                "Второй исправленный: " +
                correctedSecond);

            Console.WriteLine(
                "Первый отрезок включает второй: " +
                result);
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

        private static int ReadInt(string message)
        {
            int value = 0;
            bool isValid = false;

            while (!isValid)
            {
                Console.Write(message);

                string? input = Console.ReadLine();

                isValid = int.TryParse(
                    input,
                    out value);

                if (!isValid)
                {
                    Console.WriteLine(
                        "Ошибка! Введите целое число.");
                }
            }

            return value;
        }
    }
}
