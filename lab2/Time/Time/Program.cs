using System;

namespace Time
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime data = DateTime.Now;
            Console.WriteLine(data.ToString("dd.MM.yyyy HH:mm:ss"));
            Console.WriteLine(data.ToString("MM.dd.yyyy hh:mm:ss"));
            string firstStrDate = data.ToString("dd.MM.yyyy HH:mm:ss");
            string secondStrDate = data.ToString("MM.dd.yyyy hh:mm:ss");
            int[] firstArr = new int[10];
            int[] secondArr = new int[10];
            for (int i = 0; i < firstStrDate.Length; i++)
            {
                switch (firstStrDate[i])
                {
                    case '0':
                        firstArr[0]++;
                        break;
                    case '1':
                        firstArr[1]++;
                        break;
                    case '2':
                        firstArr[2]++;
                        break;
                    case '3':
                        firstArr[3]++;
                        break;
                    case '4':
                        firstArr[4]++;
                        break;
                    case '5':
                        firstArr[5]++;
                        break;
                    case '6':
                        firstArr[6]++;
                        break;
                    case '7':
                        firstArr[7]++;
                        break;
                    case '8':
                        firstArr[8]++;
                        break;
                    case '9':
                        firstArr[9]++;
                        break;
                    default:
                        break;
                }
                switch (secondStrDate[i])
                {
                    case '0':
                        secondArr[0]++;
                        break;
                    case '1':
                        secondArr[1]++;
                        break;
                    case '2':
                        secondArr[2]++;
                        break;
                    case '3':
                        secondArr[3]++;
                        break;
                    case '4':
                        secondArr[4]++;
                        break;
                    case '5':
                        secondArr[5]++;
                        break;
                    case '6':
                        secondArr[6]++;
                        break;
                    case '7':
                        secondArr[7]++;
                        break;
                    case '8':
                        secondArr[8]++;
                        break;
                    case '9':
                        secondArr[9]++;
                        break;
                    default:
                        break;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("quantity " + i + ": " + firstArr[i]+", "+ secondArr[i]);
            }
        }
    }
}