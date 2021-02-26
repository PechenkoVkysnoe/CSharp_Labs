using System;

namespace ConsoleApp1
{
    class Program
    {
        //выводим поле
        static void Table(string[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j]);
                }
                Console.WriteLine();
            }
        }
        //ставим прямоугольник
        static void PlayerTurn(int x1, int y1, int x2, int y2, string[,] arr, int player)
        {
            if (player == 1)
            {
                for (int i = y1; i < y2 + 1; i++)
                {
                    for (int j = x1; j < x2 + 1; j++)
                    {
                        arr[i, j] = "11";
                    }
                }
            }
            else
            {
                for (int i = arr.GetLength(0) - y1 - 1; i < arr.GetLength(0) - (y2); i++)
                {
                    for (int j = arr.GetLength(1) - x1 - 1; j < arr.GetLength(1) - (x2); j++)
                    {
                        arr[i, j] = "22";
                    }
                }
            }
        }
        //проверка на то, чтобы не ставился прямоугольник в занятые клетки
        static bool TestTerritory(int x1, int y1, int x2, int y2, string[,] arr, int player)
        {
            bool tr = true;
            if (player == 1)
            {
                for (int i = y1; i < y2 + 1; i++)
                {
                    if (!tr)
                    {
                        break;
                    }
                    for (int j = x1; j < x2 + 1; j++)
                    {
                        if (arr[i, j] == "11" || arr[i, j] == "22")
                        {
                            tr = false;
                            break;
                        }
                    }
                }
            }
            else
            {
                for (int i = arr.GetLength(0) - y1 - 1; i < arr.GetLength(0) - (y2); i++)
                {
                    if (!tr)
                    {
                        break;
                    }
                    for (int j = arr.GetLength(1) - x1 - 1; j < arr.GetLength(1) - (x2); j++)
                    {
                        if (arr[i, j] == "11" || arr[i, j] == "22")
                        {
                            tr = false;
                            break;
                        }
                    }
                }
            }
            return tr;
        }
        //проверка на то, чтобы прямоугольник был присоединен к своей территории
        static bool TestHomeTerritory(int x1, int y1, int x2, int y2, string[,] arr, int progress1, int progress2, int player)
        {
            bool tr = false;
            if (player == 1)
            {
                if (progress1 == 1)
                {
                    tr = true;
                }
                else
                {
                    for (int i = y1; i < y2 + 1; i++)
                    {
                        if (arr[i, x1 - 1] == "11")
                        {
                            tr = true;
                            break;
                        }
                        if (arr[i, x2 + 1] == "11")
                        {
                            tr = true;
                            break;
                        }
                    }
                    for (int j = x1; j < x2 + 1; j++)
                    {
                        if (arr[y1 - 1, j] == "11")
                        {
                            tr = true;
                            break;
                        }
                        if (arr[y2 + 1, j] == "11")
                        {
                            tr = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                if (progress2 == 1)
                {
                    tr = true;
                }
                else
                {
                    for (int i = arr.GetLength(0) - y1 - 1; i < arr.GetLength(0) - 1 - y2 + 1; i++)
                    {
                        if (arr[i, arr.GetLength(1) - x1 - 1 - 1] == "22")
                        {
                            tr = true;
                            break;
                        }
                        if (arr[i, arr.GetLength(1) - x2 - 1 + 1] == "22")
                        {
                            tr = true;
                            break;
                        }
                    }
                    for (int j = arr.GetLength(1) - x1 - 1; j < arr.GetLength(1) - x2 - 1 + 1; j++)
                    {
                        if (arr[arr.GetLength(0) - y1 - 1 - 1, j] == "22")
                        {
                            tr = true;
                            break;
                        }
                        if (arr[arr.GetLength(0) - y2 - 1 + 1, j] == "22")
                        {
                            tr = true;
                            break;
                        }
                    }
                }
            }
            return tr;
        }
        //проверка верности введенных размеров
        static bool TestSize(int x1, int y1, int x2, int y2, int lenght, int widht)
        {
            bool tr = false;
            if (Math.Abs(x1 - x2) + 1 == lenght && Math.Abs(y1 - y2) + 1 == widht)
            {
                tr = true;
            }
            if (Math.Abs(x1 - x2) + 1 == widht && Math.Abs(y1 - y2) + 1 == lenght)
            {
                tr = true;
            }
            return tr;
        }
        //проверка на правильный порядок ввода координат
        static bool TestAngle(int x1, int y1, int x2, int y2, int player)
        {
            bool tr = false;
            if (player == 1)
            {
                if (x2 >= x1 && y2 >= y1)
                {
                    tr = true;
                }
            }
            else
            {
                if (x1 >= x2 && y1 >= y2)
                {
                    tr = true;
                }
            }
            return tr;
        }
        //проверка на то, чтобы первый прямоугольник был в своем угле
        static bool TestStartAngle(int x1, int y1, int x2, int y2, int progress1, int progress2, int player)
        {
            bool tr = true;
            if (player == 1 && progress1 == 1)
            {
                if (x1 != 1 || y1 != 1)
                {
                    tr = false;
                }
            }
            if (player != 1 && progress2 == 1)
            {
                if (x2 != 1 || y2 != 1)
                {
                    tr = false;
                }
            }
            return tr;
        }
        //проверка на заполненность поля
        static bool TestAll(string[,] arr)
        {
            bool tr = true;
            for (int i = 1; i < arr.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < arr.GetLength(1) - 1; j++)
                {
                    if (arr[i, j] == "  ")
                    {
                        tr = false;
                    }
                }
            }
            return tr;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Правила игры:\n" +
                "Два игрока играют на прямоугольном клетчатом поле\n" +
                "Игрокам по очереди генерируются два числа, которые являются сторонами прямоугольника\n" +
                "Прямоугольник должен быть присоединен к существующей территории\n" +
                "Первый прямоугольник первого игрока помещается в левый верхний угол, " +
                "прямоугольник соперника-в противоположный\n" +
                "Если вы не можете сделать ход, вы его пропускаете\n" +
                "Игра является завершенной если все поле заполнено, " +
                "либо ее можно завершить после хода любого из игроков\n" +
                "Побеждает тот, у кого большая территория\n\n" +
                "Для продолжения нажмите Enter");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Введите ширину и длину поля");
            int n, m;
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0 || n > 42)
            {
                Console.WriteLine("Ошибка ввода! Введите натуральное число, не превосходящее 42");
            }
            while (!int.TryParse(Console.ReadLine(), out m) || m <= 0 || m > 42)
            {
                Console.WriteLine("Ошибка ввода! Введите натуральное число, не превосходящее 42");
            }
            Console.Clear();
            string skip;
            string[,] arr = new string[2 + n, 2 + m];

            arr[0, 0] = "  ";
            arr[arr.GetLength(0) - 1, arr.GetLength(1) - 1] = "  ";
            for (int i = 1; i < arr.GetLength(1) - 1; i++)
            {
                if (i < 10)
                {
                    arr[0, i] = i + " ";
                }
                else
                {
                    arr[0, i] = i + "";
                }
            }
            arr[arr.GetLength(0) - 1, 0] = "  ";
            for (int i = 1; i < arr.GetLength(1) - 1; i++)
            {
                if (arr.GetLength(1) - 1 - i < 10)
                {
                    arr[arr.GetLength(0) - 1, i] = (arr.GetLength(1) - i - 1) + " ";
                }
                else
                {
                    arr[arr.GetLength(0) - 1, i] = (arr.GetLength(1) - i - 1) + "";
                }
            }
            for (int i = 1; i < arr.GetLength(0) - 1; i++)
            {
                if (i < 10)
                {
                    arr[i, 0] = i + " ";
                }
                else
                {
                    arr[i, 0] = i + "";
                }
            }
            for (int i = 1; i < arr.GetLength(0) - 1; i++)
            {
                arr[i, arr.GetLength(1) - 1] = (arr.GetLength(0) - 1 - i) + "";
            }
            for (int i = 1; i < arr.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < arr.GetLength(1) - 1; j++)
                {
                    arr[i, j] = "  ";
                }
            }

            int value = 0, progress1 = 0, progress2 = 0;
            string exit = "";
            while (exit != "exit" && !TestAll(arr))
            {
                Random random = new Random();
                int length = random.Next(1, 7);
                int width = random.Next(1, 7);
                Console.Clear();
                Console.WriteLine("Ход " + (value % 2 + 1) + " игрока\n"
                + "Сгенерированные числа:" + length + " " + width);
                Table(arr);
                Console.WriteLine("Чтобы пропустить ход введите skip, в противном случае нажмите Enter");
                skip = Console.ReadLine();
                value++;
                if (skip == "skip")
                {
                    continue;
                }
                if (value % 2 == 1)
                {
                    progress1++;
                }
                else
                {
                    progress2++;
                }
                int x1, y1, x2, y2;
                do
                {
                    Console.Write("Введите координаты левого верхнего угла прямоугольника," +
                        "не превосходящее размеров поля\nx: ");

                    while (!int.TryParse(Console.ReadLine(), out x1) || x1 <= 0 || x1 >= arr.GetLength(1) - 1)
                    {
                        Console.WriteLine("Ошибка ввода! Введите натуральное число," +
                            " не превосходящее размеров поля\nx:");
                    }
                    Console.Write("y: ");
                    while (!int.TryParse(Console.ReadLine(), out y1) || y1 <= 0 || y1 >= arr.GetLength(0) - 1)
                    {
                        Console.WriteLine("Ошибка ввода! Введите натуральное число," +
                            "не превосходящее размеров поля\ny:");
                    }
                    Console.Write("Введите координаты правого нижнего угла прямоугольника\nx: ");

                    while (!int.TryParse(Console.ReadLine(), out x2) || x2 <= 0 || x2 >= arr.GetLength(1) - 1)
                    {
                        Console.WriteLine("Ошибка ввода! Введите натуральное число," +
                            "не превосходящее размеров поля\nx:");
                    }
                    Console.Write("y: ");
                    while (!int.TryParse(Console.ReadLine(), out y2) || y2 <= 0 || y2 >= arr.GetLength(0) - 1)
                    {
                        Console.WriteLine("Ошибка ввода! Введите натуральное число," +
                            "не превосходящее размеров поля\ny:");
                    }

                    if (!TestTerritory(x1, y1, x2, y2, arr, (value - 1) % 2 + 1))
                    {
                        Console.WriteLine("Нельзя захватывать занятые территории, повторите ввод\n");
                    }
                    if (!TestSize(x1, y1, x2, y2, length, width))
                    {
                        Console.WriteLine("Размеры прямоугольника не совпадают с задаными, повторите ввод\n");
                    }
                    if (!TestAngle(x1, y1, x2, y2, value % 2))
                    {
                        Console.WriteLine("Некорректный ввод, повторите ввод\n");
                    }
                    if (!TestStartAngle(x1, y1, x2, y2, progress1, progress2, value % 2))
                    {
                        Console.WriteLine("Первым ходом необходимо ставить прямоугольник в свой угол" +
                            ", повторите ввод\n");
                    }
                    if (!TestHomeTerritory(x1, y1, x2, y2, arr, progress1, progress2, value % 2))
                    {
                        Console.WriteLine("Прямоугольник должен быть присоединен к своей территории" +
                            ", повторите ввод\n");
                    }
                } while (!TestTerritory(x1, y1, x2, y2, arr, value % 2)
                || !TestSize(x1, y1, x2, y2, length, width) || !TestAngle(x1, y1, x2, y2, value % 2)
                || !TestStartAngle(x1, y1, x2, y2, progress1, progress2, value % 2)
                || !TestHomeTerritory(x1, y1, x2, y2, arr, progress1, progress2, value % 2));
                PlayerTurn(x1, y1, x2, y2, arr, value % 2);
                Table(arr);
                Console.WriteLine("Если желаете закончить игру введите exit," +
                    " в противном случае нажмите Enter");
                exit = Console.ReadLine();
            }

            int sum1 = 0, sum2 = 0;
            for (int i = 1; i < arr.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < arr.GetLength(1) - 1; j++)
                {
                    if (arr[i, j] == "11")
                    {
                        sum1++;
                    }
                    if (arr[i, j] == "22")
                    {
                        sum2++;
                    }
                }
            }
            if (sum1 > sum2)
            {
                Console.WriteLine("Победил первый игрок, мои поздравления!!!");
            }
            if (sum1 < sum2)
            {
                Console.WriteLine("Победил второй игрок, мои поздравления!!!");
            }
            if (sum1 == sum2)
            {
                Console.WriteLine("Ничья!");
            }
        }
    }
}


