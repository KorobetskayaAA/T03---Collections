using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            ManageList();
        }

        static void ManageList()
        {
            var list = new List<int>();
            int startPositionToPrint = 0;
            for (; ; )
            {
                Console.Clear();
                ShowMenu();
                PrintList(list, startPositionToPrint);
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.Q: return;
                    case ConsoleKey.R:
                        Console.Clear();
                        Console.WriteLine("ЗАМЕНА ЗНАЧЕНИЯ В УКАЗАННОЙ ПОЗИЦИИ");
                        list[ReadPosition(list.Count - 1)] = ReadNewValue();
                        break;
                    case ConsoleKey.A:
                        Console.Clear();
                        Console.WriteLine("ДОБАВЛЕНИЕ НОВОГО ЗНАЧЕНИЯ В КОНЕЦ СПИСКА");
                        list.Add(ReadNewValue());
                        break;
                    case ConsoleKey.I:
                        Console.Clear();
                        Console.WriteLine("ВСТАВКА НОВОГО ЗНАЧЕНИЯ В УКАЗАННУЮ ПОЗИЦИЮ");
                        list.Insert(ReadPosition(list.Count - 1), ReadNewValue());
                        break;
                    case ConsoleKey.D:
                        Console.Clear();
                        Console.WriteLine("УДАЛЕНИЕ ЗНАЧЕНИЯ В УКАЗАННОЙ ПОЗИЦИИ");
                        list.RemoveAt(ReadPosition(list.Count - 1));
                        break;
                    case ConsoleKey.G:
                        Console.Clear();
                        Console.WriteLine("ГЕНЕРАЦИЯ СПИСКА");
                        list = ListGenerate(ReadLength());
                        break;
                    case ConsoleKey.UpArrow:
                        startPositionToPrint--;
                        break;
                    case ConsoleKey.DownArrow:
                        startPositionToPrint++;
                        break;
                    case ConsoleKey.PageUp:
                        startPositionToPrint -= Console.WindowHeight - 1;
                        break;
                    case ConsoleKey.PageDown:
                        startPositionToPrint += Console.WindowHeight - 1;
                        break;
                }
                if (startPositionToPrint < 0)
                    startPositionToPrint = 0;
                else if (startPositionToPrint > list.Count - GetMaxVisibleLines())
                    startPositionToPrint = list.Count - GetMaxVisibleLines();
            }
        }

        static List<int> ListGenerate(int length)
        {
            var newList = new List<int>(length);
            var random = new Random();
            for (int i = 0; i < length; i++)
            {
                newList.Add(random.Next());
            }
            return newList;
        }

        static int ReadPosition(int maxValue)
        {
            int position;
            Console.WriteLine("Введите индекс значения в списке: ");
            while (!int.TryParse(Console.ReadLine(), out position)
                || position < 0 || position > maxValue)
            {
                Console.Error.WriteLine("Введите целое число в диапазоне от 0 до " + maxValue);
            }
            return position;
        }

        static int ReadNewValue()
        {
            int position;
            Console.WriteLine("Введите значение: ");
            while (!int.TryParse(Console.ReadLine(), out position))
            {
                Console.Error.WriteLine("Введите целое число");
            }
            return position;
        }

        static int ReadLength()
        {
            int length;
            Console.WriteLine("Введите длину списка: ");
            while (!int.TryParse(Console.ReadLine(), out length) && length > 0)
            {
                Console.Error.WriteLine("Введите целое положительное число");
            }
            return length;
        }

        static void ShowMenu()
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            for (int i = 0; i < Console.WindowWidth; i++)
                Console.Write(" ");
            Console.CursorLeft = 0;
            PrintMenuCommand("Q", "Выход");
            PrintMenuCommand("R", "Заменить");
            PrintMenuCommand("A", "Добавить");
            PrintMenuCommand("I", "Вставить");
            PrintMenuCommand("D", "Удалить");
            PrintMenuCommand("G", "Сгенерировать");
            PrintMenuCommand("↑↓PgUpPgDn", "Перемещение");
            Console.WriteLine();
            Console.ResetColor();
        }

        static void PrintMenuCommand(string key, string action)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(key);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" " + action + " ");
        }

        static void PrintList(List<int> list, int startPosition)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Список пуст");
                return;
            }
            Console.WriteLine("Длина списка: {0}", list.Count);
            int maxLines = Math.Min(list.Count - startPosition, GetMaxVisibleLines());
            for (int i = startPosition; i < startPosition + maxLines; i++)
            {
                Console.WriteLine("[{0}] = {1}", i, list[i]);
            }
        }

        static int GetMaxVisibleLines()
        {
            return Console.WindowHeight - 3;
        }
    }
}
