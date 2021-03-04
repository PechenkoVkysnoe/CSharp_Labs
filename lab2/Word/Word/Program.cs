using System;

namespace Word
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string[] words = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                Console.Write(words[words.Length - i - 1] + " ");
            }
        }
    }
}
