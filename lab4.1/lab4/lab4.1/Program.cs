using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace lab4
{
    class Program
    { 
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(int i);
        static void Main()
        {
            while (true)
            {
                for (int i = 0; i < 255; i++)
                {
                    if (GetAsyncKeyState(i) == 32769)
                    {
                        Console.Write((Keys)i);
                    }
                }
                System.Threading.Thread.Sleep(10);
            }
        }
    }
}