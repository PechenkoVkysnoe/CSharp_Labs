using System;

namespace Time
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime data = DateTime.Now;
            Console.WriteLine(data.ToString("dd.MM.yyyy HH:mm:ss"));
            Console.WriteLine(data.ToString("MM.dd.yyyy HH:mm:ss"));
            string strDate = data.ToString();
            int[] arr = new int[10];
            for (int i = 0; i < strDate.Length; i++)
            {
                switch (strDate[i])
                {
                    case '0':
                        arr[0]++;
                        break;
                    case '1':
                        arr[1]++;
                        break;
                    case '2':
                        arr[2]++;
                        break;
                    case '3':
                        arr[3]++;
                        break;
                    case '4':
                        arr[4]++;
                        break;
                    case '5':
                        arr[5]++;
                        break;
                    case '6':
                        arr[6]++;
                        break;
                    case '7':
                        arr[7]++;
                        break;
                    case '8':
                        arr[8]++;
                        break;
                    case '9':
                        arr[9]++;
                        break;
                    default:
                        break;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("quantity " + i + ": " + arr[i]);
            }
        }
    }
}