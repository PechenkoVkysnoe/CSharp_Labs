using System;
using System.Runtime.InteropServices;

namespace UnmanagedCode
{
    class Program
    {
        [DllImport("MathLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern double Add(double firstValue, double secondValue);

        [DllImport("MathLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern double Subtraction(double firstValue, double secondValue);

        [DllImport("MathLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern double Multiplication(double firstValue, double secondValue);

        [DllImport("MathLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern double Division(double firstValue, double secondValue);
        [DllImport("MathLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern double Abs(double firstValue);
        [DllImport("MathLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern double Opposite(double firstValue);
        [DllImport("MathLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern double Mirror(double firstValue);
        [DllImport("MathLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern double Minimal(double firstValue, int secondValue);
        [DllImport("MathLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern double Maximum(double firstValue, int secondValue);
        [DllImport("MathLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern double Pow(double firstValue, uint secondValue);
        static void Main()
        {
            Console.WriteLine(Add(3.12, 4));
            Console.WriteLine(Subtraction(5, 4));
            Console.WriteLine(Multiplication(50, -1.5));
            Console.WriteLine(Division(-0.5, 2));
            Console.WriteLine(Abs(-42));
            Console.WriteLine(Opposite(4));
            Console.WriteLine(Mirror(-2.5));
            Console.WriteLine(Minimal(5, 4));
            Console.WriteLine(Maximum(5, 4));
            Console.WriteLine(Pow(2.5, 4));
            Console.ReadKey();
        }
    }
}
