using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneCodes
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagePhoneCodes();
        }

        private static void ManagePhoneCodes()
        {
            var phoneCodes = GetPhoneCodes();
            while (true)
            {
                Console.Clear();
                ShowMenu();
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Escape: 
                        return;
                    case ConsoleKey.F1:
                        PrintPhoneCodes(phoneCodes);
                        break;
                    case ConsoleKey.F2:
                        SearchCode(phoneCodes);
                        break;
                    case ConsoleKey.F3:
                        SearchRegion(phoneCodes);
                        break;
                }
            }
        }

        static Dictionary<int, string> GetPhoneCodes()
        {
            return new Dictionary<int, string>()
            {
                [388] = "Алтайская Республика",
                [385] = "Алтайский край",
                [416] = "Амурская область",
                [814] = "Архангельская область",
                [818] = "Архангельская область",
                [851] = "Астраханская область",
                [472] = "Белгородская область",
                [483] = "Брянская область",
                [302] = "Бурятский АО",
                [492] = "Владимирская область",
                [844] = "Волгоградская область",
                [817] = "Вологодская область",
                [820] = "Вологодская область",
                [844] = "Вологодская область",
                [473] = "Воронежская область",
                [426] = "Еврейская область",
                [493] = "Ивановская область",
                [395] = "Иркутская область",
                [866] = "Кабардино-Балкарская Республика",
                [401] = "Калининградская область",
                [484] = "Калужская область",
                [415] = "Камчатка",
                [878] = "Карачаево-Черкессия",
                [384] = "Кемеровская область",
                [833] = "Кировская область",
                [494] = "Костромская область",
                [861] = "Краснодарский край",
                [862] = "Краснодарский край",
                [391] = "Красноярский край",
                [352] = "Курганская область",
                [471] = "Курская область",
                [812] = "Ленинградская область",
                [813] = "Ленинградская область",
                [474] = "Липецкая область",
                [413] = "Магаданская область",
                [495] = "Москва",
                [496] = "Московская область",
                [815] = "Мурманская область",
                [818] = "Ненецкий АО",
                [831] = "Нижегородская область",
                [816] = "Новгородская область",
                [383] = "Новосибирская область",
                [381] = "Омская область",
                [353] = "Оренбургская область",
                [486] = "Орловская область",
                [841] = "Пензенская область",
                [342] = "Пермская область",
                [423] = "Приморский край",
                [811] = "Псковская область",
                [877] = "Республика Адыгея",
                [347] = "Республика Башкортостан",
                [301] = "Республика Бурятия",
                [872] = "Республика Дагестан",
                [873] = "Республика Ингушетия",
                [847] = "Республика Калмыкия",
                [814] = "Республика Карелия",
                [821] = "Республика Коми",
                [836] = "Республика Марий Эл",
                [834] = "Республика Мордовия",
                [867] = "Республика Северная Осетия (Алания)",
                [843] = "Республика Татарстан",
                [855] = "Республика Татарстан",
                [394] = "Республика Тыва",
                [341] = "Республика Удмуртия",
                [390] = "Республика Хакасия",
                [835] = "Республика Чувашия",
                [411] = "Республика Якутия (Саха)",
                [863] = "Ростовская область",
                [491] = "Рязанская область",
                [846] = "Самарская область",
                [848] = "Самарская область",
                [845] = "Саратовская область",
                [424] = "Сахалин",
                [343] = "Свердловская область",
                [481] = "Смоленская область",
                [863] = "Ставропольский край",
                [865] = "Ставропольский край",
                [879] = "Ставропольский край",
                [475] = "Тамбовская область",
                [482] = "Тверская область",
                [382] = "Томская область",
                [487] = "Тульская область",
                [345] = "Тюменская область",
                [346] = "Тюменская область",
                [842] = "Ульяновская область",
                [421] = "Хабаровский край",
                [351] = "Челябинская область",
                [871] = "Чеченская республика",
                [302] = "Читинская область",
                [427] = "Чукотка",
                [349] = "Ямало-Ненецкий Округ",
                [485] = "Ярославская область",
            };
        }

        static void ShowMenu()
        {
            int height = 7, width = 40;
            int left = (Console.WindowWidth - width) / 2;
            int top = (Console.WindowHeight - height) / 2;
            PrintMenuFrame(height, width, left, top);
            Console.WriteLine("      ТЕЛЕФОННЫЕ КОДЫ РЕГИОНОВ РФ");
            PrintMenuCommand(left + 2, "F1", "Вывести все коды");
            PrintMenuCommand(left + 2, "F2", "Поиск по коду");
            PrintMenuCommand(left + 2, "F3", "Поиск по названию");
            PrintMenuCommand(left + 2, "ESC", "Выход");
            Console.ResetColor();
        }

        static void PrintMenuFrame(int height, int width, int left, int top)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string horisontalLine = new string('═', width - 2);
            string line = $"║{new string(' ', width - 2)}║\n";
            Console.SetCursorPosition(left, top);
            Console.Write($"╔{horisontalLine}╗");
            for (int i = 1; i < height - 1; i++)
            {
                Console.SetCursorPosition(left, top + i);
                Console.Write(line);
            }
            Console.SetCursorPosition(left, top + height - 1);
            Console.Write($"╚{new string('═', width - 2)}╝");
            Console.ResetColor();
            Console.SetCursorPosition(left + 1, top + 1);
        }

        static void PrintMenuCommand(int left, string key, string action)
        {
            Console.CursorLeft = left;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(key);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" - " + action);
        }

        static void PrintPhoneCodes(Dictionary<int, string> phoneCodes)
        {
            Console.Clear();
            if (phoneCodes.Count == 0)
            {
                Console.WriteLine("Список телефонных кодов пуст");
                return;
            }
            foreach (var phoneCode in phoneCodes)
            {
                Console.WriteLine("{0} - {1}", phoneCode.Key, phoneCode.Value);
            }
            GoBack();
        }

        static void SearchCode(Dictionary<int, string> phoneCodes)
        {
            Console.Clear();
            Console.WriteLine("ПОИСК ПО КОДУ");
            int code = ReadCode();
            if (phoneCodes.ContainsKey(code))
            {
                Console.WriteLine(phoneCodes[code]);
            }
            else
            {
                Console.WriteLine($"Код {code} не найден.");
            }
            GoBack();
        }

        static void SearchRegion(Dictionary<int, string> phoneCodes)
        {
            Console.Clear();
            Console.WriteLine("ПОИСК ПО НАЗВАНИЮ РЕГИОНА");
            string region = ReadRegion().ToLower();
            bool found = false;
            foreach (var phoneCode in phoneCodes)
            {
                if (phoneCode.Value.ToLower().Contains(region))
                {
                    Console.WriteLine("{0} - {1}", phoneCode.Key, phoneCode.Value);
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine($"Не удалось найти регионы, содержащие в названии {region}");
            }
            GoBack();
        }

        static int ReadCode()
        {
            Console.Write("Введите код: ");
            int code;
            while (!int.TryParse(Console.ReadLine(), out code) && code > 0)
            {
                Console.WriteLine("Код должен быть целым положительным числом");
            }
            return code;
        }

        static string ReadRegion()
        {
            Console.Write("Введите название региона или его часть: ");
            return Console.ReadLine();
        }

        static void GoBack()
        {
            Console.WriteLine("\nЧтобы вернуться в меню, нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
