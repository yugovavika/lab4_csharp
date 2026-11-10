using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Tasks1_5
{
    internal static class Checked
    {
        public static int ReadInt(
            string message,
            int min,
            int max)
        {
            int value = 0;
            bool isValid = false;
            string input = string.Empty;

            while (!isValid)
            {
                Console.Write(message);
                input = Console.ReadLine() ?? string.Empty;

                if (int.TryParse(input, out value))
                {
                    if (value >= min && value <= max)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine(
                            "Число вне допустимого диапазона.");
                    }
                }
                else
                {
                    Console.WriteLine(
                        "Ошибка! Введите целое число.");
                }
            }

            return value;
        }

        public static string ReadString(string message)
        {
            string value = string.Empty;

            while (value.Length == 0)
            {
                Console.Write(message);
                value = Console.ReadLine() ?? string.Empty;
                value = value.Trim();

                if (value.Length == 0)
                {
                    Console.WriteLine(
                        "Ошибка! Строка не должна быть пустой.");
                }
            }

            return value;
        }
    }
}
