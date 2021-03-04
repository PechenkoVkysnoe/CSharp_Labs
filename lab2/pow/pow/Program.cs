using System;

namespace pow
{
    class Program
    {
        static int Pow(int n)
        {
            int res = 0;
            int value = 2;
            while (n / value > 0)
            {
                res += n / value;
                value *= 2;
            }
            return res;
        }
        static void Main(string[] args)
        {
            int a, b;
            Console.WriteLine("Enter a");
            while (!int.TryParse(Console.ReadLine(), out a) || a <= 0)
            {
                Console.WriteLine("Input Error! Enter a natural number");
            }
            Console.WriteLine("Enter b");
            while (!int.TryParse(Console.ReadLine(), out b) || b <= 0)
            {
                Console.WriteLine("Input Error! Enter a natural number");
            }
            Console.WriteLine(Pow(b) - Pow(a - 1));
        }
    }
}
